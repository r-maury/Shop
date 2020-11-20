using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.InMemory {
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository() {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

        }

        public void Commit() {
            cache[className] = items;
        }

        public void Insert(T t) {
            items.Add(t);
        }

        public void Update(T product) {
            T toUpdate = items.Find(p => p.Id == product.Id);

            if(toUpdate != null) {
                toUpdate = product;
            } else {
                throw new Exception($"{className} Not found");
            }
        }

        public T FindById(int id) {
            T p = items.Find(p1 => p1.Id == id);
            if(p != null) {
                return p;
            } else {
                throw new Exception($"{className} Not found");
            }
        }

        public IQueryable<T> Collection() {
            return items.AsQueryable();
        }

        public void Delete(int id) {
            T toDelete = items.Find(p => p.Id == id);
            if(toDelete != null) {
                items.Remove(toDelete);
            } else {
                throw new Exception($"{className} Not found");
            }
        }
    }
}
