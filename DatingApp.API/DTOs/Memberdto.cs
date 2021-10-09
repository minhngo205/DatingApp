using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DatingApp.API.DTOs
{
    public class Memberdto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public string AKA { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Intro { get; set; }
        public string Avatar { get; set; }
        public string City { get; set; }
    }
}