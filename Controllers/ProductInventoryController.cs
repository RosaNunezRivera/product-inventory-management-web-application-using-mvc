using Product_Inventory_Management_Web_Application_using_MVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Inventory_Management_Web_Application_using_MVC.Controllers
{
    public class ProductInventoryController : Controller
    {
        // GET: ProductInventory
        public ActionResult Index()
        {
            //Creating objects and adding the the List data collection
            ProductsBusinessLogic pbl = new ProductsBusinessLogic();
            var products = pbl.GetAllProducts();
            var inventories = pbl.GetAllInventory();
            var uniquesId = pbl.GetAllUniqueID();

            //Creating a composite view
            var viewModel = new ViewModel
            {
                Products = products,
                Inventories = inventories,
                UniqueIDs = uniquesId
            };

            return View(viewModel);
        }

        /// <summary>
        /// Method to create products with the data get in the form
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="inventoryID"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public ActionResult CreateProduct(int productID, string name, string description, decimal price, int inventoryID, int stock ) 
        {
            //his action should handle the HTTP POST request for adding products and stocks
            ProductsBusinessLogic pbl = new ProductsBusinessLogic();

            //Adding the new products enter bu the user
            Product newProduct = new Product(productID, name, description, price);
           
            //Adding the new inventory of the product enter by the user 
            Inventory newInventory = new Inventory(inventoryID, productID, stock);

            //Validating if the new product had been created in the method of the pbl object
            if (pbl.CreateProducts(newProduct, newInventory))
            {
                //Incrementing in 1 Product ID and Inventory ID
                pbl.IncrementIDs();

                //Redirect to the index method in the controler 'ProductInventory'
                return RedirectToAction("Index", "ProductInventory");
            }

            return null;
        }

        /// <summary>
        /// ActionResult to Detele a product 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public ActionResult DeleteProduct(int id)
        {

            //his action should handle the HTTP POST request for adding products and stocks
            ProductsBusinessLogic pbl = new ProductsBusinessLogic();

            pbl.DeleteProductID(id);

            //Redirect to the index method in the controler 'ProductInventory'
            return RedirectToAction("Index", "ProductInventory");

        }

        /// <summary>
        /// Method to show the view with the form 
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductRegisterView() 
        {
            //Creating objects and adding the the List data collection
            ProductsBusinessLogic pbl = new ProductsBusinessLogic();
            var products = pbl.GetAllProducts();
            var inventories = pbl.GetAllInventory();
            var uniquesId = pbl.GetAllUniqueID();

            var viewModel = new ViewModel
            {
                Products = products,
                Inventories = inventories,
                UniqueIDs = uniquesId
            };

            return View(viewModel);

        }
    }
}