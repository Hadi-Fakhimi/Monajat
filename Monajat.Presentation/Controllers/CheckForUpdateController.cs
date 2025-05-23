using Microsoft.AspNetCore.Mvc;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;

namespace Monajat.Presentation.Controllers
{
    [Route("api/v1/check-for-update")]
    [ApiController]
    public class CheckForUpdateController : ControllerBase
    {
        #region Constructor

        private ICheckForUpdateService _checkForUpdateService;

        public CheckForUpdateController(ICheckForUpdateService checkForUpdateService)
        {
            _checkForUpdateService = checkForUpdateService;
        }

        #endregion
        [HttpPost]
        public async Task<IActionResult> CheckForUpdate(CheckForUpdateRequestDto request)
        {
            var response = await _checkForUpdateService.CheckForUpdate(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
