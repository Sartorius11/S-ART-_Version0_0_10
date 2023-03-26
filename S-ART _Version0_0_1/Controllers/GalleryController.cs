using Microsoft.AspNetCore.Mvc;
using S_ART__Version0_0_1.Helpers;
using S_ART__Version0_0_1.Models;

namespace S_ART__Version0_0_1.Controllers
{
    public class GalleryController : Controller
    {
        private Repositories.RepositoryFormularios repo;

        public GalleryController (Repositories.RepositoryFormularios repo)
        {
            this.repo = repo;
        }
        


        public async Task <IActionResult> ListaDeImagenes()
        {
            List<Galeria> ListaDeImagenes = await this.repo.GetImagenes();
            return View(ListaDeImagenes);
        }

        public async Task <IActionResult> ImagenGrande(int id_Imagen)
        {
            Galeria galeria = await this.repo.GetDetallesImagenes(id_Imagen);
			return View(galeria);
        }

    }
}
