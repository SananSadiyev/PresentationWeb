using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.BseEntities
{
    public class Contact:BaseEntities
    {
        
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }

    }
}
