using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Taxes.Models;

namespace Taxes.Classes
{
    public class Utilities : IDisposable
    {
        private static readonly ApplicationDbContext UserContext = new ApplicationDbContext();

        public static void CheckRole(string roleName)
        {
            //user management
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(UserContext));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CreateUser(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(UserContext));

            var aspUser=new ApplicationUser()
            {
                Email = email,
                UserName = email
            };

            userManager.Create(aspUser, email);
            userManager.AddToRole(aspUser.Id, roleName);
        }

        public void Dispose()
        {
            UserContext.Dispose();
        }
    }
}