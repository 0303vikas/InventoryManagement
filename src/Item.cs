namespace InventoryManagement.src;

public class Item
{
    private string _barcode;
    private int _quantity; 

    private string _name;

    public Item(string barcode,string name, int quantity) {
        this._barcode = barcode;
        this._name = name;
        this._quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        if( amount > 0)
        {
            _quantity += amount;
        }
        else 
        {
            throw new ArgumentException("The quantity increase amount cannot be negative.");
        }        
    }
   
    public void DecreaseQuantity(int amount)
    {
        if( amount > 0 && _quantity >= amount)
        {
            _quantity -= amount;
        }
        else 
        {
            throw new Exception("Amount should be greater than 0 and less than or equal to inventory quantity.");
        }        
    }

     public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }

    }
    
    public string Barcode
    {
        get { return _barcode;}
    } 

    public string Name
    {
        get { return _name;}
    }



        
}
