using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        IRepositoryBase<Product> productRepository;

        public ProductsController(IRepositoryBase<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            //var model = productRepository.GetAll();

            //return View(model);
            return RedirectToAction("ProductListing", "Products");
        }

        public ActionResult ProductListing()
        {
            var model = productRepository.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Product();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            productRepository.Insert(model);
            productRepository.Commit();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Product model = productRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            productRepository.Update(model);
            productRepository.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = new Product { ProductId = id };

            productRepository.Delete(model);
            productRepository.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Product model = productRepository.GetById(id);
            return View(model);
        }
    }
}