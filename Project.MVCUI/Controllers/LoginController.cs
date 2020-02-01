using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        AppUserRepository aRep;
        public LoginController()
        {
            aRep = new AppUserRepository();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser item)
        {

            if (aRep.Any(x=> x.UserName== item.UserName && x.Password==item.Password))
            {
                AppUser user = aRep.Default(x => x.UserName == item.UserName && x.Password == item.Password);
                if (user.Role==MODEL.Enums.UserRole.Admin)
                {
                    Session["Admin"] = user;
                    return RedirectToAction("CategoryList", "Category");
                }
                else if (user.Role == MODEL.Enums.UserRole.Member)
                {
                    Session["Member"] = user;
                    return RedirectToAction("ShoppingList", "Shopping");
                }
                else if (user.Role == MODEL.Enums.UserRole.Visitor)
                {
                    Session["Visitor"] = user;
                    return RedirectToAction("ShoppingList", "Shopping");
                }
            }

            ViewBag.KullaniciYok = "Kullanıcı Bulunamadı";
            return View();
        }
    }
}