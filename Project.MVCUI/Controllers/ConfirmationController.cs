using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class ConfirmationController : Controller
    {
        readonly AppUserRepository userRepository;

        public ConfirmationController()
        {
            userRepository = new AppUserRepository();
        }

        public ActionResult ConfirmEMail(Guid activationCode)
        {
            AppUser user = userRepository.Default(x => x.ActivationCode.Equals(activationCode));
            if (user != null)
            {
                user.IsActive = true;
                userRepository.Update(user);
                ViewBag.Control = "kullanıcınız aktive edilmiştir";
            }
            else
            {
                ViewBag.Control = "bir sorun oluştu";
            }
            return View();
        }
    }
}