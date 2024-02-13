using Product_Inventory_Management_Web_Application_using_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Inventory_Management_Web_Application_using_MVC.Models
{
    public class ProductsBusinessLogic
    {
        //Static Class to store collections of productos objects 
        public static List<Product> productsCollection = new List<Product>()
        {
            new Product(1, "Tide Pods", "Tide Hygienic Clean Heavy Duty Power PODS Laundry Detergent Pacs, Original, 76 count.", 34.99m),
            new Product(2, "OxiClean", "OxiClean Max Efficiency Stain Remover, 5 kg.", 26.99m),
            new Product(3, "Tide PODS with Downy", "Tide PODS with Downy, Liquid Laundry Detergent Pacs, April Fresh, 104-count.", 37.99m),
            new Product(4, "Kirkland Liquid Laundry Detergent", "Kirkland Signature Free and Clear Ultra Clean Liquid Laundry Detergent, 146 Wash Loads.", 23.99m),
            new Product(5, "Purenature Laundry Detergent", "Purenature Laundry Detergent, 660 wash loads", 1998.00m)
        };
       

        //Static Class to store collections of inventory objects 
        public static List<Inventory> inventoryCollection = new List<Inventory>()
        {
            new Inventory(101, 1, 50),
            new Inventory(102, 2, 40),
            new Inventory(103, 3,30),
            new Inventory(104, 4, 25),
            new Inventory(105, 5, 55)
        };

        //Class to store int numbers to set unique Ids for products and inventories registers 
        public static List<UniqueID> UniqueIDCollection = new List<UniqueID>()
        {
             new UniqueID(6,106)

        };

        /// <summary>
        /// Method to add new products objects in the List 
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public bool CreateProducts(Product newProduct, Inventory newInventory) 
        {
            //Adding new products to the List Collection
            productsCollection.Add(newProduct);

            //Adding new inventory's product to the List Collection
            inventoryCollection.Add(newInventory);
            return true;
        }

        
        /// <summary>
        /// Method to return the all Products Collections 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts() 
        {
            return productsCollection;
        }

        /// <summary>
        /// Method to return all the register of inventory's products collection
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory() 
        {
            return inventoryCollection;
        }

        /// <summary>
        /// Method to retunr all register of UniqueID
        /// </summary>
        /// <returns></returns>
        public List<UniqueID> GetAllUniqueID() 
        {
            return UniqueIDCollection;
        }


        /// <summary>
        /// Method to delete the a product passing a InventoryID parameter, if the  
        /// produt object was found (delete & return true) or otherwise return null
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public bool DeleteProductID(int prodId)
        {
            //Find Method to return the object founded or otherwise return null 
            var productFounded = productsCollection.Find(p => p.GetProductID() == prodId);
            var inventoryFounded = inventoryCollection.Find(p => p.GetProductID() == prodId);

            if (productFounded != null && inventoryFounded != null)
            {
                try 
                {
                    //Removing the product object from the List Collection
                    productsCollection.Remove(productFounded);
                    inventoryCollection.Remove(inventoryFounded);
                    return true;
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    // Rollback the transaction if necessary
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

       
        /// <summary>
        /// Method to increment +1 the Product ID and Product Inventory ID
        /// </summary>
        public void IncrementIDs() 
        {
            UniqueIDCollection[0].SetInventoryID();
            UniqueIDCollection[0].SetProductID();
        }
    }
}