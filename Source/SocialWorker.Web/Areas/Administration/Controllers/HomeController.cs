using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialWorker.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Navigation()
        {
            return View(DateTime.Now);
        }

        [HttpPost]
        public ActionResult Navigation(DateTime datePicker)
        {
            return Content(datePicker.ToString());
        }


    }
}