using Shop.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dtos
{
    public class ProductDto : DtoObject
    {
        public string Type { get; set; }

        public int Quantity { get; set; }

        public int ShopId { get; set; }
    }
}
