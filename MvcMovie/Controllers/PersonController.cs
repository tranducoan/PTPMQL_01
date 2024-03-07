<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Index(Person ps)
        {
           string StrOutput= "Xin chao" + ps. PersonId + "-" + ps.FullName + "-" +ps.Address
           viewBag.infoPerson = StrOutput;
           return View();
        }
    }
}

