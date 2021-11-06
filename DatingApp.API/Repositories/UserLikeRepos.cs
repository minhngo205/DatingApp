using System;
using System.Linq;
using AutoMapper;
using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.DatingApp.API.Repositories
{
    public class UserLikeRepos : IUserLikeRepos
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserLikeRepos(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool likeUser(string srcUsername, string likedUsername)
        {
            var sourceUser = _context.Users
                .Include(x => x.SourceUsers)
                .FirstOrDefault(u => u.Username == srcUsername);
            if (sourceUser == null) return false;
            var likedUser = _context.Users.FirstOrDefault(u => u.Username == likedUsername);
            if (likedUser == null) return false;
            if (sourceUser.SourceUsers.Any(u => u.likedUserID == likedUser.Id)) return false;
            _context.UserLikes.Add(new UserLike
            {
                likedUserID = likedUser.Id,
                srcUserID = sourceUser.Id
            });
            return _context.SaveChanges() > 0;
        }

        // public bool likeUser(string srcUsername, string likedUsername)
        // {
        //     var srcUser = _context.Users.FirstOrDefault(u => u.Username == srcUsername);
        //     var likedUser = _context.Users.FirstOrDefault(u => u.Username == likedUsername);

        //     if(srcUser == null || likedUser == null) return false;
        // }
    }
}