using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Data.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T post);
        void Update(T post);
        void Remove(int id);

        Task<bool> SaveChangesAsync();
    }
}