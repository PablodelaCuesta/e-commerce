using Models.Entities;

namespace Models.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(criteria => 
            (!productParams.BrandId.HasValue || criteria.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || criteria.ProductTypeId == productParams.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            // AddOrderBy(item => item.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(item => item.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(item => item.Price);
                        break;
                    default:
                        AddOrderBy(item => item.Name);
                        break;
                }
            }

        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(item => item.Id == id)
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
        }
        
    }
}