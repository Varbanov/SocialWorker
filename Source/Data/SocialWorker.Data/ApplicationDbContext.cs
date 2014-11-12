using Microsoft.AspNet.Identity.EntityFramework;
using SocialWorker.Data.Common.Models;
using SocialWorker.Data.Migrations;
using SocialWorker.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace SocialWorker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Meal> Meals { get; set; }



        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            //this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        //private void ApplyDeletableEntityRules()
        //{
        //    // Approach via @julielerman: http://bit.ly/123661P
        //    foreach (
        //        var entry in
        //            this.ChangeTracker.Entries()
        //                .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
        //    {
        //        var entity = (IDeletableEntity)entry.Entity;

        //        entity.DeletedOn = DateTime.Now;
        //        entity.IsDeleted = true;
        //        entry.State = EntityState.Modified;
        //    }
        //}

    }
}
