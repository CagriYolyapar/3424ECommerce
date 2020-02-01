using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {

        AppUserRepository aurep;

        public AppUserController()
        {
           aurep= new AppUserRepository();
        }
            
        // GET: Admin/AppUser
        public ActionResult Index()
        {
            return View(aurep.GetAll());
        }
        public ActionResult AddAppUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAppUser(AppUser appUser)
        {
            aurep.Add(appUser);
            return RedirectToAction("UserList", "User");
        }
    }
}