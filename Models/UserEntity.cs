using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TodoApi.Models
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public List<ShelfEntity> UserShelf  { get; set; }
        
    }
}