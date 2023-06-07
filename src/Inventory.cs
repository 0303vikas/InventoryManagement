using System;
namespace InventoryManagement.src;

public class Inventory
{
    // private static Inventory _instance;
    // private static readonly object _lockObject = new Object();

    private Dictionary<string,Item> _items;

    private int _maxCapacity {get;}

    public string barcodeString = "barcode";

    public Inventory (int maxCapacity)    
    {
        _items = new Dictionary<string, Item>();
        this._maxCapacity = maxCapacity;
    }

    // public static Inventory Instance (int maxCapacity)
    // {
        
        
    //         if (_instance == null)
    //         {
    //             lock (_lockObject)
    //             {
    //                 if ( _instance == null) {
    //                     _instance = new Inventory(maxCapacity);
    //                 }
    //             }
    //         }
    //         return _instance;

        

    // }

    public bool AddItem (string item, int itemQuantity)
    {
        if (_items.Count == 0)
        {
            Item newItem = new Item(barcodeString+item,item, itemQuantity);
            _items.Add(barcodeString+item,newItem);
            Console.WriteLine("this line is working");
            return true;
        } 

        int totalQuantity = 0;
        foreach(var element in _items.Values)
        {
            totalQuantity += element.Quantity;
        }

         if ((totalQuantity + itemQuantity )> _maxCapacity)
        {
            return false;

        } else if (_items.ContainsKey(item))
        {
            _items[barcodeString+item] = new Item(barcodeString+item,item, itemQuantity + _items[barcodeString+item].Quantity);

        }
        return true;

    }

    public bool RemoveItem (string barcode) 
    {
        if(_items.ContainsKey(barcode))
        {
            _items.Remove(barcode);
            return true;
        }

        return false;
    }

     public void IncreaseQuantity(int amount, string barcode)
    {
        if(_items.ContainsKey(barcode))
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
       if(_items.ContainsKey(barcode))
        {
            _items[barcode].DecreaseQuantity(amount);
                        
        }
        else 
        {
            throw new ArgumentException("Missing argument barcode");
        }       
    }
    
    public void ViewInventory()
    {
        foreach(var item in _items.Values) 
        {
            Console.WriteLine("Product BarCode: {0},  Product Name: {1}, Product Quantity: {2}",item.Barcode,item.Name, item.Quantity);

        }
    }

    public void Destructor ()
    {
        _items.Clear();
        Console.WriteLine("Inventory Successfully Destroyed");
    }

    public Dictionary<string,Item> Item{
        get {return _items;}
    }        
}


