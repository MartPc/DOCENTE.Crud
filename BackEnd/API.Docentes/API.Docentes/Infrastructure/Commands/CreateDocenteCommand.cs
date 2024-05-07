using API.Docentes.Application.DTOs;
using API.Docentes.Domain.Entities;
using MediatR;

namespace API.Docentes.Infrastructure.Commands
{
    public record CreateDocenteCommand(
        string Identificacion,
        string TipoIdentificacion,
        string Nombres,
        string Apellidos,
        string CorreoElectronico,
        string TelefonoCelular,
        string NumeroContrato,
        int CiudadId,
        int EscalafonTecnicoId,
        int EscalafonExtensionId
    ) : IRequest<DocenteCreateDto>;
}
