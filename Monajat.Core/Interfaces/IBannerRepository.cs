using Monajat.Core.DTOs.Response;

namespace Monajat.Core.Interfaces
{
    public interface IBannerRepository
    {
        Task<List<BannerDto>> GetBanners();
    }
}
