namespace Monajat.Core.DTOs.Response
{
    public class BannerResponseDto
    {

        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<BannerDto> Data { get; set; }



    }

    public class BannerDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ImageUrl { get; set; }
        public int Duration { get; set; }
        public string? ActionLink { get; set; }
        public string Place { get; set; }
    }


}
