using AutoMapper;
using CleanArchitectureV2.Api.DTO;
using CleanArchitectureV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureV2.Api.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Product, ProductDTO>();
                //cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<ToDoItem, ToDoItemDTO>();
                cfg.CreateMap<ToDoItemDTO, ToDoItem>();
            });

            return config.CreateMapper();
        }
    }
}
