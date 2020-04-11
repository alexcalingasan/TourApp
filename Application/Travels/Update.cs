using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Travels
{
    public class Update
    {        
        public class Command : IRequest
        {
            public int TravelId { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
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

                travel.Title = request.Title;
                travel.Date = request.Date;
                travel.Location = request.Location;
                travel.Description = request.Description;

                var success = await _context.SaveChangesAsync(cancellationToken) > 0;
                if(success) return Unit.Value;

                throw new Exception("Problem saving the travel.");
            }
        }
    }
}