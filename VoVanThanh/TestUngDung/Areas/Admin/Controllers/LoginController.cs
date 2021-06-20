using ModelEF;
using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                int result = dao.Login(model.UserName,Common.EncryptMD5(model.Password));
                if(result == 1)
                {
                    Session.Add(Constants.USER_SESSION, model);
                    return RedirectToAction("Index","User");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công ");
                }
            }
            return View("Index");
        }
    }
}