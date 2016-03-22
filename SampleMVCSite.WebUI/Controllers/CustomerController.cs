using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.DAL.Data;
using SampleMVCSite.DAL.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        IRepositoryBase<Customer> customers;

        public CustomerController(IRepositoryBase<Customer> customers)
        {
            this.customers = customers;
        }//end Constructor

        public ActionResult Index()
        {
            var model = customers.GetAll();

            return View(model);
        }

        public ActionResult ListingForUsers()
        {
            var model = customers.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = new Customer { CustomerId = id };

            customers.Delete(customer);
            customers.Commit();

            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }

    }
}