namespace SocialWorker.Data
{
    using SocialWorker.Data.Common.Repository;
    using SocialWorker.Data.Models;

    public interface ISocialWorkerData
    {
        ISocialWorkerDbContext Context { get; }

        IDeletableEntityRepository<Meal> Meals { get; }

        IDeletableEntityRepository<DoctorVisit> DoctorVisits { get; }

        IRepository<AppUser> Users { get; }

        int SaveChanges();

    }
}
