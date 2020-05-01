using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data.FileManager;

namespace SimpleBlog.Controllers
{
    public class ImageController : Controller
    {
        private readonly IFileManager _fileManager;

        public ImageController(IFileManager fileManager) => 
            _fileManager = fileManager;

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}