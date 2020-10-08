using Models.Entities;

namespace Models.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(criteria => 
            (!productParams.BrandId.HasValue || criteria.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || criteria.ProductTypeId == productParams.TypeId))
        {
        }
    }
}