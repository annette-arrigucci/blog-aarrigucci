using blog_aarrigucci.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace blog_aarrigucci.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<blog_aarrigucci.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            var userManager = new UserManager<ApplicationUser>(
           new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "annette.arrigucci@outlook.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "aarrigucci",
                    Email = "annette.arrigucci@outlook.com",
                    FirstName = "Annette",
                    LastName = "Arrigucci",
                    DisplayName = "Annette Arrigucci"
                }, "password");
            }
            var userId = userManager.FindByEmail("annette.arrigucci@outlook.com").Id;
            userManager.AddToRole(userId, "Admin");
        }

    }
}
