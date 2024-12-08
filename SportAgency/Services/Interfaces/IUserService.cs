using SportAgency.Entities;

namespace SportAgency.Services.Interfaces
{
    public interface IUserService
    {
        User ReadUser(int id);
        IEnumerable<User> ReadAllUsers();
        void RegisterUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
