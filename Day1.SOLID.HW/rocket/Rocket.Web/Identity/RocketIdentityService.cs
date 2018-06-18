using System;
using IdentityServer3.AspNetIdentity;
using Microsoft.AspNet.Identity;
using Rocket.BL.Common.Models.User;

namespace Rocket.Web.Identity
{
    public class RocketIdentityService : AspNetIdentityUserService<User, string>
    {
        public RocketIdentityService(UserManager<User, string> userManager, Func<string, string> parseSubject = null) 
            : base(userManager, parseSubject)
        {
        }
    }
}