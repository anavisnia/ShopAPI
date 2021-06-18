using ShopWA.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Dtos
{
    public class ProductDto : DtoObject
    {
        public string Type { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal? Price { get; set; } = 3.5M;

        public int ShopId { get; set; }
    }
}
