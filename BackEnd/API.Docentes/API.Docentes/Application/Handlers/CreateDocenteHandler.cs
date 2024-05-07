using API.Docentes.Application.DTOs;
using API.Docentes.Domain.Entities;
using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class CreateDocenteHandler : IRequestHandler<CreateDocenteCommand, DocenteCreateDto>
    {

        private readonly AppDbContext _appDbContext;

        public CreateDocenteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DocenteCreateDto> Handle(CreateDocenteCommand request, CancellationToken cancellationToken)
        {

            var docente = new Docente
            {
                Identificacion = request.Identificacion,
                TipoIdentificacion = request.TipoIdentificacion,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                CorreoElectronico = request.CorreoElectronico,
                TelefonoCelular = request.TelefonoCelular,
                NumeroContrato = request.NumeroContrato,
                CiudadId = request.CiudadId,
                EscalafonTecnicoId = request.EscalafonTecnicoId,
                EscalafonExtensionId = request.EscalafonExtensionId
            };

            _appDbContext.Docentes.Add(docente);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new DocenteCreateDto
            {
                Identificacion = docente.Identificacion,
                TipoIdentificacion = docente.TipoIdentificacion,
                Nombres = docente.Nombres,
                Apellidos = docente.Apellidos,
                CorreoElectronico = docente.CorreoElectronico,
                TelefonoCelular = docente.TelefonoCelular,
                NumeroContrato = docente.NumeroContrato,
                CiudadId = docente.CiudadId,
                EscalafonTecnicoId = docente.EscalafonTecnicoId,
                EscalafonExtensionId = docente.EscalafonExtensionId
            };

        }
    }
}
