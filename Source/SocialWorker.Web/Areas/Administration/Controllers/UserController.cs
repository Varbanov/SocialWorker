using Kendo.Mvc.UI;
using SocialWorker.Data;
using SocialWorker.Web.Areas.Administration.Controllers.Base;
using SocialWorker.Web.Infrastructure.UserProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using SocialWorker.Web.Areas.Administration.ViewModels;

namespace SocialWorker.Web.Areas.Administration.Controllers
{
    public class UserController : BaseAdminController
    {
        public UserController(ISocialWorkerData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }


        // GET: Administration/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var users = this.Data
                .Users
                .All().Join(this.Data.Roles.All(),
                user => user.Roles.FirstOrDefault().RoleId,
                role => role.Id,
                (user, role) =>
                    new UserViewModel()
                    {
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Age = user.Age,
                        PersonalNumber = user.PersonalNumber,
                        Id = user.Id,
                        Role = role.Name
                    }
                ).ToDataSourceResult(request, ModelState);

            return this.Json(users);
        }
    }
}