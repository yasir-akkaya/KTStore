using KTStore.Models.Abstracts;

namespace KTStore.Models
{
    public class Product:LongCommonProperty
    {
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
