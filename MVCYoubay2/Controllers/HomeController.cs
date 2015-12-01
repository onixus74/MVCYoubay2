using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCYoubay2.Models;

namespace MVCYoubay2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var Products = db.t_product.ToList();
            return View(Products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListProductByCategory(string Category)
        {
            var ProductList = db.t_category.Include("Products")
                .Single(g => g.categoryName == Category);

            return View(ProductList);
        }
    }
}