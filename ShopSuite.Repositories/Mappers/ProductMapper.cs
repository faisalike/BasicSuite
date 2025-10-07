using ShopSuite.Domain.Entities;
using ShopSuite.Shared.Dto.Product;

namespace ShopSuite.Repositories.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }

        public static Product ToEntity(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description
            };
        }
    }
}