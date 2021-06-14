using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopWA.Dtos.Base;
using ShopWA.Entities.Base;
using ShopWA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Controllers.Base
{
    public class GenericControllerBase<TDto, TEntity> : ControllerBase where TDto : DtoObject where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<TEntity> _repository;

        public GenericControllerBase(IMapper mapper, GenericRepository<TEntity> repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<List<TDto>> GetAll()
        {
            var entities = await _repository.GetAll();

            return _mapper.Map<List<TDto>>(entities);
        }

        [HttpGet("{id}")]
        public TDto GetById(int id)
        {
            var entity = _repository.GetById(id);

            return _mapper.Map<TDto>(entity);
        }

        [HttpPost]
        public async Task Upsert(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.Upsert(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
