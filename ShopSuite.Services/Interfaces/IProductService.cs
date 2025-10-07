using ShopSuite.Shared.Dto.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopSuite.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto product);
        Task<bool> UpdateAsync(ProductDto product);
        Task<bool> DeleteAsync(int id);
    }
}