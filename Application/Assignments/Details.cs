using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Assignments;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<AssignmentDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AssignmentDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<AssignmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var assignment = await _context.Assignments
                    .ProjectTo<AssignmentDto>(_mapper.ConfigurationProvider,
                        new { currentUsername = _userAccessor.GetUserName() })
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<AssignmentDto>.Success(assignment);
            }
        }
    }
}