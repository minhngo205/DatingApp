using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DatingApp.API.Repositories
{
    public interface IUserLikeRepos
    {
        bool likeUser(string srcUsername, string likedUsername);
    }
}