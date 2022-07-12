using ecommerceapi.Data;
using ecommerceapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly EcommerceDbContext _context;
        public ProductController(EcommerceDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
