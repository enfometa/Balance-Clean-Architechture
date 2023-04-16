using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace Balance.Api.Helpers
{
    public class UserAuthHelper
    {
        public static int? GetUserId(HttpContext httpContext)
        {
            int? userId = null;
            var userContext = httpContext.User;
            if (userContext != null)
            {
                userId = int.Parse(userContext.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value);
            }
            return userId;
        }

        public static string? GetUsername(HttpContext httpContext)
        {
            string? username = null;
            var userContext = httpContext.User;
            if (userContext != null)
            {
                username = userContext.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;
            }
            return username;
        }
    }
}
