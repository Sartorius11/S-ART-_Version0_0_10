using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace S_ART__Version0_0_1.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute
    , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated == false)
            {
                //AQUI DENTRO, NO NOS GUSTA QUE NO SE HAYA
                //AUTENTIFICADO Y NOS LO LLEVAMOS A Login
                RouteValueDictionary rutaLogin =
                    new RouteValueDictionary
                    (
                        new { controller = "Managed", action = "Login" }
                    );
                //REDIRECCIONAMOS
                context.Result =
                    new RedirectToRouteResult(rutaLogin);
            }
        }
    }

}
