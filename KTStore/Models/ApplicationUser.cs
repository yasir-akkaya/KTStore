using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public double Balance { get; set; }
        //Veritabanına dahil etmek etmemek için yazıyor
        [NotMapped]
        public string Role { get; set; }

    }
}
