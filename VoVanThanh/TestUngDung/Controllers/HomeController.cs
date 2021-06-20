using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.ListProClock = productDao.ListProduct(1);
            ViewBag.ListProGlasses = productDao.ListProduct(2);
            ViewBag.ListProAccess = productDao.ListProduct(3);

            return View();
        }
    }
}