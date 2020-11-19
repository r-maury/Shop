using shop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.InMemory {
    public class ProductCategoryRepository {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> products;

        public ProductCategoryRepository(ObjectCache cache) {
            products = cache["productsCategry"] as List<ProductCategory>;
            if(products == null) {
                products = new List<ProductCategory>();
            }
        }

        public void commit() {
            cache["productsCategry"] = products;
        }

        public void Insert(ProductCategory p) {
            products.Add(p);
        }

        public void Update(ProductCategory product) {
            ProductCategory toUpdate = products.Find(p => p.Id == product.Id);

            if(toUpdate != null) {
                toUpdate = product;
            } else {
                throw new Exception("Category Not Found");
            }
        }

        public IQueryable<ProductCategory> Collection() {
            return products.AsQueryable();
        }

        public void Delete(int id) {
            ProductCategory toDelete = products.Find(p => p.Id == id);
            if(toDelete != null) {
                products.Remove(toDelete);
            } else {
                throw new Exception("Category Not Found");
            }
        }
    }
}
