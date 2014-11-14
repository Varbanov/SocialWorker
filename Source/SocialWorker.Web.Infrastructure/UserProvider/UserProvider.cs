using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace SocialWorker.Web.Infrastructure.UserProvider
{
    public class UserProvider :IUserProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}
