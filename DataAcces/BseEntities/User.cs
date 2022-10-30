
using DataAcces.BseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.BseEntities
{
    public class User : BaseEntities
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Username { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Contact Contacts { get; set; }
        public  Role Role { get; set; }







        public List<Cart> Cart { get; set; } = new List<Cart>();

    }
}
