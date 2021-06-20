using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        // GET: Admin/User
        public ActionResult Index()
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model);
        }

        //public ActionResult Index(string search)
        //{
        //    var user = new UserDao();
        //    var model = user.ListSearch(search);
        //    ViewBag.searchString = search;
        //    return View(model);
        //}


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}