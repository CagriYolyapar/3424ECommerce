using Project.DAL.Context;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            AppUser ap = new AppUser();
            ap.UserName = "Cagri";
            ap.Password = "123";
            ap.Role = MODEL.Enums.UserRole.Admin;
            ap.IsActive = true;
            ap.Email = "nightwhisper137@gmail.com";
            context.AppUsers.Add(ap);
            context.SaveChanges();
        }
    }
}
