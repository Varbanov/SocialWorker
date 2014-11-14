namespace SocialWorker.Web.Controllers
{
    using System.Web.Mvc;
    using System;
    using System.Linq;

    using SocialWorker.Web.ViewModels;
    using System.Data.Entity;
    using SocialWorker.Data.Models;
    using SocialWorker.Data;
    using Microsoft.AspNet.Identity;
    using SocialWorker.Web.Infrastructure.UserProvider;
    using SocialWorker.Common;

    public abstract class BaseController
    {
        private string currentUserId;

        public BaseController(ISocialWorkerData data, IUserProvider userProvider)
        {
            this.Data = data;
            this.currentUserId = userProvider.GetUserId();
        }

        protected ISocialWorkerData Data { get; set; }

        protected string CurrentUserId { get; set; }

        protected bool IsInRole(string userId, string roleName)
        {
            var user = this.Data.Users.GetById(userId);

            if (user == null)
            {
                return false;
            }

            var roles = ((SocialWorkerDbContext)this.Data.Context)
                .Roles
                .Select(r => new { r.Id, r.Name }).ToList();

            foreach (var role in user.Roles)
            {
                var currentRole = roles.FirstOrDefault(r => r.Id == role.RoleId);
                if (currentRole != null)
                {
                    if (currentRole.Name == roleName)
                    {
                        return true;
                    }
                }

            }

            return false;
        }
    }
}