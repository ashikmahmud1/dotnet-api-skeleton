using API.ActionFilters;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (result.Succeeded) return StatusCode(201);
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
    }
}