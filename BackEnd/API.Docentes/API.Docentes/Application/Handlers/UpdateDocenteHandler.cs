using API.Docentes.Application.DTOs;
using API.Docentes.Domain.Entities;
using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class UpdateDocenteHandler : IRequestHandler<UpdateDocenteCommand, DocenteUpdateDto>
    {

        private readonly AppDbContext _appDbContext;

        public UpdateDocenteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<DocenteUpdateDto> Handle(UpdateDocenteCommand request, CancellationToken cancellationToken)
        {
            var docente = await _appDbContext.Docentes.FindAsync(
                new object[] { request.Id }, cancellationToken);


            if (docente == null)
            {
                return null;
            }

            docente.Identificacion = request.Identificacion;
            docente.TipoIdentificacion = request.TipoIdentificacion;
            docente.Nombres = request.Nombres;
            docente.Apellidos = request.Apellidos;
            docente.CorreoElectronico = request.CorreoElectronico;
            docente.TelefonoCelular = request.TelefonoCelular;
            docente.NumeroContrato = request.NumeroContrato;
            docente.CiudadId = request.CiudadId;
            docente.EscalafonTecnicoId = request.EscalafonTecnicoId;
            docente.EscalafonExtensionId = request.EscalafonExtensionId;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            var docentes = await _appDbContext.Docentes
            .Include(d => d.EscalafonTecnico)
            .ToListAsync(cancellationToken);

            return new DocenteUpdateDto
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
