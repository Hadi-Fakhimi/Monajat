using Monajat.Application.Generator;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;
using Monajat.Core.Models;

namespace Monajat.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion
        public async Task<RegisterResponseDto> RegisterUser(RegisterRequestDto request)
        {

            var newUser = new User()
            {
                ApiVersion = request.ApiVersion,
                AppVersion = request.AppVersion,
                LanguageCode = request.LanguageCode,
                MarketName = request.MarketName,
                FirebaseId = request.FirebaseId,
                Uuid = CodeGenerator.UniqueUuidCode(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };

            bool result = await _userRepository.CreateUser(newUser);

            if (!result)
            {

                return new RegisterResponseDto()
                {
                    StatusCode = 500,
                    Message = "عملیات با شکست مواجه شد",
                    Success = true,
                    Data = null
                };
            }

            return new RegisterResponseDto()
            {
                StatusCode = 200,
                Message = "عملیات با موفقیت انجام شد",
                Success = true,
                Data = new RegisterData()
                {
                    Uuid = newUser.Uuid
                }
            };

        }

    }
}
