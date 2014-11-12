using SocialWorker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SocialWorker.Web.ViewModels.Home; 

namespace SocialWorker.Web.Controllers
{
    public class HomeController : Controller
    {
        private List<Meal> meals = new List<Meal>()
        {
            new Meal() { Description="meal 1"},
            new Meal() { Description="meal 2"},
            new Meal() { Description="meal 3"},
        };



        public ActionResult Index()
        {
            var meals = this.meals.AsQueryable()
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