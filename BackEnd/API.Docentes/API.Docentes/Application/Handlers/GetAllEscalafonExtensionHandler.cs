using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class GetAllEscalafonExtensionHandler : IRequestHandler<GetAllEscalafonExtensionQuery, IEnumerable<EscalafonExtensionDto>>
    {

        private readonly AppDbContext _appDbContext;

        public GetAllEscalafonExtensionHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<EscalafonExtensionDto>> Handle(GetAllEscalafonExtensionQuery request, CancellationToken cancellationToken)
        {
            var escalafonExtensiones = await _appDbContext.EscalafonExtensiones
            .ToListAsync(cancellationToken);

            return escalafonExtensiones.Select(escalafonExtension => new EscalafonExtensionDto
            {
                Id = escalafonExtension.Id,
                Nombre = escalafonExtension.Nombre,
                Estado = escalafonExtension.Estado
            });
        }
    }
}
