using ecommerceclient.Helper;
using ecommerceclient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ecommerceclient.Controllers
{
    public class UserController : Controller
    {
        EcommerceAPI ecommerceapi = new EcommerceAPI();

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Create(Users user)
        {
            HttpClient client = ecommerceapi.Initial();

            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Products> products = new List<Products>();
            HttpClient client = ecommerceapi.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Product");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Products>>(results);
            }

            return View(products);
        }
    }
}
