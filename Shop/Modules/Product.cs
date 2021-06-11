using Shop.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Modules
{
    public class Product : Entity
    {
        public int Quantity { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
