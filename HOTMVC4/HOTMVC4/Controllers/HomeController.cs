using HOTMVC4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HOTMVC4.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];

            return View();
        }

    }
}
