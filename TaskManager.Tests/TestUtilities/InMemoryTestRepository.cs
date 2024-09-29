using System.Collections.Generic;
using TaskManager.Core.Repositories;

namespace TaskManager.Tests.TestUtilities
{
    public class InMemoryTestRepository<T> : IRepository<T>
    {
        private readonly List<T> _items = new();

        public IEnumerable<T> GetAll() => _items;
        
        public void Add(T entity) => _items.Add(entity);
        
        public void Remove(T entity) => _items.Remove(entity);

        // Implement the Update method
        public void Update(T entity)
        {
            // Since we're using an in-memory list, the reference to the entity is already in `_items`.
            // No additional action is needed. We simply need to ensure this method exists to satisfy the interface contract.
        }
    }
}
