using Microsoft.AspNetCore.Mvc;
using LearnKing.Api.Data;
using LearnKing.Api.Models;

namespace LearnKing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already registered.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok("Login successful.");
        }
    }
}
