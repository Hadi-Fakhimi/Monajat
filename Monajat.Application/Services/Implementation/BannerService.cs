using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;

namespace Monajat.Application.Services.Implementation
{
    public class BannerService:IBannerService
    {
        #region Constructor

        private readonly IBannerRepository _bannerRepository;
        private readonly IUserRepository _userRepository;

        public BannerService(IBannerRepository bannerRepository,IUserRepository userRepository)
        {
            _bannerRepository = bannerRepository;
            _userRepository = userRepository;
        }

        #endregion


        public async Task<BannerResponseDto> GetBannersForHomeLayout(BannerRequestDto request)
        {
            if (!await _userRepository.IsExistUserByUuid(request.Uuid))
            {
                return new BannerResponseDto()
                {
                    StatusCode = 404,
                    Success = false,
                    Message = "کاربری با این شناسه یافت نشد",
                    Data = null
                };
            }

            return new BannerResponseDto()
            {
                StatusCode = 200,
                Success = true,
                Message = "بنر ها با موفقیت دریافت شد.",
                Data = await _bannerRepository.GetBanners()
            };
        }
    }
}
