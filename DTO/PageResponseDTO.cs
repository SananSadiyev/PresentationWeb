using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PageResponseDTO<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
       public IEnumerable<T> Values { get; set; }

        public PageResponseDTO(int page, int pageSize, IEnumerable<T> values)
        {
            Page = page;
            PageSize = pageSize;
            Values = values;
        }
    }
}
