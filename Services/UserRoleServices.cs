using AutoMapper;
using DataAcces;
using DataAcces.BseEntities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserRoleServices : BaseServices<UserRoleDTO, UserRole, UserRoleDTO>, IUserRoleServices
    {
        public UserRoleServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override IEnumerable<UserRoleDTO> Get()
        {
            var ent = _dbSet.Include(x => x.User).Include(x => x.Role);

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            return res;
        }
    }
}
