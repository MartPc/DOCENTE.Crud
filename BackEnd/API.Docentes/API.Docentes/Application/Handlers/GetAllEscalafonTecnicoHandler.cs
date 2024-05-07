using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{

    public class GetAllEscalafonTecnicoHandler : IRequestHandler<GetAllEscalafonTecnicoQuery, IEnumerable<EscalafonTecnicoDto>>
    {

        private readonly AppDbContext _appDbContext;

        public GetAllEscalafonTecnicoHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<EscalafonTecnicoDto>> Handle(GetAllEscalafonTecnicoQuery request, CancellationToken cancellationToken)
        {
            var escalafonTecnicos = await _appDbContext.EscalafonTecnicos
            .ToListAsync(cancellationToken);

            return escalafonTecnicos.Select(escalafonTecnico => new EscalafonTecnicoDto
            {
                Id = escalafonTecnico.Id,
                Nombre = escalafonTecnico.Nombre,
                Estado = escalafonTecnico.Estado
            });
        }
    }
}
