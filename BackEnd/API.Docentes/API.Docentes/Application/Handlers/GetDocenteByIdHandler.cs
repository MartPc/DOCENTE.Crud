using API.Docentes.Application.DTOs;
using API.Docentes.Domain.Entities;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class GetDocenteByIdHandler : IRequestHandler<GetDocenteByIdQuery, DocenteDto>
    {

        private readonly AppDbContext _appDbContext;

        public GetDocenteByIdHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DocenteDto> Handle(GetDocenteByIdQuery request, CancellationToken cancellationToken)
        {

            var docente = await _appDbContext.Docentes
                .Include(d => d.Ciudad)
                .Include(t => t.EscalafonTecnico)
                .Include(e => e.EscalafonExtension)
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (docente == null)
            {
                return null;
            }

            return new DocenteDto
            {
                Id = docente.Id,
                Identificacion = docente.Identificacion,
                TipoIdentificacion = docente.TipoIdentificacion,
                Nombres = docente.Nombres,
                Apellidos = docente.Apellidos,
                CorreoElectronico = docente.CorreoElectronico,
                TelefonoCelular = docente.TelefonoCelular,
                NumeroContrato = docente.NumeroContrato,
                Ciudad = new CiudadDto
                {
                    Id = docente.CiudadId,
                    Nombre = docente.Ciudad.Nombre,
                    Estado = docente.Ciudad.Estado
                },
                EscalafonTecnico = new EscalafonTecnicoDto
                {
                    Id = docente.EscalafonTecnicoId,
                    Nombre = docente.EscalafonTecnico.Nombre,
                    Estado = docente.EscalafonTecnico.Estado
                },
                EscalafonExtension = new EscalafonExtensionDto
                {
                    Id = docente.EscalafonExtensionId,
                    Nombre = docente.EscalafonExtension.Nombre,
                    Estado = docente.EscalafonExtension.Estado
                }
            };
        }
    }
}
