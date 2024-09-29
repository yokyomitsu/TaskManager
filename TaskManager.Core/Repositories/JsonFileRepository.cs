// JsonFileRepository.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TaskManager.Core.Models;

namespace TaskManager.Core.Repositories
{
    public class JsonFileRepository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;
        private List<T> _items;

        public JsonFileRepository(string filePath)
        {
            _filePath = filePath;
            _items = LoadFromFile();
        }

        public IEnumerable<T> GetAll() => _items;

        public void Add(T entity)
        {
            _items.Add(entity);
            SaveToFile();
        }

        public void Remove(T entity)
        {
            _items.Remove(entity);
            SaveToFile();
        }

        public void Update(T entity)
        {
            SaveToFile();
        }

        private List<T> LoadFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
