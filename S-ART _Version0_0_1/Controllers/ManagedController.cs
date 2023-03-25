using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using S_ART__Version0_0_1.Models;
using S_ART__Version0_0_1.Repositories;

namespace S_ART__Version0_0_1.Controllers
{
    public class ManagedController : Controller
    {

        private RepositoryUsuarios repo;

        public ManagedController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> LogIn
            (string username, string password)
        {
            Usuario usuario =
                await this.repo.LogInUser(username,password);
            if (usuario != null)
            {
                ClaimsIdentity identity =new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name, ClaimTypes.Role);
                Claim claimName = new Claim(ClaimTypes.Name, username);
                identity.AddClaim(claimName);

                Claim claimId = new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString());
                identity.AddClaim(claimId);

               

                ClaimsPrincipal userPrincipal =
                    new ClaimsPrincipal(identity);


                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }


    }
}