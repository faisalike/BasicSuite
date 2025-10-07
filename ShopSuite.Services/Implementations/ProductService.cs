using ShopSuite.Repositories.Interfaces;
using ShopSuite.Repositories.Mappers;
using ShopSuite.Services.Interfaces;
using ShopSuite.Shared.Dto.Product;

namespace ShopSuite.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(ProductMapper.ToDto);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : ProductMapper.ToDto(product);
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = ProductMapper.ToEntity(productDto);
            var created = await _productRepository.AddAsync(product);
            return ProductMapper.ToDto(created);
        }

        public async Task<bool> UpdateAsync(ProductDto productDto)
        {
            var product = ProductMapper.ToEntity(productDto);
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}