using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;

namespace Monajat.Application.Services.Implementation
{
    public class CheckForUpdateService: ICheckForUpdateService
    {
        #region Constructor

        private readonly ICheckForUpdateRepository _checkForUpdateRepository;
        private readonly IUserRepository _userRepository;

        public CheckForUpdateService(ICheckForUpdateRepository checkForUpdateRepository, IUserRepository userRepository)
        {
            _checkForUpdateRepository = checkForUpdateRepository;
            _userRepository = userRepository;
        }

        #endregion
        public async Task<CheckForUpdateResponseDto> CheckForUpdate(CheckForUpdateRequestDto request)
        {
            if (!await _userRepository.IsExistUserByUuid(request.Uuid))
            {
                return new CheckForUpdateResponseDto()
                {
                    StatusCode = 404,
                    Success = false,
                    Message = "کاربری با این شناسه یافت نشد",
                    Data = null
                };
            }


            var user = await _userRepository.GetUserByUuid(request.Uuid);

            user.AppVersion = request.AppVersion;
             _userRepository.UserUpdate(user);
             await _userRepository.SaveChange();

            var lastVersion = await _checkForUpdateRepository.GetLastVersionAsync();
            var newVersionAvailable = request.AppVersion < lastVersion.VersionCode;
            return new CheckForUpdateResponseDto
            { 
                StatusCode = 200,
                Success = true,
                Message = "اطلاعات با موفقیت دریافت شد.",
                Data = new UpdateDataDto
                {
                    NewVersionAvailable = newVersionAvailable,
                    NewVersionCode = lastVersion.VersionCode,
                    NewVersionName = lastVersion.VersionName,
                    ForceUpdate = lastVersion.ForceUpdate,
                    ChangeLog = lastVersion.Changelog
                },
                Options = await _checkForUpdateRepository.GetAllOption()
                
            };
        }
    }
}
