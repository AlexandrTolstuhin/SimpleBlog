using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data.FileManager;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;
using System.Threading.Tasks;

namespace SimpleBlog.Controllers
{
    [Authorize(Roles = "admin")]
    public class PanelController : Controller
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IFileManager _fileManager;

        public PanelController(IRepository<Post> postRepository, IFileManager fileManager)
        {
            _postRepository = postRepository;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAll();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View(new PostViewModel());
            }

            var post = _postRepository.Get(id.Value);

            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = _postRepository.Get(vm.Id) ?? new Post();

            post.Title = vm.Title;
            post.Body = vm.Body;
            if (vm.Image != null)
                post.Image = await _fileManager.SaveImageAsync(vm.Image);

            if (post.Id > 0)
                _postRepository.Update(post);
            else
                _postRepository.Add(post);

            if (await _postRepository.SaveChangesAsync())
                return RedirectToAction(nameof(Index));
            return View(vm);
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