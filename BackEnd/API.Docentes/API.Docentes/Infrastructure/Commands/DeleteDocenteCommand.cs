using API.Docentes.Application.DTOs;
using MediatR;

namespace API.Docentes.Infrastructure.Commands
{
    public record DeleteDocenteCommand(int Id) : IRequest<bool>;

}
