using Monajat.Core.Models;

namespace Monajat.Core.DTOs.Response
{
    public class DataResponseDto
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetContentResponseDto Data { get; set; }


    }

    public class GetContentResponseDto
    {
        public bool NewCategoryAvailable { get; set; }
        public bool NewContentAvailable { get; set; }
        public bool NewTextAvailable { get; set; }
        public List<Verse> Verse { get; set; }
        public List<HomeLayout> HomeLayout { get; set; }
        public List<Category> Category { get; set; }
        public List<Content> Content { get; set; }
        public List<TextContent> TextContent { get; set; }

    }
}
