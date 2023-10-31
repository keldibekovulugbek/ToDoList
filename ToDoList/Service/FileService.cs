namespace ToDoList.Service
{
    public class FileService : IFileService
    {
        private readonly string _folderName = "images";
        private readonly string _basePath;

        public FileService(IWebHostEnvironment webHost)
        {
            _basePath = webHost.WebRootPath;
      
        }

        public string FolderName => _folderName;

        public async ValueTask<bool> DeleteAsync(string imagePath)
        {
            var path = Path.Combine(_basePath, imagePath);

            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);

            return true;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async ValueTask<string> SaveImageAsync(IFormFile image)
        {
            var folderPath = Path.Combine(_basePath, _folderName);
            
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
            if (!Directory.Exists(folderPath))
            { 
                Directory.CreateDirectory(folderPath);
            }


            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            var imagePath =Path.Combine(folderPath, imageName);
            
            var stream = File.Create(imagePath);
            await image.CopyToAsync(stream);
            stream.Close();

            return Path.Combine(_folderName, imageName);
            
        }


    }
}
