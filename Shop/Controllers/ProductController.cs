using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopWA.Controllers.Base;
using ShopWA.Data;
using ShopWA.Dtos;
using ShopWA.Entities;
using ShopWA.Repositories;
using ShopWA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : GenericControllerBase<ProductDto, Product>
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Product> _repository;
        private readonly PriceCalculationService _priceCalculationService;
        private readonly DataContext _context;

        public ProductController(IMapper mapper, GenericRepository<Product> repository, PriceCalculationService priceCalculationService, DataContext context) : base(mapper, repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _priceCalculationService = priceCalculationService ?? throw new ArgumentNullException(nameof(priceCalculationService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async override Task<List<ProductDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            var dtos = _mapper.Map<List<ProductDto>>(entities);

            //var updatedDtos = dtos.Select(d => _priceCalculationService.ApplyDiscount(d)).ToList();

            dtos.ForEach(d => _priceCalculationService.ApplyDiscount(d));

            return dtos;
        }

        [HttpPost("/buy")]
        public decimal Buy(BuyItemDto buyItemDto)
        {
            var item = _context.Products.FirstOrDefault(i => i.Name == buyItemDto.ItemName);

            var totalPrice = (decimal)item.Price * buyItemDto.ItemQuantity;
           
            return (decimal)totalPrice;
        }
    }
}
