using CleanArchitectureApplication.Contracts;
using CleanArchitectureDomain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserListRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}