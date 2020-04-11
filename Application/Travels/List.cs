using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Travels
{
    public class List
    {
        public class Query : IRequest<List<Travel>> { }

        public class Handler : IRequestHandler<Query, List<Travel>>
        {
            private readonly IDataContext _context;
            public Handler(IDataContext context)
            {
                _context = context;
            }
            public async Task<List<Travel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var travels = await _context.Travels.ToListAsync();
                return travels;
            }
        }
    }
}