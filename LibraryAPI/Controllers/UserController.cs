using Library.Application.Auth.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/users")]
    public class UserController : ApiBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            await Mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
