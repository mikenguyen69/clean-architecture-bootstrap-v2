using AutoMapper;
using CleanArchitectureV2.Api.DTO;
using CleanArchitectureV2.Core.Entities;
using CleanArchitectureV2.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV2.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _repository.List()
                .Select(product => _mapper.Map<Product, ProductDTO>(product));

            return Ok(products);
        }
    }
}
