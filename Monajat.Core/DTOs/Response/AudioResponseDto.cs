namespace Monajat.Core.DTOs.Response
{
    public class AudioResponseDto
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<AudioDataDto> Data { get; set; }

    }

    public class AudioDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AudioLink { get; set; }
    }
}
