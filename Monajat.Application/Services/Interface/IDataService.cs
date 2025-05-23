using Monajat.Core.DTOs.Request;
using Monajat.Core.DTOs.Response;

namespace Monajat.Application.Services.Interface
{
    public interface IDataService
    {
        Task<DataResponseDto> GetDataAsync(DataRequestDto request);
    }
}
