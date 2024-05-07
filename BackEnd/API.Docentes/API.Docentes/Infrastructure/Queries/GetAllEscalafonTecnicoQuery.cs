using API.Docentes.Application.DTOs;
using MediatR;

namespace API.Docentes.Infrastructure.Queries
{
    public record GetAllEscalafonTecnicoQuery : IRequest<IEnumerable<EscalafonTecnicoDto>>;

}
