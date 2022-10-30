using DataAcces.BseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        public string RoleName { get; set; }

        public int RoleId { get; set; }
        public string Salt { get; set; }

        public string PasswordHash { get; set; }

        [Required]
        public string Password { get; set; }

        
        

    }
}
