namespace Monajat.Core.DTOs.Response
{
    public class RegisterResponseDto
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public RegisterData Data { get; set; }

    }

    public class RegisterData
    {
        public Guid Uuid { get; set; }
    }
}
