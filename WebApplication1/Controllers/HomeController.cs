using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from Index Action";
        }

        public IActionResult Index2()
        {
            return Ok();
        }

        public IActionResult Index3()
        {
            return NotFound();
        }

        public IActionResult Index4()
        {
            return BadRequest();
        }

        public IActionResult Employees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                     Firstname="Ali",
                      Lastname="Aliyev",
                      CityId=1
                },
                new Employee
                {
                    Id=2,
                     Firstname="Huseyn",
                      Lastname="Huseynov",
                      CityId=10
                },
                new Employee
                {
                    Id=3,
                     Firstname="Ruad",
                      Lastname="Dunyamaliyev",
                      CityId=77
                },
            };

            List<string> cities = new List<string> { "Baku", "Oslo", "Ankara" };

            var viewModel = new EmployeeViewModel
            {
                Employees = employees,
                Cities = cities
            };
            return View(viewModel);
            // return Json(employees);
        }

        public IActionResult GetEmployee(int id, int id2)
        {
            return Json(new { id, id2 });
            //List<Employee> employees = new List<Employee>
            //{
            //    new Employee
            //    {
            //        Id=1,
            //         Firstname="Ali",
            //          Lastname="Aliyev",
            //          CityId=1
            //    },
            //    new Employee
            //    {
            //        Id=2,
            //         Firstname="Huseyn",
            //          Lastname="Huseynov",
            //          CityId=10
            //    },
            //    new Employee
            //    {
            //        Id=3,
            //         Firstname="Ruad",
            //          Lastname="Dunyamaliyev",
            //          CityId=77
            //    },
            //};
            //var employee=employees.FirstOrDefault(e=>e.Id==id);
            //return Json(employee);
        }


        public IActionResult GetById(int id)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                     Firstname="Ali",
                      Lastname="Aliyev",
                      CityId=1
                },
                new Employee
                {
                    Id=2,
                     Firstname="Huseyn",
                      Lastname="Huseynov",
                      CityId=10
                },
                new Employee
                {
                    Id=3,
                     Firstname="Ruad",
                      Lastname="Dunyamaliyev",
                      CityId=77
                },
            };

            var item = employees.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                var employeeDetailViewModel = new EmployeeDetailViewModel
                {
                    Id = item.Id,
                    Name = item.Firstname,
                    Surname = item.Lastname
                };
                return View(employeeDetailViewModel);
            }
            else
            {
                // return Redirect("/home/employees");
                //return RedirectToAction("employees");
                // return RedirectToAction("GetById", new { id = 1 });
                var routeValue = new RouteValueDictionary(new {action="Employees",controller="Home"});
                return RedirectToRoute(routeValue);

            }
        }

        public IActionResult FindItems(string name = "No Name", string surname = "No Surname")
        {
            return Json(new { name, surname });
        }
    }
}
