using ShopWA.Dtos;
using ShopWA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Services
{
    public class PriceCalculationService
    {
        private readonly DiscountService _discountService;

        public PriceCalculationService(DiscountService discountService)
        {
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        }

        public ProductDto ApplyDiscount(ProductDto productDto)
        {
            if (productDto.Price.HasValue)
            {
                productDto.Price = productDto.Price - _discountService.CalculateDiscount(productDto.Price.Value);
            }

            return productDto;
        }
    }
}
