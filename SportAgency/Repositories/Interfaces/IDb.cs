using SportAgency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAgency.Repositories.Interfaces
{
    public interface IDb
    {
        User ReadById(int id);
        IEnumerable<User> ReadAll();
        void Add(User user);
        Task<User> GetByEmailAsync(string email);
        void Update(User user);
        void Delete(int id);
    }
}
