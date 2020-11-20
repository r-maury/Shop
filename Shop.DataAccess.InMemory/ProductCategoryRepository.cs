using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.InMemory {
    public class ProductCategoryRepository {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> ProductCategories;

        public ProductCategoryRepository() {
            ProductCategories = cache["ProductCategory"] as List<ProductCategory>;
            if(ProductCategories == null) {
                ProductCategories = new List<ProductCategory>();
            }
        }

        public void Commit() {
            cache["ProductCategory"] = ProductCategories;
        }

        public void Insert(ProductCategory p) {
            ProductCategories.Add(p);
        }

        public void Update(ProductCategory product) {
            ProductCategory toUpdate = ProductCategories.Find(p => p.Id == product.Id);

            if(toUpdate != null) {
                toUpdate = product;
            } else {
                throw new Exception("Category Not Found");
            }
        }
        public ProductCategory FindById(int id) {
            ProductCategory p = ProductCategories.Find(p1 => p1.Id == id);
            if(p != null) {
                return p;
            } else {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<ProductCategory> Collection() {
            return ProductCategories.AsQueryable();
        }

        public void Delete(int id) {
            ProductCategory toDelete = ProductCategories.Find(p => p.Id == id);
            if(toDelete != null) {
                ProductCategories.Remove(toDelete);
            } else {
                throw new Exception("Category Not Found");
            }
        }
    }
}
