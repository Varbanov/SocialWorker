namespace SocialWorker.Data
{
    using SocialWorker.Data.Common.Repository;
    using SocialWorker.Data.Models;

    public interface ISocialWorkerData
    {
        ISocialWorkerDbContext Context { get; }

        IDeletableEntityRepository<Meal> Meals { get; }

        IDeletableEntityRepository<DoctorVisit> DoctorVisits { get; }

        IDeletableEntityRepository<Visit> Visits { get; }

        IDeletableEntityRepository<Medicine> Medicine { get; }




        IRepository<User> Users { get; }

        int SaveChanges();

    }
}
