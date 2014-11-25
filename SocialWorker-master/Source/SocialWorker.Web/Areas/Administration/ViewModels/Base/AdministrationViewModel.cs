using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SocialWorker.Web.Areas.Administration.ViewModels.Base
{
    public class AdministrationViewModel
    {
        [Display(Name = "Добавен на")]
        DateTime CreatedOn { get; set; }

        [Display(Name = "Променен на")]
        DateTime? ModifiedOn { get; set; }
    }
}