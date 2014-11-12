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

namespace SocialWorker.Web.Controllers
{
    public class HomeController : Controller
    {
        private DbContext data;

        public HomeController(DbContext context)
        {
            this.data = context;
        }

        public ActionResult Index()
        {
            var meals = (this.data as ApplicationDbContext).Meals
                .Project().To<MealViewModel>();


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