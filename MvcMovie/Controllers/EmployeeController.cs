using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace DemoMVC.Controllers
{
//Tran Đuc toan  - 2021050642
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Employee()); 
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            
            ViewBag.Message = "Thông tin nhân viên: " + employee.EmployeeId + " tuoi " + employee.Age;
            return View(employee);
        }
    }
}
