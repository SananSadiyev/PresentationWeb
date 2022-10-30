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
    public interface IProductServices:IBaseServices<ProductDTO,Product,ProductDTO>
    {
        //   public IEnumerable<ProductDTO> GetFilter(int page = 1, int pageSize = 16, SortOrder order = SortOrder.NameAsc, string search = null);

        public IEnumerable<ProductDTO> GetFilter(out int prodCount, int page = 1, int pageSize = 4, SortOrder order = SortOrder.NameAsc, string search = null);
        public void Delete(int cartId);
        public void Buy(int cartId);
        public void DeleteFromCart(int cartId);
    }
}
