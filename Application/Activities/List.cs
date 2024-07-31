using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    //En caso que desde cliente se cancele la solicitud, se cierre navegador o algun corte de conexion
                    cancellationToken.ThrowIfCancellationRequested();
                    
                }
                catch (System.Exception)
                {
                    _logger.LogInformation("Request was canceled");
                }
                return await _context.Activities.ToListAsync();
            }
        }
    }
}