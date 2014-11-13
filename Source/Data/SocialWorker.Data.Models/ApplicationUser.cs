using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialWorker.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Data
{
    public class AppUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public AppUser()
        {
            //prevent Usermanager.CreateAsync from trowing exception
            this.CreatedOn = DateTime.Now;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        //public string PersonalNumber { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public DateTime CreatedOn {get; set;}

        public bool PreserveCreatedOn {get; set;}

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
       
    }
}
