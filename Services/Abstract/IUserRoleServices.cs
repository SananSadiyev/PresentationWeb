using DataAcces.BseEntities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{     public interface IUserRoleServices : IBaseServices <UserRoleDTO, UserRole, UserRoleDTO>
        {
            // public List<UserContactsDTO> GetUserContasts();
        }
    
}
