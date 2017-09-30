using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cibertec.MVC
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View(_unit.Customer.GetList());
        }

        public IActionResult Edit(int id)
        {
            return View(_unit.Customer.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customer.Update(customer))
                return RedirectToAction("Index");

            return View(customer);
        }

        public IActionResult Details(int id)
        {
            return View(_unit.Customer.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            return View(_unit.Customer.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            //var customer = _unit.Customer.GetById(id);

            if (ModelState.IsValid && _unit.Customer.Delete(customer))
                return RedirectToAction("Index");

            return View(customer);
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid && _unit.Customer.Insert(customer) != 0)
                return RedirectToAction("Index");

            return View(customer);
        }
    }
}
