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
    public class ShipperController : Controller
    {
        ShipperRepository sRep;
        public ShipperController()
        {
            sRep = new ShipperRepository();
        }
        // GET: Admin/Shipper
        public ActionResult ShipperList()
        {
            return View(sRep.GetAll());
        }

        public ActionResult AddShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipper( Shipper item)
        {
            sRep.Add(item);
            return RedirectToAction("ShipperList");
        }

        public ActionResult DeleteShipper(int id)
        {
            sRep.Delete(sRep.Find(id));
            return RedirectToAction("ShipperList");
        }

        public ActionResult UpdateShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateShipper(Shipper item)
        {
            sRep.Update(item);
            return RedirectToAction("ShipperList");
        }

    }
}