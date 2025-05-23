namespace Monajat.Core.Models
{
    public class Content
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? ArabicText { get; set; }
        public string? PersianText { get; set; }
    }
}
