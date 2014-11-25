using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorker.Web.Infrastructure.UserProvider
{
    public interface IUserProvider
    {
        string GetUserId();
    }
}
