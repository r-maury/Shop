using Shop.Core.Models;
using Shop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                context.Insert(p);
                context.Commit();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Product p = context.FindById(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception )
            {

                return HttpNotFound();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p, int id)
        {
            Product pToEdit = context.FindById(id);
            try
            {
                if(pToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View(pToEdit);
                    }
                    else
                    {
                        //context.Update(pToEdit);
                        pToEdit.Name = p.Name;
                        pToEdit.Description = p.Description;
                        pToEdit.Category = p.Category;
                        pToEdit.Price = p.Price;
                        pToEdit.Image = p.Image;
                        context.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Product p = context.FindById(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception )
            {

                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Product pToDelete = context.FindById(id);
                if (pToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Delete(id);
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }
    }
}