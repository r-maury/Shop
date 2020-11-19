using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DataAccess.InMemory;

namespace Shop.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryRepository context;
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}