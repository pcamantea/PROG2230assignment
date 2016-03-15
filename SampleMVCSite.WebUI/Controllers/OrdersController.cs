using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        IRepositoryBase<Order> ordersRepository;

        public OrdersController(IRepositoryBase<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }//end Constructor

        // GET: Orders
        public ActionResult Index()
        {
            var model = ordersRepository.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Order();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Order model)
        {
            ordersRepository.Insert(model);
            ordersRepository.Commit();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Order model = ordersRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Order model)
        {
            ordersRepository.Update(model);
            ordersRepository.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = new Order { OrderId = id };

            ordersRepository.Delete(model);
            ordersRepository.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Order model = ordersRepository.GetById(id);
            return View(model);
        }
    }
}