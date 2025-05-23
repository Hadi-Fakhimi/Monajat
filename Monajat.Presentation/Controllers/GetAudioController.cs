using Microsoft.AspNetCore.Mvc;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;

namespace Monajat.Presentation.Controllers
{
    [Route("api/v1/get-audio")]
    [ApiController]
    public class GetAudioController : ControllerBase
    {
        #region Constructor

        private readonly IAudioService _audioService;

        public GetAudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        #endregion
        [HttpPost]
        public async Task<IActionResult> GetAudio(AudioRequestDto request)
        {
            var response = await _audioService.GetAudioAsync(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
