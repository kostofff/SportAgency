using Microsoft.EntityFrameworkCore;
using SportAgency.Entities;
using SportAgency.Repositories.Implementation;
using SportAgency.Repositories.Interfaces;
using SportAgency.Services.Interfaces;

namespace SportAgency.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IDb _userRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IAthleteRepository _athleteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
         IDb userRepository,
         IClubRepository clubRepository,
         IAthleteRepository athleteRepository,
         IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _clubRepository = clubRepository;
            _athleteRepository = athleteRepository;
            _unitOfWork = unitOfWork;
        }

        public void RegisterUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Invalid user data");
                if (_userRepository.GetByEmailAsync(user.Email) != null)
                {
                    throw new Exception("User with this email already exists.");
                }

            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _userRepository.Add(user);


            // Ако потребителят е "Клуб"
            if (user.Role == "Клуб")
            {
                var club = new Club
                {
                    ClubId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Location = "неопределено"
                };
                _clubRepository.Add(club);
            }
            // Ако потребителят е "Спортист"
            else if (user.Role == "Спортист")
            {
                var athlete = new Athlete
                {
                    AthleteId = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = "18"
                };
                _athleteRepository.Add(athlete);
            }

            // Запазване на всички промени
            _unitOfWork.SaveChanges();
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            // Намиране на потребителя по имейл
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            return user;
        }

        public User ReadUser(int id)
        {
            var user = _userRepository.ReadById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public IEnumerable<User> ReadAllUsers()
        {
            return _userRepository.ReadAll();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user); 
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

    }
}
