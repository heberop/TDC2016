using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Backoffice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Restrito()
        {
            ViewData["Message"] = "Você está em uma área restrita!!!";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
