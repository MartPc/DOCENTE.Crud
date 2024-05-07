using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Docentes.Application.Handlers
{
    public class GetEscalafonTecnicoByIdHandler : IRequestHandler<GetEscalafonTecnicoByIdQuery, EscalafonTecnicoDto>
    {

        private readonly AppDbContext _appDbContext;

        public GetEscalafonTecnicoByIdHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EscalafonTecnicoDto> Handle(GetEscalafonTecnicoByIdQuery request, CancellationToken cancellationToken)
        {
            var escalafon = await _appDbContext.EscalafonTecnicos
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

            if (escalafon == null)
            {
                return null;
            }

            return new EscalafonTecnicoDto
            {
                Id = escalafon.Id,
                Nombre = escalafon.Nombre,
                Estado = escalafon.Estado,
            };
        }
    }
}
