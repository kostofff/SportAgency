using SportAgency.Entities;
using SportAgency.Repositories.Interfaces;

namespace SportAgency.Repositories.Implementation
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly ApplicationDbContext _context;

        public AthleteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
        }
    }

}
