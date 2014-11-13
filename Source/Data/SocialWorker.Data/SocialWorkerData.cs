using SocialWorker.Data.Common.Models;
using SocialWorker.Data.Common.Repository;
using SocialWorker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data
{
    public class SocialWorkerData : ISocialWorkerData, IDisposable
    {
        private readonly ISocialWorkerDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public SocialWorkerData(ISocialWorkerDbContext context)
        {
            this.context = context;
        }

        public ISocialWorkerDbContext Context
        {
            get { return this.context; }
        }

        public IDeletableEntityRepository<Meal> Meals
        {
            get { return this.GetDeletableEntityRepository<Meal>(); }
        }

        public IRepository<AppUser> Users
        {
            get { return this.GetRepository<AppUser>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }





        public IDeletableEntityRepository<DoctorVisit> DoctorVisits
        {
            get { return this.GetDeletableEntityRepository<DoctorVisit>(); }
        }
    }
}
