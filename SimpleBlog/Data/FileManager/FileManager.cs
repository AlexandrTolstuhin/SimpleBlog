using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SimpleBlog.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImageAsync(IFormFile image)
        {
            var savePath = Path.Combine(_imagePath);

            try
            {
                if (!Directory.Exists(savePath))
                    Directory.CreateDirectory(savePath);

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}{mime}";

                await using var stream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create);
                await image.CopyToAsync(stream);

                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }
    }
}