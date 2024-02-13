using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Product_Inventory_Management_Web_Application_using_MVC.Models
{
    //Class for store products 
    public class Product
    {
        private int ProductID { get; set; }
        private string Name;
        private string Description;
        private decimal Price;

        public Product(int productID, string name, string description, decimal price)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Price = price;
        }

        //Publics method to Get properties values 
        public int GetProductID()
        {
            return ProductID;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        //Publics method to set properties values 
        public void SetProductID(int prodId)
        {
            ProductID = prodId;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetPrice(decimal price )
        {
            Price=price;
        }
    }

    //Class for store product's inventory    
    public class Inventory
    {
        private int InventoryID;
        private int ProductID;
        private int StockQuantity;

        public Inventory(int inventoryID, int productID, int stock)
        {
            InventoryID = inventoryID;
            ProductID = productID;
            StockQuantity = stock;
        }

        public int GetInventoryID()
        {
            return InventoryID;
        }
       
        public int GetProductID()
        {
            return ProductID;
        }
        public int GetStockQuantity()
        {
            return StockQuantity;
        }

        public void SetProductID(int productId)
        {
            ProductID = productId;
        }

        public void SetInventoryID(int inventoryId)
        {
            InventoryID = inventoryId;
        }


        public void SetStockQuantity(int stock)
        {
            StockQuantity = stock;
        }
    }

    //Class to store the id numbers for new productos and new inventory's registers 
    public class UniqueID
    {
        //Encapsulation: private properties to access them using get-set public methods  
        private int ProductID;

        private int InventoryID;

        public UniqueID(int productID, int inventoryID)
        {
            ProductID = productID;
            InventoryID = inventoryID;
        }

        //Publics method to Get and Set ProductID & Inventory
        public int GetProductID() 
        {
            return ProductID;
        }
       
        public int GetInventoryID()
        {
            return InventoryID;
        }

        public void SetProductID()
        {
            ProductID = ProductID + 1;
        }

        public void SetInventoryID()
        {
            InventoryID = InventoryID + 1;
        }
    }


    /// <summary>
    /// Class to get the conposite model 
    /// </summary>
    public class ViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Inventory> Inventories { get; set; }
        public IEnumerable<UniqueID> UniqueIDs { get; set; }

        public string GetStockQuantityForProduct(int productId)
        {
            var inventory = Inventories.FirstOrDefault(inv => inv.GetProductID() == productId);
            return inventory != null ? inventory.GetStockQuantity().ToString() : "N/A";
        }
    }

}