using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DatingApp.API.Database.Entities
{
    public class UserLike
    {
        public int srcUserID { get; set; }
        public int likedUserID { get; set; }
        public virtual User srcUser { get; set; }
        public virtual User likedUser { get; set; }
    }
}