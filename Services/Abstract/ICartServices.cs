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
    public interface ICartServices:IBaseServices<CartDTO,Cart,CartDTO>
    {

        public IEnumerable<CartDTO> GetByUserId(int userId);
    }
}
