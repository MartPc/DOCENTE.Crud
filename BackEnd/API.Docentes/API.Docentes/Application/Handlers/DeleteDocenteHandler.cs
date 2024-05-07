using API.Docentes.Infrastructure.Commands;
using API.Docentes.Infrastructure.Data;
using MediatR;

namespace API.Docentes.Application.Handlers
{
    public class DeleteDocenteHandler : IRequestHandler<DeleteDocenteCommand, bool>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteDocenteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteDocenteCommand request, CancellationToken cancellationToken)
        {
            var docente = await _appDbContext.Docentes.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (docente == null)
            {
                return false;
            }

            _appDbContext.Docentes.Remove(docente);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
