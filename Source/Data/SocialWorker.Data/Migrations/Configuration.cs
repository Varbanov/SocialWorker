namespace SocialWorker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using SocialWorker.Common;
    using SocialWorker.Data.Common.SeedUtilities;


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
            this.SeedClients(context);



        }

        private void SeedRoles(SocialWorkerDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(GlobalConstants.AdministrationRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.AdministrationRoleName));
            }

            if (!roleManager.RoleExists(GlobalConstants.SocialWorkerRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.SocialWorkerRoleName));
            }

            if (!roleManager.RoleExists(GlobalConstants.UserRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.UserRoleName));
            }

            if (!roleManager.RoleExists(GlobalConstants.DoctorRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.DoctorRoleName));
            }

            if (!roleManager.RoleExists(GlobalConstants.ClientRoleName))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.ClientRoleName));
            }
        }


        private void SeedAdmin(SocialWorkerDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(GlobalConstants.AdministrationRoleName))
            {
                throw new ArgumentNullException("{0} role is missing!", GlobalConstants.AdministrationRoleName);
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
            userManager.AddToRole(user.Id, GlobalConstants.AdministrationRoleName);
        }

        private void SeedClients(SocialWorkerDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(GlobalConstants.ClientRoleName))
            {
                throw new ArgumentNullException("{0} role is missing!", GlobalConstants.ClientRoleName);
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (roleManager.Roles.First(r => r.Name == GlobalConstants.ClientRoleName).Users.Count >= 100)
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

            var rnd = new RandomGenerator();

            for (int i = 0; i < 100; i++)
            {
                var userName = string.Format("client{0}@socialworker.com", i);

                var client = new User
                {
                    UserName = userName,
                    Email = userName,
                    FirstName = "Client " + i,
                    MiddleName = "Client " + i,
                    LastName = "Client " + i,
                    Age = rnd.GetRandomInt(45, 100),
                    PersonalNumber = rnd.GetRandomNumericString(10)
                };

                userManager.Create(client, "client");
                userManager.AddToRole(client.Id, GlobalConstants.ClientRoleName);
            }
        }

    }
}
