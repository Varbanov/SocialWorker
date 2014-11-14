namespace SocialWorker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<SocialWorkerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SocialWorkerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            this.SeedRoles(context);
            this.SeedAdmin(context);



        }

        private void SeedRoles(SocialWorkerDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("SocialWorker"))
            {
                roleManager.Create(new IdentityRole("SocialWorker"));
            }

            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }

            if (!roleManager.RoleExists("Doctor"))
            {
                roleManager.Create(new IdentityRole("Doctor"));
            }

            if (!roleManager.RoleExists("Client"))
            {
                roleManager.Create(new IdentityRole("Client"));
            }
        }


        private void SeedAdmin(SocialWorkerDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                throw new ArgumentNullException("Admin role is missing!");
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            if (userManager.FindByEmail("admin@socialworker.com") != null)
            {
                return;
            }
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new User { UserName = "admin@socialworker.com", Email = "admin@socialworker.com" };
            userManager.Create(user, "admin");
            userManager.AddToRole(user.Id, "Admin");
        }

    }
}
