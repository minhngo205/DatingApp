using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.DatingApp.API.Database;
using DatingApp.DatingApp.API.Database.Entities;
using DatingApp.DatingApp.API.DTOs;

namespace DatingApp.DatingApp.API.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepos(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUser(User user)
        {
            if(GetUserByID(user.Id)!=null) return;
            
            _context.Users.Add(user);
        }

        public Memberdto GetmemberByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Memberdto GetmemberByUserName(string username)
        {
            return _context.Users
                        .Where(u => u.Username.Equals(username))
                        .ProjectTo<Memberdto>(_mapper.ConfigurationProvider)
                        .FirstOrDefault();    
        }

        public IEnumerable<Memberdto> GetMembers()
        {
            return _context.Users.ProjectTo<Memberdto>(_mapper.ConfigurationProvider);
        }

        public User GetUserByID(int ID)
        {
            return _context.Users.FirstOrDefault(u => u.Id==ID);
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateProfile(string username, ProfileDTO profile)
        {
            var user = GetUserByUserName(username);
            if(user==null) return;
            _mapper.Map(profile,user);
        }
    }
}