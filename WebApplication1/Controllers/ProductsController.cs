using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int id, string name, int Quantity)
        {

            var products = Session["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
            bool existId = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    existId = true;
                    products[i].Quantity += Quantity;
                    break;
                }
            }
            if (!existId)
            {
                Product product = new Product()
                {
                    Id = id,
                    Name = name,
                    Quantity = Quantity
                };
                products.Add(product);
            }

            Session["products"] = products;

            return Redirect("~/Products/Get");
        }
        public ActionResult Get()
        {
            var products = Session["products"] as List<Product>;
            ViewBag.Product = products;
            return View("Index");
        }
    }
}