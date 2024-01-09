using System.ComponentModel.DataAnnotations;

namespace KTStore.Models.Abstracts
{
    public abstract class LongCommonProperty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan!")]
        [MinLength(2, ErrorMessage = "En az 2 karakter giriniz!!")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } = "empty.jpg";
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
