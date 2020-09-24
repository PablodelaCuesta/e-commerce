using Models.Entities;

namespace Models.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);            
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(item => item.Id == id)
        {
            AddInclude(item => item.ProductType);
            AddInclude(item => item.ProductBrand);
        }
        
    }
}