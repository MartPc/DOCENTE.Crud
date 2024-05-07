using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscalafonTecnicoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EscalafonTecnicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EscalafonTecnicoDto>> GetAll()
        {

            return await _mediator.Send(new GetAllEscalafonTecnicoQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EscalafonTecnicoDto>> GetById(int id)
        {
            var query = new GetEscalafonTecnicoByIdQuery(id);
            var escalafon = await _mediator.Send(query);

            if (escalafon == null)
            {
                return NotFound();
            }

            return Ok(escalafon);
        }
    }
}
