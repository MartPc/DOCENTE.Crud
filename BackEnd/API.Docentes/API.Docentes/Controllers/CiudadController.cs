using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CiudadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<CiudadDto>> GetAll()
        {

            return await _mediator.Send(new GetAllCiudadQuery());
        }

    }
}
