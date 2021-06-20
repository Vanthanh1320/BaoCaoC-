using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var iplCate = new CategoryModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.Create(collection.Name, collection.Description);
                    if(res > 0)

                    return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới thành công");
                    }    
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new CategoryDao();
            var content = dao.GetByID(id);

            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(category);

                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập danh mục thành công");
                }
            }
            return View("Index");
        }


        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
