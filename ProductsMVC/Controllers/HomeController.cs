using DatabaseService.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductsMVC.Models;
using System.Diagnostics;

namespace ProductsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = new List<Product>();

            var apiUrl = new Uri(_configuration.GetValue<string>("APIBaseAddress"));

            var response = await _httpClient.GetAsync(apiUrl + "/products");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(responseData);
            }
            return View(products);
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