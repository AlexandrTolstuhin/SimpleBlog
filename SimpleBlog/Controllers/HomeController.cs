using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> _postRepository;

        public HomeController(IRepository<Post> postRepository) =>
            _postRepository = postRepository;

        public IActionResult Index()
        {
            var posts = _postRepository.GetAll();

            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _postRepository.Get(id);

            Test();

            return View(post);
        }

        void Test()
        {
            RedirectToPage("/home/index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var post = id != null ? _postRepository.Get(id.Value) : new Post();

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
                _postRepository.Update(post);
            else 
                _postRepository.Add(post);

            if (await _postRepository.SaveChangesAsync())
                return RedirectToAction(nameof(Index), "Home");
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _postRepository.Remove(id);
            await _postRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}