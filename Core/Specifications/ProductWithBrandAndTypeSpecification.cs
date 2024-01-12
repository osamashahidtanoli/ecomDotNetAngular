using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification()
        {
            AddIncluded(x => x.ProductType);
            AddIncluded(x => x.ProductBrand);
        }

        public ProductWithBrandAndTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddIncluded(x => x.ProductType);
            AddIncluded(x => x.ProductBrand);
        }
    }
}