using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public double Sum { get=> Math.Round(Price * Count, 2); }








        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImgPath { get; set; }
    }
}
