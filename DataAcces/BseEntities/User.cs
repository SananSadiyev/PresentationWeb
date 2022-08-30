
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
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Contact> Contact { get; set; }
        public List<Role> Role { get; set; }
        
    }
}
