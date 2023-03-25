using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Assignments
{
    public class List
    {
        public class Query : IRequest<Result<List<Assignment>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Assignment>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Assignment>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Assignment>>.Success(await _context.Assignments.ToListAsync(cancellationToken));
            }
        }
    }
}