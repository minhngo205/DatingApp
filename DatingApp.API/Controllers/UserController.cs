using System.Collections.Generic;
using System.Security.Claims;
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
        private readonly IUserLikeRepos _userLikeRepos;
        public UsersController(IUserRepos userRepos, IUserLikeRepos userLikeRepos)
        {
            _userRepos = userRepos;
            _userLikeRepos = userLikeRepos;
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

        [HttpPut]
        public ActionResult<Memberdto> editUser(ProfileDTO profile){
            var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(string.IsNullOrEmpty(username)) return NotFound();
            _userRepos.UpdateProfile(username,profile);
            if(_userRepos.SaveChanges()) return NoContent();
            return NotFound();
        }

        [HttpPost("{likedUsername}")]
        public ActionResult Like(string likedUsername)
        {
            var sourceUsername = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_userLikeRepos.likeUser(sourceUsername, likedUsername)) return NoContent();
            return BadRequest();
        }
    }
}