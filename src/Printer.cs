using System;
namespace InventoryManagement.src;

public class Printer
{
    public void PrintItem(Item item)
    {
        Console.WriteLine($"Item: {item.Name}, BarCode: {item.Barcode}");
    }

    public void PrintInventory(Inventory inventory)
    {
        int totalItems = 0;
        int uniqueItems = inventory.Item.Count();

        foreach (var item in inventory.Item.Values)
        {
            totalItems += item.Quantity;
        }

        Console.WriteLine("Inventory Information :");
        Console.WriteLine($"Number of Unique Items : {uniqueItems}");
        Console.WriteLine($"Number of Items : {totalItems}");
    }
}
