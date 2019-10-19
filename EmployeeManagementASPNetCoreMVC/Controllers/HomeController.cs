using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementASPNetCoreMVC.Models;

namespace EmployeeManagementASPNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        public HomeController(IEmployeeRepository empRepo)
        {
            employeeRepository = empRepo;
        }
        public IActionResult Index()
        {
            var model = employeeRepository.GetAllEmployees();
            ViewBag.PageTitle = "All Employees";
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = employeeRepository.GetById(id);
            ViewBag.PageTitle = "Employee Details";
            return View(model);
        }

        public IActionResult InsertEmployee()
        {
            employeeRepository.InsertEmployee();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
