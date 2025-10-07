using ShopSuite.Domain.Entities;
using ShopSuite.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopSuite.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _repo;

        public ProductRepository(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _repo.AddAsync(product);
            await _repo.SaveAsync();
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _repo.Update(product);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;
            _repo.Delete(product);
            await _repo.SaveAsync();
            return true;
        }
    }
}