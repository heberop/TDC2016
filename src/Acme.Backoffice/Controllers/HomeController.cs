using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Acme.Backoffice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
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
