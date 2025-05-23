using Microsoft.AspNetCore.Mvc;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;

namespace Monajat.Presentation.Controllers
{
    [Route("api/v1/get-banners")]
    [ApiController]
    public class GetBannerController : ControllerBase
    {
        #region Constructor

        private readonly IBannerService _bannerService;

        public GetBannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        #endregion
        [HttpPost]
        public async Task<IActionResult> GetHomeLayoutBanner(BannerRequestDto request)
        {
            var response = await _bannerService.GetBannersForHomeLayout(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
