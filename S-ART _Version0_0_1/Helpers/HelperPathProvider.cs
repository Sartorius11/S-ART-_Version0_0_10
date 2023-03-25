namespace S_ART__Version0_0_1.Helpers
{
    

    public class HelperPathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName)
        {
            string folder = "Uploads";
            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, folder, fileName);
            return path;
        }
    }

}
