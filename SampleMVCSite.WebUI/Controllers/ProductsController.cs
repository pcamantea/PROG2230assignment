using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using SampleMVCSite.Services;
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
        IRepositoryBase<Basket> baskets;
        BasketService basketService;

        public ProductsController(IRepositoryBase<Product> productRepository, IRepositoryBase<Basket> baskets)
        {
            this.baskets = baskets;
            this.productRepository = productRepository;
            basketService = new BasketService(this.baskets);
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
            var model = new Product { ProductID = id };

            productRepository.Delete(model);
            productRepository.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Product model = productRepository.GetById(id);
            return View(model);
        }

        public ActionResult BasketSummary()
        {
            var model = basketService.GetBasket(this.HttpContext);
            return View(model.BasketItems);
        }

        public ActionResult AddToBasket(int id)
        {
            basketService.AddToBasket(this.HttpContext, id, 1);//always add one to the basket
            return RedirectToAction("BasketSummary");
        }
    }
}