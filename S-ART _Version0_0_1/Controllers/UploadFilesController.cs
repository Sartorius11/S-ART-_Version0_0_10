using Microsoft.AspNetCore.Mvc;
using S_ART__Version0_0_1.Helpers;

namespace S_ART__Version0_0_1.Controllers
{
    public class UploadFilesController : Controller
    {
      
        private HelperPathProvider helperPathProvider;
        private Repositories.RepositoryFormularios  repo;


       
        public UploadFilesController( HelperPathProvider helperPathProvider, Repositories.RepositoryFormularios repo)
        {
            this.helperPathProvider = helperPathProvider;
            this.repo = repo;
        }


        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFichero
            (IFormFile fichero, string nombre, int id)
        {
            string fileName = fichero.FileName;

            string path = this.helperPathProvider.MapPath(fileName);
            
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            await this.repo.subirFichero(fileName, nombre, id);


            ViewData["MENSAJE"] = "Fichero subido ";
            return View();
        }

    }
}
