namespace Monajat.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int RowId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public int CategoryOrder { get; set; }
        public int ContentId { get; set; }
    }
}
