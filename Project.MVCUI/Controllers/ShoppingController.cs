using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.MODEL.Entities;
using Project.MVCUI.Filters;
using Project.MVCUI.Models;
using Project.VIEWMODEL.ViewModels;

namespace Project.MVCUI.Controllers
{
    [ActFilter]
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
            pavm.PagedProduct = pRep.GetActives().ToPagedList(page ?? 1, 9);
            pavm.Categories = cRep.GetActives();
            return View(pavm);
        }


        public ActionResult AddToCart(int id)
        {
            AppUser user;
            if (Session["member"] == null)
                TempData["anonimKullanici"] = "Anonim kullanıcı";


            else
            {
                user = Session["member"] as AppUser;
            }

            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

            Product eklenecekUrun = pRep.Find(id);

            CartItem ci = new CartItem()
            {
                ID = eklenecekUrun.ID,
                Name = eklenecekUrun.ProductName,
                Price = eklenecekUrun.UnitPrice,
                ImagePath = eklenecekUrun.ImagePath,

            };
            c.SepeteEkle(ci);

            Session["scart"] = c;
            return RedirectToAction("ShoppingList");


            
        }


    }
}