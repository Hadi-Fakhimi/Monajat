using Microsoft.EntityFrameworkCore;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;
using Monajat.Core.Models;
using Monajat.Infra.Data.Context;

namespace Monajat.Infra.Data.Repositories
{
    public class CheckForUpdateRepository:ICheckForUpdateRepository
    {
        #region Constructor

        private readonly MonajatDbContext _context;

        public CheckForUpdateRepository(MonajatDbContext context)
        {
            _context = context;
        }

        #endregion


        public async Task<AppVersion> GetLastVersionAsync()
        {
            return await _context.AppVersions.AsQueryable()
                .OrderByDescending(v => v.VersionCode)
                .FirstOrDefaultAsync();
        }

        public async Task<List<OptionDto>> GetAllOption()
        {
            return await _context.Options.Select(o => new OptionDto()
            {
                Key = o.Key,
                Value = o.Value

            }).ToListAsync();
        }
    }
}
