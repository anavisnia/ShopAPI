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
    public class ProductController : GenericControllerBase<ProductDto, Product>
    {
        public ProductController(IMapper mapper, GenericRepository<Product> repository) : base(mapper, repository)
        {
        }
    }
}
