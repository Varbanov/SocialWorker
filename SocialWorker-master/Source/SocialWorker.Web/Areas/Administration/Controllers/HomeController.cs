using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SocialWorker.Web.ViewModels.Home;
using SocialWorker.Data;
using SocialWorker.Web.Infrastructure.UserProvider;
using SocialWorker.Web.Areas.Administration.Controllers.Base;

namespace SocialWorker.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseAdminController
    {
        public HomeController(ISocialWorkerData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }


        // GET: Administration/Home
        public ActionResult Navigation()
        {
            var meals = this.Data.Meals.All()
                .Project().To<MealViewModel>().ToList();

            return View(meals);
        }

        [HttpPost]
        public ActionResult Navigation(DateTime datePicker)
        {
            return Content(datePicker.ToString());
        }


    }
}