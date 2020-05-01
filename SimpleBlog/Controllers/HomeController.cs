using Microsoft.AspNetCore.Mvc;
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
            var posts = _postRepository.GetAll();

            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _postRepository.Get(id);

            return View(post);
        }
    }
}