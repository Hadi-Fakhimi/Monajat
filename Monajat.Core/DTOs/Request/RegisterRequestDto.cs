namespace Monajat.Core.DTOs.Request
{
    public class RegisterRequestDto
    {
        public int AppVersion { get; set; }
        public int ApiVersion { get; set; }
        public string MarketName { get; set; }
        public string FirebaseId { get; set; }
        public string LanguageCode { get; set; }
    }
}
