using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductAttributeController : Controller
    {
        ProductAttributeRepository paRep;
        public ProductAttributeController()
        {
            paRep = new ProductAttributeRepository();
        }
        // GET: Admin/ProductAttribute
        public ActionResult ProductAttributeList()
        {
            return View(paRep.GetAll());
        }

        public ActionResult ProductAttributeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductAttributeAdd(ProductAttribute item)
        {
            paRep.Add(item);
            return RedirectToAction("ProductAttributeList");
        }

        public ActionResult DeleteProductAttribute(int id)
        {
            paRep.Delete(paRep.Find(id));
            return RedirectToAction("ProductAttributeList");
        }

        public ActionResult UpdateProductAttribute(int id)
        {
            return View(paRep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateProductAttribute(ProductAttribute item)
        {
            paRep.Update(item);
            return RedirectToAction("ProductAttributeList");
        }
    }
}