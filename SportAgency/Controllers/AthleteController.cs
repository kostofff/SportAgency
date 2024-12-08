using Microsoft.AspNetCore.Mvc;

namespace SportAgency.Controllers
{
    public class AthleteController : Controller
    {
        public IActionResult AthleteDashboard(int userId)
        {
            // Логика за Athlete Dashboard
            return View();
        }
    }

}
