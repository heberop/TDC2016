using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Acme.Fabrica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Restrito()
        {
            ViewData["Message"] = "Você está em uma área restrita da FABRICA!!!";
            ViewBag.AccessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Produtos()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync("http://localhost:5000/api/produtos");
            ViewBag.Produtos = JsonConvert.DeserializeObject<IEnumerable<string>>(response);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
