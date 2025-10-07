using Microsoft.EntityFrameworkCore;
using ShopSuite.Domain.Entities;
using ShopSuite.Repositories.Interfaces;

namespace ShopSuite.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _repo;

        public UserRepository(IGenericRepository<User> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(object id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(User entity)
        {
            await _repo.AddAsync(entity);
            await _repo.SaveAsync();
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            _repo.Update(entity);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(User entity)
        {
            _repo.Delete(entity);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _repo.AsQueryable().FirstOrDefaultAsync(u => u.Username == username);
        }

    }
}