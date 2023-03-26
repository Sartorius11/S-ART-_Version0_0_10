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
        private RepositoryFormularios repos;

        public ManagedController(RepositoryUsuarios repo, RepositoryFormularios repos)
        {
            this.repo = repo;
            this.repos = repos;
        }
       


        public IActionResult perfil()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> perfil(string nombre, string correo, string artista_fav, string pais)
        {
            await this.repos.FomularioUsuario(nombre, correo, artista_fav, pais);
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

        public async Task<IActionResult>LogOut()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn");

        }



    }
}