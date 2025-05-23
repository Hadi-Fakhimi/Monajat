using Monajat.Core.DTOs.Response;

namespace Monajat.Core.Interfaces
{
    public interface IAudioRepository
    {
        Task<List<AudioDataDto>> GetAudioByItemId(int categoryId);
    }
}
