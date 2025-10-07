using ShopSuite.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ShopSuite.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(object id);
        Task AddAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(User entity);
        Task<User?> GetByUsernameAsync(string username);
    }
}