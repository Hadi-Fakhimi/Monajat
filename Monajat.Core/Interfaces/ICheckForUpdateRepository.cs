using Monajat.Core.DTOs.Response;
using Monajat.Core.Models;

namespace Monajat.Core.Interfaces
{
    public interface ICheckForUpdateRepository
    {
        Task<AppVersion> GetLastVersionAsync();
        Task<List<OptionDto>> GetAllOption();
    }
}
