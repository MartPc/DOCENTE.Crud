using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocenteGetAllDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllDocenteQuery());
            return Ok(result);
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<DocenteDto>> GetById(int id)
        {
            var query = new GetDocenteByIdQuery(id);
            var docente = await _mediator.Send(query);

            if (docente == null)
            {
                return NotFound();
            }

            return Ok(docente);
        }

        [HttpPost]
        public async Task<ActionResult<DocenteDto>> Create(CreateDocenteCommand command)
        {
            
            var docente = await _mediator.Send(command);

            return Ok(docente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateDocenteCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest();
            }

            var docente = await _mediator.Send(command);

            if (docente == null)
            {
                return NotFound();
            }

            return Ok(docente);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDocenteCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }



    }
}
