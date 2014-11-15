using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using SocialWorker.Web.Areas.Administration.ViewModels.Base;
using SocialWorker.Data;
using SocialWorker.Web.Infrastructure.Mapping;
using AutoMapper;

namespace SocialWorker.Web.Areas.Administration.ViewModels
{
    public class UserViewModel : AdministrationViewModel
    {
        [HiddenInput(DisplayValue=false)]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength=2)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(30, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        [Range(0,125)]
        public int? Age { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "Personal Id")]
        public string PersonalNumber { get; set; }

        [StringLength(0, MinimumLength = 20)]
        [Display(Name = "Role")]
        public string Role { get; set; }

       
    }
}