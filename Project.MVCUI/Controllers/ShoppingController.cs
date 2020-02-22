using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.BLL.DesignPatterns.SingletonPattern;

using Project.VIEWMODEL.ViewModels;

namespace Project.MVCUI.Controllers
{
    public class ShoppingController : Controller
    {
        ProductRepository pRep;
        CategoryRepository cRep;

        public ShoppingController()
        {
            pRep = new ProductRepository();
            cRep = new CategoryRepository();
        }
      
        // GET: Shopping
        public ActionResult ShoppingList(int? page)
        {
            PAVM pavm = new PAVM();
            pavm.PagedProduct = pRep.GetActives().ToPagedList(page??1,9);
            pavm.Categories = cRep.GetActives();
            return View(pavm);
        }
    }
}