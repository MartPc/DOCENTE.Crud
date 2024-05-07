using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Commands.Authenticate;
using API.Docentes.Infrastructure.Data;
using ApplicationLayer.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers.Authenticate
{
    public class AuthenticateUsuarioHandler : IRequestHandler<AuthenticateUsuarioCommand, ServiceResponse>
    {
        private readonly AppDbContext _appDbContext;

        public AuthenticateUsuarioHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<ServiceResponse> Handle(AuthenticateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario);

            if (usuario == null)
            {
                return null;
            }

            if (request.Contrasena != usuario.Contrasena)
            {
                return null;
            }


            return new ServiceResponse(true, "Sesión Iniciada");
        }
    }
}