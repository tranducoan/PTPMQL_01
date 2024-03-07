using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View(new Person()); 
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
           ViewBag.thongBao = "Xin chao " + person.PersonId + " - " + person.FullName + " - " + person.Address ;
            return View(person); 
        }
    }
}
// Tran Đuc toan-2021050642