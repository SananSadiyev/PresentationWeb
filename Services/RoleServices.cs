using AutoMapper;
using DataAcces;
using DataAcces.BseEntities;
using DTO;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleServices : BaseServices<RoleDTO, Role, RoleDTO>, IRoleServices
    {
        public RoleServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

    }
}
