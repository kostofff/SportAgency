using SportAgency.Entities;
using SportAgency.Repositories.Interfaces;

namespace SportAgency.Repositories.Implementation
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Club club)
        {
            _context.Clubs.Add(club);
        }
    }

}
