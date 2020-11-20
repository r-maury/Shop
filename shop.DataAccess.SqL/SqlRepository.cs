using Shop.Core.Logic;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.DataAccess.SqL {
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity {
        internal MyContext DataContext;
        internal DbSet<T> dbSet;

        public SQLRepository(MyContext DataContext) {
            this.DataContext = DataContext;
            this.dbSet = DataContext.Set<T>();

        }
        public IQueryable<T> Collection() {
            return dbSet;
        }

        public void Commit() {
            DataContext.SaveChanges();
        }

        public void Delete(int id) {
            var t = FindById(id);
            if(DataContext.Entry(t).State == EntityState.Detached) {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);
        }


        public T FindById(int id) {
            return dbSet.Find(id);
        }

        public void Insert(T t) {
            dbSet.Add(t);
        }

        public void Update(T t) {
            dbSet.Attach(t);
            DataContext.Entry(t).State = EntityState.Modified;
        }
    }
}
