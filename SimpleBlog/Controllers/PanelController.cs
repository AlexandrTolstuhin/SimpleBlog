using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    [Authorize(Roles = "admin")]
    public class PanelController : Controller
    {
        private readonly IRepository<Post> _postRepository;

        public PanelController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAll();

            return View(posts);
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
                return RedirectToAction(nameof(Index));
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _postRepository.Remove(id);
            await _postRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}