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
    [AdminAuth]
    public class AppUserDetailController : Controller
    {
        AppUserDetailRepository audRep;
        AppUserRepository auRep;
        public AppUserDetailController()
        {
            audRep = new AppUserDetailRepository();
            auRep = new AppUserRepository();
        }
        // GET: Admin/AppUserDetail
        public ActionResult UserDetailList()
        {
            return View(audRep.GetAll());
        }
        public ActionResult UserDetailByID(int id)
        {
            return View(audRep.Find(id));
        }
        public ActionResult AddUserDetail()
        {
            ViewBag.Kullanicilar = auRep.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddUserDetail(AppUserDetail userDetail, string userID)
        {
            AppUser user = auRep.Find(Convert.ToInt32(userID));
            userDetail.AppUser = user;
            audRep.Add(userDetail);
            return RedirectToAction("UserDetailList");
        }
        public ActionResult UpdateUserDetail(int id)
        {
            ViewBag.Kullanicilar = auRep.GetAll();
            return View(audRep.Find(id));
        }
        [HttpPost]
        public ActionResult UpdateUserDetail(AppUserDetail userDetail, string userID)
        {
            AppUser user = auRep.Find(Convert.ToInt32(userID));
            userDetail.AppUser = user;
            audRep.Update(userDetail);
            return RedirectToAction("UserDetailList");
        }
        public ActionResult DeleteUserDetail(int id)
        {
            audRep.Delete(audRep.Find(id));
            return RedirectToAction("UserDetailList");
        }
    }
}