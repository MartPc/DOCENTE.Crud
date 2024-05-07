using API.Docentes.Application.DTOs;
using API.Docentes.Infrastructure.Data;
using API.Docentes.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace API.Docentes.Application.Handlers
{
    public class GetAllCiudadHandler : IRequestHandler<GetAllCiudadQuery, IEnumerable<CiudadDto>>
    {

        private readonly AppDbContext _appDbContext;

        public GetAllCiudadHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<CiudadDto>> Handle(GetAllCiudadQuery request, CancellationToken cancellationToken)
        {
            var ciudades = await _appDbContext.Ciudades
                .ToListAsync(cancellationToken);

            return ciudades.Select(ciudad => new CiudadDto
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                Estado = ciudad.Estado,
            });

        }
    }
}
