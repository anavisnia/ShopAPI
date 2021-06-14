using AutoMapper;
using ShopWA.Dtos;
using ShopWA.Entities;
using ShopWA.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWA.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
