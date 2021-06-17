using ShopWA.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Entities
{
    public class Shop : Entity
    {
        public List<Product> Products { get; set; }

        public List<ShopOwnerShop> ShopOwnersShop { get; set; }
    }
}
