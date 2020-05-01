using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleBlog.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImageAsync(IFormFile image);
    }
}