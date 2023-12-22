using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PetShop.Client.CustomAuthorize
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the action or controller has the [Authorize] attribute
            var customAuthorizeAttribute = context.ActionDescriptor.EndpointMetadata
                .OfType<CustomAuthorizeAttribute>()
                .FirstOrDefault();

            if (customAuthorizeAttribute != null)
            {
                // Check if the user is authenticated
                if (!context.HttpContext.User.Identity!.IsAuthenticated)
                {
                    context.Result = new RedirectToActionResult("Index", "Home", new { message = "Unauthorized access. Please log in." });
                    return;
                }

                // Check if the user has the required roles
                var requiredRoles = customAuthorizeAttribute.Roles;
                var userRoles = context.HttpContext.User.FindAll(ClaimTypes.Role).Select(c => c.Value);

                if (!userRoles.Any(role => requiredRoles.Contains(role, StringComparer.OrdinalIgnoreCase)))
                {
                    // User doesn't have the required roles
                    context.Result = new ContentResult
                    {
                        Content = "Unauthorized access. Insufficient role permissions.",
                        StatusCode = 403 // Forbidden status code
                    };
                }
            }
        }
    }
}
