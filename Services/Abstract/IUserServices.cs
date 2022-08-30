using DataAcces;
using DataAcces.BseEntities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserServices:IBaseServices<UserDTO,User,UserDTO>
    {
        public UserDTO Login(string user, string pas);

        public List<UserContactsDTO> GetUserContasts();

    }
}
