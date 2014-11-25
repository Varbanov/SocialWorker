using SocialWorker.Common;
using SocialWorker.Data;
using SocialWorker.Web.Controllers;
using SocialWorker.Web.Infrastructure.UserProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialWorker.Web.Areas.Administration.Controllers.Base
{
    [Authorize(Roles = GlobalConstants.AdministrationRoleName)]
    public abstract class BaseAdminController : BaseController
    {
        public BaseAdminController(ISocialWorkerData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }
    }
}