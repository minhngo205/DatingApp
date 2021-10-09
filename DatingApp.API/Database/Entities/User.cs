using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.DatingApp.API.Database.Entities
{
    [Table("User")]
    public class User    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        public byte[] passwordHash {get; set;}
        public byte[] passwordSalt {get; set;}
        public DateTime DateofBirth { get; set; }
        
        [StringLength(32)]
        public string AKA { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(256)]
        public string Intro { get; set; }

        [StringLength(512)]
        public string Avatar { get; set; }

        [StringLength(32)]
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // public int GetAge()
        // {
        //     var today = DateTime.Now;
        //     var age = today.Year - DateofBirth.Year;
        //     if (DateofBirth.Date > today.AddYears(-age)) age--;
        //     return age;
        // }
    }
}