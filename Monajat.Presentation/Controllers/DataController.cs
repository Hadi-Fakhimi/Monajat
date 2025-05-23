using Microsoft.AspNetCore.Mvc;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;

namespace Monajat.Presentation.Controllers
{
    [Route("api/v1/get-data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        #region Constructor

        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> GetData(DataRequestDto request)
        {
            var response = await _dataService.GetDataAsync(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
