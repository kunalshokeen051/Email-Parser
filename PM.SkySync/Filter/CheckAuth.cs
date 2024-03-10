using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PM.SkySync.Filter
{
    public class CheckAuth : Attribute,IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Session.Keys.Contains("user"))
            {
                context.Result = new RedirectToActionResult("Login","Auth",new {returnUrl = context.HttpContext.Request.Path.Value});
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
