using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Travels
{
    public class Details
    {        
        public class Query : IRequest<Travel>
        {
            public int TravelId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Travel>
        {
            private readonly IDataContext _context;
            public Handler(IDataContext context)
            {
                _context = context;
            }
            public async Task<Travel> Handle(Query request, CancellationToken cancellationToken)
            {
                var travel = await _context.Travels.FindAsync(request.TravelId);

                if(travel == null)
                    throw new Exception("Travel not found.");

                return travel;
            }
        }
    }
}