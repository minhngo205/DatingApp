using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Database.Entities;
using DatingApp.DatingApp.API.DTOs;
using DatingApp.DatingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.DatingApp.API.Controllers
{
    public class AccountsController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountsController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        
        [HttpPost("register")]
        public ActionResult<string> Register(Registerdto registerdto)
        {
            registerdto.Username.ToLower();
            if(_context.Users.Any(u => u.Username == registerdto.Username)){
                return BadRequest("Username is existed !");
            }

            using var hmac = new HMACSHA512();

            var user = new User{
                Username = registerdto.Username,
                Email = registerdto.Email,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                passwordSalt = hmac.Key
            };
            _context.Add(user);
            _context.SaveChanges();
            return Ok(new UserResponedto{
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("login")]
        public ActionResult<string> Login(Logindto logindto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == logindto.Username.ToLower());
            if(user == null) return Unauthorized("Invalid username");
            using var hmac = new HMACSHA512(user.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.passwordHash[i]) return Unauthorized("Invalid password");
            }
            return Ok(new UserResponedto{
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}