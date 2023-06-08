using System;
using System.Text;
namespace InventoryManagement.src;

public class Inventory
{
    private static Inventory _instance;
    private static readonly object _lockObject = new Object();
    private Dictionary<string, Item> _items;
    private int _maxCapacity { get; }

    public string barcodeString = "barcode";

    public Dictionary<string, Item> Item
    {
        get { return _items; }
    }

    public static Inventory Instance(int maxCapacity)
    {
        if (_instance == null)
        {
            lock (_lockObject)
            {
                if (_instance == null)
                {
                    _instance = new Inventory(maxCapacity);
                }
            }
        }
        return _instance;
    }

    private Inventory(int maxCapacity)
    {
        _items = new Dictionary<string, Item>();
        this._maxCapacity = maxCapacity;
    }

    public bool AddItem(string item, int itemQuantity)
    {
        int totalQuantity = 0;
        foreach (var element in _items.Values)
        {
            totalQuantity += element.Quantity;
        }

        if ((totalQuantity + itemQuantity) > _maxCapacity)
        {
            return false;
        }

        if (_items.ContainsKey(barcodeString + item))
        {
            _items[barcodeString + item] = new Item(barcodeString + item, item, itemQuantity + _items[barcodeString + item].Quantity);
            return true;
        }

        Item newItem = new Item(barcodeString + item, item, itemQuantity);
        _items.Add(barcodeString + item, newItem);
        return true;
    }

    public bool RemoveItem(string barcode)
    {
        if (_items.ContainsKey(barcode))
        {
            _items.Remove(barcode);
            return true;
        }
        return false;
    }

    public void IncreaseQuantity(int amount, string barcode)
    {
        if (_items.ContainsKey(barcode))
        {
            _items[barcode].IncreaseQuantity(amount);
        }
        else
        {
            throw new ArgumentException("Missing argument barcode");
        }
    }

    public void DecreaseQuantity(int amount, string barcode)
    {
        if (_items.ContainsKey(barcode))
        {
            _items[barcode].DecreaseQuantity(amount);
        }
        else
        {
            throw new ArgumentException("Missing argument barcode");
        }
    }

    public override string ToString()
    {
        StringBuilder printData = new StringBuilder();
        foreach (var item in _items.Values)
        {
            printData.Append($"Product BarCode: {item.Barcode},  Product Name: {item.Name}, Product Quantity: {item.Quantity}");
        }

        return printData.ToString();

    }

    ~Inventory()
    {
        Console.WriteLine("Inventory class destroyed");
    }


}


