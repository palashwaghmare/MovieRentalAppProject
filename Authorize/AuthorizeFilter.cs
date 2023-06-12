
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieRentalAppProject.Authorize
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string username = context.HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username) || username.ToLower() != "admin")
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
        }
    }
    
    
}
