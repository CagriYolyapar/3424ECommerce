using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{

    public class EntityAttributeController : Controller
    {

        EntityAttributeRepository eaRep;

        public EntityAttributeController()
        {
            eaRep = new EntityAttributeRepository();
        }
        // GET: Admin/EntityAttribute
        public ActionResult EntityAttributeList()
        {
            return View(eaRep.GetAll());
        }

        public ActionResult AddEntityAttribute()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddEntityAttribute(EntityAttribute item)
        {
            eaRep.Add(item);
            return RedirectToAction("EntityAttributeList");
        }

        public ActionResult DeleteEntityAttribute(int id)
        {
            eaRep.Delete(eaRep.Find(id));
            return RedirectToAction("EntityAttributeList");
        }

        public ActionResult UpdateEntityAttribute(int id)
        {
            return View(eaRep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateEntityAttribute(EntityAttribute item)
        {
            eaRep.Update(item);
            return RedirectToAction("EntityAttributeList");
        }
    }
}