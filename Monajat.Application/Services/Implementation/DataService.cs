using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;
using Monajat.Core.Interfaces;

namespace Monajat.Application.Services.Implementation
{

    public class DataService:IDataService
    {
        #region Constructor

        private readonly IDataRepository _dataRepository;
        private readonly IUserRepository _userRepository;

        public DataService(IDataRepository dataRepository, IUserRepository userRepository)
        {
            _dataRepository = dataRepository;
            _userRepository = userRepository;
        }

        #endregion


        public async Task<DataResponseDto> GetDataAsync(DataRequestDto request)
        {


            var user = await _userRepository.IsExistUserByUuid(request.Uuid);

            if (!user)
            {
                return new DataResponseDto
                {
                    StatusCode = 404,
                    Success = false,
                    Message = "کاربر مورد نظر یافت نشد",
                    Data = null
                };
            }


            bool newCategoryAvailable = await _dataRepository.NewCategoryAvailable(request.LastCategoryId);
            bool newContentAvailable = await _dataRepository.NewContentAvailable(request.LastContentId);
            bool newTextAvailable = await _dataRepository.NewTextAvailable(request.LastTextContentId);
            return new DataResponseDto()
            {
                StatusCode = 200,
                Success = true,
                Message = "اطلاعات با موفقیت دریافت شد.",
                Data = new GetContentResponseDto()
                {
                   NewContentAvailable = newContentAvailable,
                   NewTextAvailable = newTextAvailable,
                   NewCategoryAvailable = newCategoryAvailable,
                   Category = await _dataRepository.GetCategory(request.LastCategoryId),
                   Content = await _dataRepository.GetContent(request.LastContentId),
                   TextContent = await _dataRepository.GetTextContent(request.LastTextContentId),
                   HomeLayout = await _dataRepository.GetHomeLayout(),
                   Verse = await _dataRepository.GetVerse()
                }
            };
        }
    }
}
