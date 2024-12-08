using System.ComponentModel.DataAnnotations;

namespace SportAgency.Entities
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location  { get; set; }
    }
}
