using ecommerceapi.Data;
using ecommerceapi.Models;
using ecommerceapi.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly EcommerceDbContext _context;

        public UserController(EcommerceDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Users>> Get() => await _context.Users.ToListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
             return user == null ? NotFound() : Ok(user);
        }

        [HttpGet("{requestEmail},{requestPassword}")]
        [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(string requestEmail, string requestPassword)
        {
            String password = Password.hashPassword(requestPassword);
            var user = _context.Users.Where(x => x.Email == requestEmail && x.Password == password).FirstOrDefault();
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(UserPasswordConfirm user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dbUser = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (dbUser != null) return BadRequest("User already exists");

            String password = Password.hashPassword(user.Password);
            Users users = new Users()
            {
                Id = user.Id,
                Email = user.Email,
                Password = password
            };
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = users.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Users user)
        {
            user.Password = Password.hashPassword(user.Password);
            if (id != user.Id) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
