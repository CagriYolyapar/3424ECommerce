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
   // [AdminAuth]
    public class CategoryController : Controller
    {
        
        // GET: Admin/Category
        CategoryRepository cRep;
        public CategoryController()
        {
            cRep = new CategoryRepository();
        }
        public ActionResult CategoryList()
        {
            return View(cRep.GetAll());
        }
        public ActionResult CategoryByID(int id)
        {
            return View(cRep.Find(id));
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            cRep.Add(category);
            return RedirectToAction("CategoryList");
        }
        public ActionResult UpdateCategory(int id)
        {
            return View(cRep.Find(id));
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cRep.Update(category);
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            cRep.Delete(cRep.Find(id));
            return RedirectToAction("CategoryList");
        }

    }
}