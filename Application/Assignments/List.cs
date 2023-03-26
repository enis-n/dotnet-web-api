using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Assignments
{
    public class List
    {
        public class Query : IRequest<Result<List<AssignmentDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<AssignmentDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AssignmentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var assignment = await _context.Assignments
                    .ProjectTo<AssignmentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<AssignmentDto>>.Success(assignment);
            }
        }
    }
}