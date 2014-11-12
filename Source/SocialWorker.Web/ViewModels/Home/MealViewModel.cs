using SocialWorker.Data.Models;
using SocialWorker.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorker.Web.ViewModels.Home
{
    public class MealViewModel : IMapFrom<Meal>
    {
        public string Description { get; set; }
       
    }
}