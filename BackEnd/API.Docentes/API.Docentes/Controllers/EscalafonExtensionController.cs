using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscalafonExtensionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EscalafonExtensionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EscalafonExtensionDto>> GetAll()
        {

            return await _mediator.Send(new GetAllEscalafonExtensionQuery());
        }
    }
}
