using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.InMemory {
    public class ProductRepository {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository() {
            products = cache["products"] as List<Product>;
            if(products == null) {
                products = new List<Product>();
            }
        }

        public void Commit() {
            cache["products"] = products;
        }

        public void Insert(Product p) {
            products.Add(p);
        }

        public void Update(Product product) {
            Product toUpdate = products.Find(p => p.Id == product.Id);

            if(toUpdate != null) {
                toUpdate = product;
            } else {
                throw new Exception("Product Not Found");
            }
        }

        public Product FindById(int id) {
            Product p = products.Find(p1 => p1.Id == id);
            if(p != null) {
                return p;
            } else {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection() {
            return products.AsQueryable();
        }

        public void Delete(int id) {
            Product toDelete = products.Find(p => p.Id == id);
            if(toDelete != null) {
                products.Remove(toDelete);
            } else {
                throw new Exception("Product not Found");
            }
        }

    }
}
