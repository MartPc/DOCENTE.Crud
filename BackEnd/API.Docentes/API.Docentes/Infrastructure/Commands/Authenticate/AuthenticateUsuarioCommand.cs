using API.Docentes.Application.DTOs;
using ApplicationLayer.DTOs;
using MediatR;

namespace API.Docentes.Infrastructure.Commands.Authenticate
{
    public record AuthenticateUsuarioCommand(
        string NombreUsuario,
        string Contrasena
        ) : IRequest<ServiceResponse>;

}
