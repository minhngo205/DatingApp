using System.Collections.Generic;
using System.Linq;
using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DatingApp.DatingApp.API.Controllers
{
    public class UsersController : BaseAPIController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_context.Users);
        }

        [Authorize]
        [HttpGet("{ID}")]
        public ActionResult<User> getUserByID(int ID){
            var User = _context.Users.FirstOrDefault(u => u.Id == ID);
            if(User==null){
                return NotFound();
            }
            return User;
        }
    }
}