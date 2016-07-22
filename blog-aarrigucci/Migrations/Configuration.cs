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
            //the above section will change
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
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
                }, "Password$1");
            }
            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "PostModerator",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "Post",
                    LastName = "Moderator",
                    DisplayName = "Post Moderator"
                }, "Password-1");
            }

            if (!context.Users.Any(u => u.Email == "jtwichell@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jtwichell@coderfoundry.com",
                    Email = "jtwichell@coderfoundry.com",
                    FirstName = "Jason",
                    LastName = "Twichell",
                    DisplayName = "J-Twich"
                }, "Abc&123!");
            }

            if (!context.Users.Any(u => u.Email == "annette_c_a@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "annette_c_a@yahoo.com",
                    Email = "annette_c_a@yahoo.com",
                    FirstName = "Annette",
                    LastName = "Arrigucci",
                    DisplayName = "annette_c_a"
                }, "Abc&123!");
            }
            var userId = userManager.FindByEmail("annette.arrigucci@outlook.com").Id;
            userManager.AddToRole(userId, "Admin");
            //set the user we created as a Moderator

            var userId2 = userManager.FindByEmail("moderator@coderfoundry.com").Id;
            userManager.AddToRole(userId2, "Moderator");

            var userId3 = userManager.FindByEmail("jtwichell@coderfoundry.com").Id;
            userManager.AddToRole(userId3, "Moderator");

            var userId4 = userManager.FindByEmail("annette_c_a@yahoo.com").Id;
            userManager.AddToRole(userId4, "Moderator");
        }

    }
}
