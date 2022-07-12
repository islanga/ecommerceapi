using ecommerceapi.Data;
using ecommerceapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public CartController(EcommerceDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Carts>> Get() => await _context.Carts.ToListAsync();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Carts cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = cart.Id }, cart);
        }
    }
}
