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
           if( !KullaniciKontrol(item, out ActionResult sonuc))
           {
                return sonuc;
           }
            else
            {
                arep.Add(item);
                return sonuc;
            }

           
        }

        private bool KullaniciKontrol(AppUser item, out ActionResult sonuc)
        {

            if (arep.Any(x => x.UserName == item.UserName))
            {
                TempData["kullaniciVar"] = "Bu kullanıcı ismi daha önce alınmıştır.";
                sonuc = RedirectToAction("Register");
                return false;
            }

            if (arep.Any(x => x.Email == item.Email))
            {
                sonuc= RedirectToAction("Register");
                TempData["kullaniciVar"] = "Bu email adresine ait bir kullanıcı bulunmaktadır.";
                return false;
            }
            sonuc= RedirectToAction("Index");
            return true;

        }
    }
}