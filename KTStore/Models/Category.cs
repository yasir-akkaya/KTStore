using KTStore.Models.Abstracts;

namespace KTStore.Models
{
    public class Category :LongCommonProperty
    {
        public List<Product>? Products { get; set; }
    }
}
