namespace S_ART__Version0_0_1.Helpers
{
    public class HelperUploadFiles
    {
        private HelperPathProvider helperPath;
        public HelperUploadFiles(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            string fileName = file.FileName;

            string path = this.helperPath.MapPath(fileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return path;

        }

       
    }
}
