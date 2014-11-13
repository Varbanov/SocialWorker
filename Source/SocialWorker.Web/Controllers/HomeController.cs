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

namespace SocialWorker.Web.Controllers
{
    public class HomeController : Controller
    {
        private SocialWorkerDbContext data;

        private IDeletableEntityRepository<Meal> mealRepo;

        public HomeController(SocialWorkerDbContext context)
        {
            this.data = context;
            mealRepo = new DeletableEntityRepository<Meal>(this.data);


        }

        public ActionResult Index()
        {
            mealRepo.Delete(4);
            var meal5 = mealRepo.GetById(5);

            //mealRepo.ActualDelete(meal5);
            data.SaveChanges();



            var meals = this.mealRepo.AllWithDeleted()
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