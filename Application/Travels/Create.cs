using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Travels
{
    public class Create
    {
        public class Command : IRequest
        {
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
                var travel = new Travel
                {
                    Title = request.Title,
                    Description = request.Description,
                    Date = request.Date,
                    Location = request.Location
                };

                _context.Travels.Add(travel);
                var success = await _context.SaveChangesAsync(cancellationToken) > 0;
                if(success) return Unit.Value;

                throw new Exception("Problem saving the travel.");
            }
        }
    }
}