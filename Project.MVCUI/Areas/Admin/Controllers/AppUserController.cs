using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.COMMON.PasswordEncryption;
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
            aurep = new AppUserRepository();
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
            appUser.Password = PasswordEncryption.EncryptPassword(appUser.Password,3);
            aurep.Add(appUser);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAppUser(int id)
        {
            return View(aurep.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateAppUser(AppUser appUser)
        {
            aurep.Update(appUser);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAppUser(int id)
        {
            aurep.Delete(aurep.Find(id));
            return RedirectToAction("Index");
        }
    }
}