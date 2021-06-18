using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ShopWA.Controllers;
using ShopWA.Data;
using ShopWA.Dtos;
using ShopWA.Entities;
using ShopWA.Mappings;
using ShopWA.Repositories;
using ShopWA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopWAUnitTests
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task Test()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var discountService = new DiscountService();

            var priceCalculationService = new PriceCalculationService(discountService);

            var mockContext = new DataContext(GetInMemoryDbContextOptions());

            mockContext.Shops.Add(new Shop()
            {
                Id = 1
            });

            var repository = new GenericRepository<Product>(mockContext, mapper);
            
            var productController = new ProductController(mapper, repository, priceCalculationService);
            //end arrange

            var productDto = new ProductDto()
            {
                Name = "Test",
                Price = 3.00M,
                ShopId = 1
            };

            await productController.Upsert(productDto);

            var results = await productController.GetAll();

            //results.Should().NotBeEmpty();
            results.First().Price.Should().Be(2.70M);
        }

        public static DbContextOptions<DataContext> GetInMemoryDbContextOptions(string dbName = "Test_DB")
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
    }
}
