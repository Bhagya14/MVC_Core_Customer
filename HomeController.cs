using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Core_Customer.Models;

namespace MVC_Core_Customer.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db;
        public HomeController(MyDbContext db)
        {
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var count = db.Customers.Count(e => e.CustomerID == model.LoginID && e.CustomerPassword == model.Password);
                if (count > 0)
                {
                    HttpContext.Session.SetString("LoginID", model.LoginID.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msg = "Invalid ID Or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    
    public IActionResult Index()
    {
            ViewBag.msg = "Login ID:" + HttpContext.Session.GetString("LoginID");
            return View();
    }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(model);
                db.SaveChanges();
                ViewBag.msg = "Customer ID:" + model.CustomerID;
                return View();
            }
            else
            {
                ViewBag.msg = "Validation Error";
                return View();
            }
        }


        public IActionResult GetCustomers()
        {
            var model = db.Customers.ToList();
            return View(model);
        }

    }
}