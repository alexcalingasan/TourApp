using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Travels
{
    public class Delete
    {        
        public class Command : IRequest
        {
            public int TravelId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDataContext _context;
            public Handler(IDataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var travel = await _context.Travels.FindAsync(request.TravelId);

                if(travel == null)
                    throw new Exception("Travel not found.");

                _context.Travels.Remove(travel);

                var success = await _context.SaveChangesAsync(cancellationToken) > 0;
                if(success) return Unit.Value;

                throw new Exception("Problem removing the travel.");
            }
        }
    }
}