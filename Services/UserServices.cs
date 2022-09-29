﻿using AutoMapper;
using DataAcces;
using DataAcces.BseEntities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : BaseServices<UserDTO, User, UserDTO>, IUserServices
    {

        public UserServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public List<UserContactsDTO> GetUserContacts()
        {
            var res = _db.Users.Include(x => x.Contacts).ToList();

            var dto = _mapper.Map<List<User>, List<UserContactsDTO>>(res);

            return dto;
        }

        public UserDTO Login(UserDTO model)
        {

            var res = _db.Users.Where(x => x.Username == model.Username);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();
                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else
            {
                throw new Exception("User not found");
            }

        }

        public override UserDTO Create(UserDTO model)
        {
            model.Salt = Crypto.GenerateSalt();
            model.PasswordHash = Crypto.GenerateSHA256Hash(model.Password, model.Salt);

            return base.Create(model);
        }

        public IEnumerable<UserRoleDTO> GetUserRoles()
        {
            var ent = _dbSet.Include(x => x.Role);

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            return res;
        }

        public IEnumerable<UserRoleDTO> GetUserRoles(UserDTO user)
        {
            var ent = _dbSet.Include(x => x.Role).Where(x => x.Id == user.Id).First();

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            return res;
        }
    }

}
