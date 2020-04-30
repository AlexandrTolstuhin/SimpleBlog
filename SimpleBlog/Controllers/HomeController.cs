using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> _postRepository;

        public HomeController(IRepository<Post> postRepository) => 
            _postRepository = postRepository;

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
            _postRepository.Add(post);

            if (await _postRepository.SaveChangesAsync())
                return RedirectToAction(nameof(Index));
            return View(post);
        }
    }
}