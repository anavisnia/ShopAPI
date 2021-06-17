using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Entities
{
    public class ShopOwnerShop
    {
        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public int ShopOwnerId { get; set; }

        public ShopOwner ShopOwner { get; set; }
    }
}
