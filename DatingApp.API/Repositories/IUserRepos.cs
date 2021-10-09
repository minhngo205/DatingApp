using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DatingApp.API.Database.Entities;
using DatingApp.DatingApp.API.DTOs;

namespace DatingApp.DatingApp.API.Repositories
{
    public interface IUserRepos
    {
        IEnumerable<User> GetUsers();

        User GetUserByUserName(string username);

        User GetUserByID(int ID);

        IEnumerable<Memberdto> GetMembers();

        Memberdto GetmemberByUserName(string username);

        void CreateUser(User user);

        bool SaveChanges();
    }
}