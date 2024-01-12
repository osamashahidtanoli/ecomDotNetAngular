using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productType, 
        IGenericRepository<ProductBrand> productBrand, IMapper mapper)
        {
            _mapper = mapper;
            _productBrand = productBrand;
            _productType = productType;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductReturnDto>>> GetProducts() {
            var spec = new ProductWithBrandAndTypeSpecification();
            var products = await _productRepo.ListAsync(spec);
            
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id) {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductReturnDto>(product);
        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            return Ok(await  _productBrand.ListAllAsync());
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            return Ok(await _productType.ListAllAsync());
        }
        
        
        
    }
}