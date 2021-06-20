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
    public class ProductController : Controller
    {
        
        // GET: Admin/Product
        public ActionResult Index()
        {
            var iplCate = new ProductModel();
            var model = iplCate.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thành công");
                }
            }
            return View("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new ProductDao();
            var content = dao.GetByID(id);

            SetViewBag(content.IDCategory);
            return View(content);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);

                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập sản phẩm thành công");
                }
            }
            return View("Index");
        }

        public void SetViewBag(int? id = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDCategory = new SelectList(dao.ListAll(), "IDCategory", "Name", id);
        }

        public ActionResult Detail(int id)
        {
            if(id !=null)
            {
                var dao = new ProductDao();
                var content = dao.GetByID(id);
                var proinfo = new Product
                {
                    IDProduct = content.IDProduct,
                    Name = content.Name,
                    UnitCost = content.UnitCost,
                    Quantity = content.Quantity,
                    Image = content.Image,
                    Description = content.Description,
                    Status = content.Status,
                    IDCategory=content.IDCategory
                    
                };
                return View(proinfo);
            }    
            
            return View("Index");
        }


        [HttpDelete]
        public ActionResult Delete(int idproduct)
        {
            new ProductDao().Delete(idproduct);
            return RedirectToAction("Index");
        }
    }
}