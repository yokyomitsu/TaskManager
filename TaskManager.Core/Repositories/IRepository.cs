// IRepository.cs
using System.Collections.Generic;

namespace TaskManager.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
