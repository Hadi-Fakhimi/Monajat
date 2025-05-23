using Microsoft.EntityFrameworkCore;
using Monajat.Core.Interfaces;
using Monajat.Core.Models;
using Monajat.Infra.Data.Context;

namespace Monajat.Infra.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        #region Constructor

        private readonly MonajatDbContext _context;

        public DataRepository(MonajatDbContext context)
        {
            _context = context;
        }
        #endregion



        public async Task<List<Content>> GetContent(int lastContentId)
        {
            var query = _context.Contents.AsQueryable();
            if (await query.CountAsync() > lastContentId)
            {
                return await query.Where(q => q.Id > lastContentId).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<TextContent>> GetTextContent(int lastTextId)
        {
            var query = _context.TextContents.AsQueryable();
            if (await query.CountAsync() > lastTextId)
            {
                return await query.Where(q => q.Id > lastTextId).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Category>> GetCategory(int lastCategoryId)
        {
            var query = _context.Categories.AsQueryable();
            if (await query.CountAsync() > lastCategoryId)
            {
                return await query.Where(q => q.RowId > lastCategoryId).ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<HomeLayout>> GetHomeLayout()
        {
            return await _context.HomeLayouts.AsQueryable().ToListAsync();
        }
        public async Task<List<Verse>> GetVerse()
        {
            return await _context.Verses.AsQueryable().ToListAsync();
        }
        public async Task<bool> NewContentAvailable(int lastContentId)
        {
            return await _context.Contents.AsQueryable().AnyAsync(e => e.Id > lastContentId);
        }

        public async Task<bool> NewCategoryAvailable(int lastCategoryId)
        {
            return await _context.Categories.AsQueryable().AnyAsync(e => e.Id > lastCategoryId);
        }

        public async Task<bool> NewTextAvailable(int lastTextId)
        {
            return await _context.TextContents.AsQueryable().AnyAsync(e => e.Id > lastTextId);

        }





    }
}
