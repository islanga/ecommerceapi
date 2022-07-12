using ecommerceclient.Helper;
using ecommerceclient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ecommerceclient.Controllers
{
    public class ProductController : Controller
    {
        EcommerceAPI ecommerceapi = new EcommerceAPI();

        public async Task<IActionResult> List()
        {
            List<Products> products      = new List<Products>();
            HttpClient client            = ecommerceapi.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Product");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                products    = JsonConvert.DeserializeObject<List<Products>>(results);
            }

            return View(products);
        }
    }
}
