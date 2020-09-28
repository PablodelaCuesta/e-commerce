using Models.Entities;

namespace Models.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            AddOrderBy(item => item.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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