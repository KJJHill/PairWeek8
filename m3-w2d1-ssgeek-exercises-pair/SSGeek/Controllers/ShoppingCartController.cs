using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.Models;
using SSGeek.DAL;
using System.Web.SessionState;

namespace SSGeek.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            IProductDAL dal = new ProductSqlDAL();

            //List<Product> result = dal.GetProducts();

            return View(dal.GetProducts());
        }

        public ActionResult ProductDetails(int id)
        {

            IProductDAL dal = new ProductSqlDAL();

            Product product = dal.GetProduct(id);

            ViewBag.Name = product.Name;
            ViewBag.ProductIdQuantity = product.ProductId + "Quantity";

            if(Session[product.ProductId + "Quantity"] == null)
            {
                Session[product.ProductId + "Quantity"] = 0;
            }

            return View(product);
        }

        public ActionResult ShoppingCartResult()
        {

            List<Product> result = new List<Product>();

            if(Request.Params["Quantity"] != null)
            {
                string productQuantityTemp = Request.Params["ProductId"] + "Quantity";
                Session[productQuantityTemp] = int.Parse(Session[productQuantityTemp].ToString()) + int.Parse(Request.Params["Quantity"]);
            }

            for (int i = 1; i <= 4; i++)
            {
                if(Session[i + "Quantity"] != null && int.Parse(Session[i+"Quantity"].ToString()) > 0)
                {
                    IProductDAL dal = new ProductSqlDAL();

                    Product product = dal.GetProduct(i);

                    product.Quantity = int.Parse(Session[i + "Quantity"].ToString());
                    result.Add(product);
                }
            }
                
            return View(result);
        }
    }
}