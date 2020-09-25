using Microsoft.Extensions.Configuration;
using Models.Entities;
using API.Helpers;

namespace API.DTO
{
    public class ProductToReturnDTO
    {
        public ProductToReturnDTO(Product product, IConfiguration config)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.PictureUrl = new ProductUrlResolver(config).Resolve(product.PictureUrl);
            this.ProductType = product.ProductType.Name;
            this.ProductBrand = product.ProductBrand.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}