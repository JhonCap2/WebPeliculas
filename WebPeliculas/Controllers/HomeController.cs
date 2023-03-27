using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peliculas.Core.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using WebPeliculas.Models;

namespace WebPeliculas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var Cliente = new HttpClient();
            var json = await Cliente.GetStringAsync("https://localhost:7100/api/Movies");
           
            var jsonobjet = JObject.Parse(json);
            //TODO: Aqui estaba trabajando
            var moviesList = JsonConvert.DeserializeObject<List<Movies>>(jsonobjet["data"].ToString());
            
            return View(moviesList);
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