using Microsoft.EntityFrameworkCore;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;
using Monajat.Infra.Data.Context;

namespace Monajat.Infra.Data.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        #region Constructor

        private readonly MonajatDbContext _context;

        public AudioRepository(MonajatDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<List<AudioDataDto>> GetAudioByItemId(int categoryId)
        {
            var audios = await _context.Audios.Where(a => a.CategoryId == categoryId).ToListAsync();

            return audios.Select(a => new AudioDataDto()
            {
                AudioLink = a.AudioLink,
                Id = a.Id,
                Name = a.Name

            }).ToList();
        }
    }
}
