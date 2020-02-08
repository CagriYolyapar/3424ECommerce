using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    //[AdminAuth]
    public class ProductController : Controller
    {
        ProductRepository prep;
        CategoryRepository crep;
        public ProductController()
        {
            prep = new ProductRepository();
            crep = new CategoryRepository();
        }
        // GET: Admin/Product
        public ActionResult ProductList()
        {
            return View(prep.GetAll());
        }
        
        public ActionResult AddProduct()
        {
            ViewBag.Kategoriler = crep.GetAll();
            return View();

        }

        [HttpPost]
        public ActionResult AddProduct(Product item)
        {
            prep.Add(item);
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            prep.Delete(prep.Find(id));

            return RedirectToAction("ProductList");
        }

        public ActionResult UpdateProduct(int id)
        {
            ViewBag.Kategoriler = crep.GetActives();
            return View(prep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product item)
        {
            prep.Update(item);
            return RedirectToAction("ProductList");
        }
    }
}