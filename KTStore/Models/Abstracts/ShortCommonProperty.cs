namespace KTStore.Models.Abstracts
{
    public abstract class ShortCommonProperty
    {
        public int Id  { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

    }
}
