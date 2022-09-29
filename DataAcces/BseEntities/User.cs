
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
        public Contact Contacts { get; set; }
        public List<Role> Role { get; set; }

    }
}
