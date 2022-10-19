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
    public class ProductServices : BaseServices<ProductDTO, Product, ProductDTO>, IProductServices
    {
        public ProductServices(AppDbContext db, IMapper mapper) : base(db, mapper)
        {



        }



        //public IEnumerable<ProductDTO> GetFilter(int page = 1, int pageSize = 16, SortOrder order = SortOrder.NameAsc, string search = null)
        //{
        //    //doing it in code, but need in db
        //    var res = Get();

        //    if (!string.IsNullOrEmpty(search))
        //        res = res.Where(pr => pr.Name.ToLower().Contains(search.ToLower()));

        //    res = order switch
        //    {
        //        SortOrder.NameDesc => res.OrderByDescending(s => s.Name),
        //        SortOrder.PriceAsc => res.OrderBy(s => s.Price),
        //        SortOrder.PriceDesc => res.OrderByDescending(s => s.Price),

        //        _ => res.OrderBy(s => s.Name),
        //    };

        //    var prods = res.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    return prods;
        //}

    }
}
