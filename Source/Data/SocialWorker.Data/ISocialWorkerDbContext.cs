namespace SocialWorker.Data
{
    using SocialWorker.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ISocialWorkerDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Meal> Meals { get; set; }

        IDbSet<DoctorVisit> DoctorVisits { get; set; }

        IDbSet<Visit> Visits { get; set; }

        IDbSet<Medicine> Medicines { get; set; }



        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();

        void Dispose();
    }
}
