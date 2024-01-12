using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductResolver : IValueResolver<Product, ProductReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductResolver(IConfiguration config)
        {
            _config = config;

        }

        public string Resolve(Product source, ProductReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}