using System;
using InventoryManagement.src;

internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory(90);
            inventory.AddItem("books", 10);
            inventory.AddItem("books", 5);
            inventory.AddItem("MacBook", 10);
            inventory.AddItem("ApplePhone", 10);
            inventory.AddItem("Pendrive", 10);
            inventory.AddItem("HardDrive", 10);
            inventory.AddItem("MotherBoard", 10);
            inventory.AddItem("Graphic Card Nvedia", 10);
            inventory.AddItem("Ram DDR5", 10);
            inventory.AddItem("Keyboard", 10);


            Printer print = new Printer();
            print.PrintItem(inventory.Item["barcode"+"books"]);
            print.PrintInventory(inventory);

            
        }
    }