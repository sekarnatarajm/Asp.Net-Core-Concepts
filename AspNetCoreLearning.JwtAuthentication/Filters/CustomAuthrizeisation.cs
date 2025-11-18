using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreLearning.JwtAuthentication.Filters
{
    public class CustomAuthrizeisation : Attribute, IAuthorizationFilter
    {
        private string? userRole { get; set; }
        public CustomAuthrizeisation() { }
        public CustomAuthrizeisation(string role)
        {
            userRole = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(userRole))
            {
                string roleName = "Role";
                var user = context.HttpContext.User;
                if (user.Identity.IsAuthenticated)
                {
                    var isValidUser = user.HasClaim(f => f.Type.Equals(roleName, StringComparison.OrdinalIgnoreCase)
                                    && f.Value.Equals(userRole, StringComparison.OrdinalIgnoreCase));

                    if (!isValidUser)
                    {
                        context.Result = new ForbidResult();
                        return;
                    }
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
        }
    }
}
