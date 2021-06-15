using FluentAssertions;
using ShopWA.Dtos;
using ShopWA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopWAUnitTests
{
    public class PriceCalculationServiceTest
    {
        [Fact]
        public void ApplyDiscount_GivenRegularPrice_CalculateCorrectDiscount()
        {
            var product = new ProductDto()
            {
                Price = 3.00M
            };

            // Arrange
            var discountService = new DiscountService();

            var priceCalculationService = new PriceCalculationService(discountService);

            // Act
            var discountedProduct = priceCalculationService.ApplyDiscount(product);

            // Assert
            discountedProduct.Price.Should().Be(2.70M);
        }
    }
}
