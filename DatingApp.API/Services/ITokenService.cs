using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DatingApp.API.Database.Entities;

namespace DatingApp.DatingApp.API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}