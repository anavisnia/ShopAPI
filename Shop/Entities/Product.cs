using ShopWA.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Entities
{
    public class Product : Entity
    {
        public string Type { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
