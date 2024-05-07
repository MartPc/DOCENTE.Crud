using API.Docentes.Application.DTOs;
using MediatR;

namespace API.Docentes.Infrastructure.Queries
{
    public record GetAllCiudadQuery : IRequest<IEnumerable<CiudadDto>>;

}
