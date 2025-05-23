using Microsoft.AspNetCore.Mvc;
using Monajat.Application.Services.Interface;
using Monajat.Core.DTOs.Request;


namespace Monajat.Presentation.Controllers
{
    [Route("api/v1/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        #region Constructor

        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        [HttpPost]
        public async Task<IActionResult> Register( RegisterRequestDto request)
        {
            var response = await _userService.RegisterUser(request);

            return StatusCode(response.StatusCode, response);
        }
    }
}
