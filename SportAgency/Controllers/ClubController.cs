using Microsoft.AspNetCore.Mvc;

namespace SportAgency.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ClubController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ClubDashboard(int sellerId)
        {
            // Извличане на информация за продавача от базата данни
            var club = _dbContext.Clubs
                .FirstOrDefault(s => s.ClubId == sellerId);

            if (club == null)
            {
                return NotFound(); // Ако продавачът не е намерен
            }

            return View(club);
        }

    }
}
