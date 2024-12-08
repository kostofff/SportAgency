using Microsoft.EntityFrameworkCore;
using SportAgency.Entities;
using SportAgency.Repositories.Interfaces;

namespace SportAgency.Repositories.Implementation
{
    public class UserRepository : IDb
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User ReadById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> ReadAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
