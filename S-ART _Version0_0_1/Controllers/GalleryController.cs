using Microsoft.AspNetCore.Mvc;

namespace S_ART__Version0_0_1.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImagenGrande()
        {
            return View();
        }

    }
}
