using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.BseEntities
{
    public class Product:BaseEntities
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public string ImgPath { get; set; }
        public string Note { get; set; }

    }
}
