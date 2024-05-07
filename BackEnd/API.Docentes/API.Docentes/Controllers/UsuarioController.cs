using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Commands.Authenticate;
using ApplicationLayer.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Create(AuthenticateUsuarioCommand command)
        {

            var usuario = await _mediator.Send(command);

            if (usuario == null)
            {
                return NotFound(new {Message = "Usuario o contraseña incorrectas"});
            }

            return Ok(new
            {
                Message = "Sesión iniciada"
            });

        }

    }
}
