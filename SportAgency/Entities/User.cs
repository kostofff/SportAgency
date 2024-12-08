using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportAgency.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Името е задължително.")]
       // [Range(2,151)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Имейлът е задължителен.")]
       // [EmailAddress(ErrorMessage = "Невалиден формат на имейл адрес.")]
       // [RegularExpression(@"^[A-Za-zА-Яа-я\s]+$", ErrorMessage = "Името може да съдържа само букви и интервали.")]
        public string Email { get; set; }
        [Required]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Паролата трябва да бъде поне 6 символа.")]
       // [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
       // ErrorMessage = "Паролата трябва да съдържа поне една главна буква, една малка буква, една цифра и един специален символ.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Полето е задължително.")]
        //  [RegularExpression("^(Спортист|Клуб)$", ErrorMessage = "Моля, изберете 'Спортист' или 'Клуб'.")]
        public string Role { get; set; }
        public User(string name,string email,string password) 
        { 
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        private User() 
        { 
         
        }
    }
}
