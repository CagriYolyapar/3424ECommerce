using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        AppUserRepository arep;

        public HomeController()
        {
            arep = new AppUserRepository();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser item)
        {
            return KullaniciKontrol(item);

           
         
        }

        private ActionResult KullaniciKontrol(AppUser item)
        {
            if (arep.Any(x => x.UserName == item.UserName))
            {
                TempData["kullaniciVar"] = "Bu kullanızı ismi daha önce alınmıstır";
               return RedirectToAction("Register");
              
            }
            if (arep.Any(x => x.Email == item.Email))
            {
                
                TempData["kullaniciVar"] = "Bu email adresine ait bir kullanıcı bulunmaktadır";


               return RedirectToAction("Register");
               

            }
            arep.Add(item);
            return  RedirectToAction("Index");
         
        }
    }
}