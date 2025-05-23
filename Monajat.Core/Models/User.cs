namespace Monajat.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public int AppVersion { get; set; }
        public int ApiVersion { get; set; }
        public string MarketName { get; set; }
        public string? FirebaseId { get; set; }
        public string LanguageCode { get; set; }
        public DateTime CreatedAt { get; set; }  //yyyy-MM-dd hh:mm:ss
        public DateTime UpdatedAt { get; set; }



    }
}
