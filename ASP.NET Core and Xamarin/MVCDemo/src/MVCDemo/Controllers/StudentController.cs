using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Repository;
using DNNTeaching.Entities;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            DataConnector d = new DataConnector();
            var e = d.GetAll();

            var i = e.Max(emp => emp.Id);
            i++;
            Employee newEmpl = new Employee { Id = i, FirstName = "Alex", LastName = "Bean" };

            var result = d.Add(newEmpl);
            return View();
        }

        public IActionResult GetNames()
        {
            return Content("Bob, Jeff, John");
        }
    }
}