using Microsoft.EntityFrameworkCore;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;
using Monajat.Infra.Data.Context;

namespace Monajat.Infra.Data.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        #region Constructor

        private readonly MonajatDbContext _context;

        public BannerRepository(MonajatDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<List<BannerDto>> GetBanners()
        {
            var banner =  _context.Banners.AsQueryable();

            return await banner.Select(b => new BannerDto()
            {
                ActionLink = b.ActionLink,
                Duration = b.Duration,
                Id = b.Id,
                ImageUrl = b.ImageUrl,
                Place = b.Place,
                Title = b.Title


            }).ToListAsync();
        }
    }
}
