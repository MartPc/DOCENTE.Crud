using API.Docentes.Application.DTOs;
using MediatR;

namespace API.Docentes.Infrastructure.Queries
{

    public record GetDocenteByIdQuery(int Id) : IRequest<DocenteDto>;
}
