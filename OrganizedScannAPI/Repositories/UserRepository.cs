﻿using OrganizedScannApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YourNamespace.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);

        Task<bool> ExistsByEmailAsync(string email);
        Task<User?> FindByEmailAsync(string email);
    }
}
