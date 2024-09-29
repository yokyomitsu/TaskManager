using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Core.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _items = new();

        public IEnumerable<T> GetAll() => _items;

        public void Add(T entity) => _items.Add(entity);

        public void Remove(T entity) => _items.Remove(entity);

        public void Update(T entity)
        {
            // Find the existing entity in the list
            var existingEntity = _items.FirstOrDefault(item => item.Equals(entity));
            
            if (existingEntity != null)
            {
                // Replace the existing entity with the updated one
                var index = _items.IndexOf(existingEntity);
                _items[index] = entity;
            }
        }
    }
}
