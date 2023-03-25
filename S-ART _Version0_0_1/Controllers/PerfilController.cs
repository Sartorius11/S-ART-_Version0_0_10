using Microsoft.AspNetCore.Mvc;
using S_ART__Version0_0_1.Filters;

namespace S_ART__Version0_0_1.Controllers
{
    public class PerfilController : Controller
    {
    

        [AuthorizeUsers]
        public IActionResult perfil2()
        {
            return View();
        }
    }
}
