using SocialWorker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SocialWorker.Web.ViewModels.Home;
using System.Data.Entity;
using SocialWorker.Data;
using SocialWorker.Data.Common.Repository;
using Microsoft.AspNet.Identity;
using SocialWorker.Web.Infrastructure.UserProvider;
using SocialWorker.Common;

namespace SocialWorker.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(ISocialWorkerData data, IUserProvider userProvider )
            : base(data, userProvider)
        {
        }

        public ActionResult Index()
        {
            var meals = this.Data.Meals.AllWithDeleted()
                .Project()
                .To<MealViewModel>().ToList();

            var id = this.CurrentUserId;
            var admin = this.IsInRole(id, GlobalConstants.AdministrationRoleName);

            ViewBag.Id = id;
            ViewBag.isAdmin= admin;

            return View(meals);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}