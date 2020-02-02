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
        AppUserDetailRepository auRep;
        public AppUserDetailController()
        {
            auRep = new AppUserDetailRepository();
        }
        // GET: Admin/AppUserDetail
        public ActionResult UserDetailList()
        {
            return View(auRep.GetAll());
        }
        public ActionResult UserDetailByID(int id)
        {
            return View(auRep.Find(id));
        }
        public ActionResult AddUserDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUserDetail(AppUserDetail userDetail)
        {
            auRep.Add(userDetail);
            return RedirectToAction("UserDetailList");
        }
        public ActionResult UpdateUserDetail(int id)
        {
            return View(auRep.Find(id));
        }
        [HttpPost]
        public ActionResult UpdateUserDetail(AppUserDetail userDetail)
        {
            auRep.Update(userDetail);
            return RedirectToAction("UserDetailList");
        }
        public ActionResult DeleteUserDetail(int id)
        {
            auRep.Delete(auRep.Find(id));
            return RedirectToAction("UserDetailList");
        }
    }
}