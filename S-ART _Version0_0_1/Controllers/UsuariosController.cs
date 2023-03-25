using Microsoft.AspNetCore.Mvc;
using S_ART__Version0_0_1.Filters;
using S_ART__Version0_0_1.Models;
using S_ART__Version0_0_1.Repositories;

namespace S_ART__Version0_0_1.Controllers
{
    public class UsuariosController : Controller
    {
        

        private RepositoryUsuarios repo;

        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register
            (string nombre, string email, string password)
        {
            await this.repo.RegisterUser(nombre, email, password);
            ViewData["MENSAJE"] = "Usuario registrado correctamente";
            return View();
        }

        
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]

        public async  Task<IActionResult> LogIn(string email, string password)
        {
            Usuario user = await this.repo.LogInUser(email, password);
            if (user == null)
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }

}
