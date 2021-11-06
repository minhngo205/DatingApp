using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DatingApp.API.DTOs
{
    public class ProfileDTO
    {
        public DateTime DateofBirth { get; set; }

        [StringLength(32)]
        public string AKA { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(256)]
        public string Intro { get; set; }

        [StringLength(512)]
        public string Avatar { get; set; }
        
        [StringLength(32)]
        public string City { get; set; }
    }
}