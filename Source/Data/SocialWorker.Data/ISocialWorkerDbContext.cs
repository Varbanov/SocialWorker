namespace SocialWorker.Data
{
    using SocialWorker.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ISocialWorkerDbContext
    {
        IDbSet<AppUser> Users { get; set; }

        IDbSet<Meal> Meals { get; set; }

        IDbSet<DoctorVisit> DoctorVisits { get; set; }


        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();

        void Dispose();
    }
}
