using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;

namespace Monajat.Application.Services.Implementation
{
    public class AudioService: IAudioService
    {
        #region Constructor

        private readonly IAudioRepository _audioRepository;
        private readonly IUserRepository _userRepository;

        public AudioService(IAudioRepository audioRepository,IUserRepository userRepository)
        {
            _audioRepository = audioRepository;
            _userRepository = userRepository;
        }

        #endregion

        public async Task<AudioResponseDto> GetAudioAsync(AudioRequestDto request)
        {

            if (!await _userRepository.IsExistUserByUuid(request.Uuid))
            {
                return new AudioResponseDto()
                {
                    StatusCode = 404,
                    Success = false,
                    Message = "کاربر با این شناسخ کاربری یافت نشد",
                    Data = null
                };
            }

            return new AudioResponseDto()
            {
                StatusCode = 200,
                Success = true,
                Message = "اطالعات با موفقیت دریافت شد.",
                Data = await _audioRepository.GetAudioByItemId(request.CategoryId)
            };
        }
    }
}
