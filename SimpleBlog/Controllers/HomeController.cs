using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _blogDb;

        public HomeController(BlogDbContext blogDb)
        {
            _blogDb = blogDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            await _blogDb.Posts.AddAsync(post);
            await _blogDb.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}