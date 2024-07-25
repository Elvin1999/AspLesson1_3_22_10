using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
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
                }
        };

        public IActionResult Index()
        {
            var vm = new EmployeeListViewModel
            {
                Employees = Employees
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities=new List<SelectListItem>
                {
                    new SelectListItem{Text="Baku",Value="10"},
                    new SelectListItem{Text="Xirdalan",Value="1"},
                    new SelectListItem{Text="Sumqayit",Value="50"}
                }
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Employee.Id = (new Random()).Next(10, 1000);
                Employees.Add(vm.Employee);
                return RedirectToAction("Index");
            }
            return View(vm); 
        }

    }
}
