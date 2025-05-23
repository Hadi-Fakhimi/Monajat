namespace Monajat.Core.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ImageUrl { get; set; }
        public int Duration { get; set; }
        public string? ActionLink { get; set; }
        public string Place { get; set; }
    }
}
