using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.MODEL.LogEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Filters
{
    
    public class ActFilter : FilterAttribute, IActionFilter
    {
        LogRepository lRep;
        public ActFilter()
        {
            lRep = new LogRepository();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SpecialLog(filterContext,true);
        }

        private void SpecialLog(ControllerContext filterContext,bool cikis)
        {
            Log l = new Log();
            if (filterContext.HttpContext.Session["oturum"] != null)
                l.UserName = (filterContext.HttpContext.Session["oturum"] as AppUser).UserName;
            else l.UserName = "Anonim kullanıcı";
            
            if (cikis)
            {
                l.Information = "Veri Action'dan cıkıs yapıldıktan sonra olusturulmustur";
              l.ActionName= (filterContext as ActionExecutedContext).ActionDescriptor.ActionName;
                l.ControllerName = (filterContext as ActionExecutedContext).ActionDescriptor.ControllerDescriptor.ControllerName;
            }
            else
            {
                l.Information = "Veri Action calısmadan önce olusturulmustur";
                l.ActionName = (filterContext as ActionExecutingContext).ActionDescriptor.ActionName;
                l.ControllerName = (filterContext as ActionExecutingContext).ActionDescriptor.ControllerDescriptor.ControllerName;
            }
            
            lRep.Add(l);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SpecialLog(filterContext, false);
        }
    }
}