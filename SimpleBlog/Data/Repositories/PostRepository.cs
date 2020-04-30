using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models;

namespace SimpleBlog.Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly BlogDbContext _blogDb;

        public PostRepository(BlogDbContext blogDb) => 
            _blogDb = blogDb;

        public Post Get(int id) => _blogDb.Posts.FirstOrDefault(_ => _.Id == id);

        public List<Post> GetAll() => _blogDb.Posts.ToList();

        public void Add(Post post) => _blogDb.Posts.Add(post);

        public void Update(Post post) => _blogDb.Posts.Update(post);

        public void Remove(int id) => _blogDb.Posts.Remove(Get(id));

        public async Task<bool> SaveChangesAsync() => await _blogDb.SaveChangesAsync() > 0;
    }
}