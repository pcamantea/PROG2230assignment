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
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer() { CustomerId = 1, CustomerName = "Customer 1", Address1 = "Address 1", EmailAddress = "email1@gmail.com", Town = "Kitchener" });
            //customers.Add(new Customer() { CustomerId = 2, CustomerName = "Customer 2", Address1 = "Address 2", EmailAddress = "email2@gmail.com", Town = "Kitchener" });
            //customers.Add(new Customer() { CustomerId = 3, CustomerName = "Customer 3", Address1 = "Address 3", EmailAddress = "email3@gmail.com", Town = "Kitchener" });
            //return View(customers);

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