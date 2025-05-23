using Monajat.Core.Models;

namespace Monajat.Core.Interfaces
{
    public interface IDataRepository
    {
        Task<bool> NewCategoryAvailable(int lastCategoryId);
        Task<bool> NewContentAvailable(int lastContentId);
        Task<bool> NewTextAvailable(int lastTextId);

        Task<List<HomeLayout>> GetHomeLayout();
        Task<List<Verse>> GetVerse();
        Task<List<Content>> GetContent(int lastContentId);
        Task<List<Category>> GetCategory(int lastCategoryId);
        Task<List<TextContent>> GetTextContent(int lastTextId);
    }
}
