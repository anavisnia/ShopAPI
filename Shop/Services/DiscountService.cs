using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Services
{
    public class DiscountService
    {
        private const int discountPrecent = 10;

        public decimal CalculateDiscount(decimal price)
        {
            return price / 100 * 10;
        }
    }
}
