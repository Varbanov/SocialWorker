namespace SocialWorker.Web.Controllers
{
    using System.Web.Mvc;

    using SocialWorker.Web.ViewModels;
    using System.Data.Entity;
    using SocialWorker.Data.Models;
    using SocialWorker.Data;
    using Microsoft.AspNet.Identity;
using SocialWorker.Web.Infrastructure.UserProvider;

    public abstract class BaseController
    {
        private string currentUserId;

        public BaseController(ISocialWorkerData data, IUserProvider userProvider )
        {
            this.Data = data;
            this.currentUserId = userProvider.GetUserId();
        }

        protected ISocialWorkerData Data { get; set; }

        protected string CurrentUserId { get; set; }



    }
}