using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class GetAllDocenteHandler : IRequestHandler<GetAllDocenteQuery, IEnumerable<DocenteGetAllDto>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllDocenteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<DocenteGetAllDto>> Handle(GetAllDocenteQuery request, CancellationToken cancellationToken)
        {
            var docenteDtos = await (from docente in _appDbContext.Docentes
                                     join ciudad in _appDbContext.Ciudades on docente.CiudadId equals ciudad.Id
                                     join escalafonTecnico in _appDbContext.EscalafonTecnicos on docente.EscalafonTecnicoId equals escalafonTecnico.Id into escalafonTecnicoLeft
                                     from escalafonTecnico in escalafonTecnicoLeft.DefaultIfEmpty()
                                     join escalafonExtension in _appDbContext.EscalafonExtensiones on docente.EscalafonExtensionId equals escalafonExtension.Id into escalafonExtensionLeft
                                     from escalafonExtension in escalafonExtensionLeft.DefaultIfEmpty()
                                     select new DocenteGetAllDto
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
                                             Id = ciudad.Id,
                                             Nombre = ciudad.Nombre,
                                             Estado = ciudad.Estado
                                         },
                                         EscalafonTecnico = new EscalafonTecnicoDto
                                         {
                                             Id = escalafonTecnico.Id,
                                             Nombre = escalafonTecnico.Nombre,
                                             Estado = escalafonTecnico.Estado
                                         },
                                         EscalafonExtension = new EscalafonExtensionDto
                                         {
                                             Id = escalafonExtension.Id,
                                             Nombre = escalafonExtension.Nombre,
                                             Estado = escalafonExtension.Estado
                                         }
                                     }).ToListAsync(cancellationToken);

            return docenteDtos;
        }
    }
}