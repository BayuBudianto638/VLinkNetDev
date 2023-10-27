using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MCF_AppService.Services
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UserTypeAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _userType;

        public UserTypeAuthorizeAttribute(string userType)
        {
            _userType = userType;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userType = context.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType == null || userType != _userType.ToString())
            {
                context.Result = new ForbidResult();
            }
        }

    }

}
