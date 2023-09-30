using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly IGenericRepository<Product> _Product;
        private readonly IGenericRepository<ProductBrand> _Brand;
        private readonly IGenericRepository<ProductType> _Type;
        private readonly IMapper _Mapper;
        public ProductsController(IGenericRepository<Product> Product, IGenericRepository<ProductBrand> Brand, IGenericRepository<ProductType> Type, IMapper mapper)
        {
            _Product = Product;
            _Brand = Brand;
            _Type = Type;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var specs = new ProductsWithTypesAndBrandsSpecification();

            var products = await _Product.ListAsync(specs);

            return Ok(_Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var specs = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _Product.GetEntityWithSpec(specs);

            return _Mapper.Map<Product, ProductToReturnDto>(product); 
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _Brand.ListAllAsync();

            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes() { 
            var types = await _Type.ListAllAsync();

            return Ok(types);
        }
            
    }
}
