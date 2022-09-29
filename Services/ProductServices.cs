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
    public class ProductServices : BaseServices<ProductDTO, Product, ProductDTO>, IProductServices
    {
        public ProductServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

    }
}
