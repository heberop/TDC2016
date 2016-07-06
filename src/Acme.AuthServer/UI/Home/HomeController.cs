using Microsoft.AspNetCore.Mvc;

namespace Acme.AuthServer.UI.Home
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}