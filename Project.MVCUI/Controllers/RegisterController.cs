using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.COMMON.MailSender;
using Project.COMMON.PasswordEncryption;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class RegisterController : Controller
    {
        readonly AppUserRepository appUserRepository;

        public RegisterController()
        {
            appUserRepository = new AppUserRepository();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult CreateUser(AppUser appUser)
        {
            appUser.Password = PasswordEncryption.EncryptPassword(appUser.Password, 2);
            appUserRepository.Add(appUser);
            string body = "http://localhost:50060/Confirmation/ConfirmEmail?activationCode=" + appUser.ActivationCode.ToString();
            MailSender.Send(receiver: appUser.Email, body: body, subject: "Account Activation");
            return RedirectToAction("Login", "Login");
        }
    }
}