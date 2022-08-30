using AutoMapper;
using DataAcces;
using DataAcces.BseEntities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserServices : BaseServices<UserDTO, User, UserDTO>, IUserServices
    {
        public UserServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {
        }



        public List<UserContactsDTO> GetUserContasts()
        {
            var res = _db.Users.Include(x => x.Contact).ToList();

            var x  = _mapper.Map<IEnumerable<UserContactsDTO>>(res).ToList();

            return x;
        }
        public UserDTO Login(string user, string pas)
        {
            var log = _db.Users.Where(x => x.Username == user && x.Password == pas);
            if (log.Count() == 1)
            {
                var dto = _mapper.Map<User, UserDTO>(log.First());
                return dto;
            }
            else
            {
                throw new Exception("Login Tapilmadi !!!");
            }
        }
    }

}
