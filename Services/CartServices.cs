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
    public class CartServices : BaseServices<CartDTO, Cart, CartDTO>, ICartServices
    {
        public CartServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

            public  IEnumerable<CartDTO> GetByUserId(int userId)
            {
            var ents =_dbSet
                .Where(x=>x.UserId==userId)
                .Include(c=>c.Product)
                .ToList();

            var res = _mapper.Map<IEnumerable<Cart>,IEnumerable<CartDTO>>(ents);
            return res;
            }

        

    }
}
