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
    public class ShopController : GenericControllerBase<ShopDto, Shop>
    {
        private readonly GenericRepository<Shop> _repository;

        public ShopController(IMapper mapper, GenericRepository<Shop> repository) : base(mapper, repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}
