using System.Collections.Generic;
using DatingApp.DatingApp.API.DTOs;
using DatingApp.DatingApp.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DatingApp.DatingApp.API.Controllers
{
    [Authorize]
    public class UsersController : BaseAPIController
    {
        private readonly IUserRepos _userRepos;
        
        public UsersController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Memberdto>> Get()
        {
            return Ok(_userRepos.GetMembers());
        }

        [HttpGet("{username}")]
        public ActionResult<Memberdto> getUserByID(string username){
            var member = _userRepos.GetmemberByUserName(username);
            if(member==null){
                return NotFound();
            }
            return Ok(member);
        }
    }
}