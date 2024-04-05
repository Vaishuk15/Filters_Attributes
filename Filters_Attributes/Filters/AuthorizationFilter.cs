using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters_Attributes.ActionFilters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Perform your authorization logic here
            bool isAuthorized = AuthorizationLogic(context.HttpContext.User); // Implement your own authorization logic

            if (!isAuthorized)
            {
                context.Result = new UnauthorizedObjectResult("UnAuthorized"); 
            }
        }

        private bool AuthorizationLogic(System.Security.Claims.ClaimsPrincipal user)
        {
            // Implement your custom authorization logic here
            // For example, check user roles, permissions, etc.
            // This is just a placeholder implementation

            //return user.Identity.IsAuthenticated;
            return true;
        }
    }
}
