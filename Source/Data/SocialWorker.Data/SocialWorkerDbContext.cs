using Microsoft.AspNet.Identity.EntityFramework;
using SocialWorker.Data.Common.Models;
using SocialWorker.Data.Migrations;
using SocialWorker.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace SocialWorker.Data
{
    public class SocialWorkerDbContext : IdentityDbContext<AppUser>, ISocialWorkerDbContext
    {
        public SocialWorkerDbContext()
            : this("DefaultConnection")
        {
        }

        public SocialWorkerDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialWorkerDbContext, Configuration>());
        }

        public virtual IDbSet<Meal> Meals { get; set; }



        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static SocialWorkerDbContext Create()
        {
            return new SocialWorkerDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
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






        public IDbSet<DoctorVisit> DoctorVisits { get; set; }
    }
}
