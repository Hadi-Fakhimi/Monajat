namespace Monajat.Core.Models
{
    public class TextContent
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Text { get; set; } // nvarchar max
    }
}
