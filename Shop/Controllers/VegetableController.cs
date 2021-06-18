using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopWA.Controllers.Base;
using ShopWA.Dtos;
using ShopWA.Entities;
using ShopWA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Product> _repository;

        public VegetableController(IMapper mapper, GenericRepository<Product> repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async virtual Task<List<ProductDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            var entity = _repository.GetById(id);

            return _mapper.Map<ProductDto>(entity);
        }

        [HttpPost]
        public async Task Upsert(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);

            await _repository.Upsert(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
