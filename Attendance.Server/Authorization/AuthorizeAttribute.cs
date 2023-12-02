using Attendance.Shared.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Attendance.Server.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymouseAttribute>().Any();
        if (allowAnonymous) return;

        var user = (User)context.HttpContext.Items["User"]!;
        if (user is null)
        {
            context.Result = new JsonResult(new
            { message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}