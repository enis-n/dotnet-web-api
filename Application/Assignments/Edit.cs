using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Assignments
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Assignment Assignment { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var assignment = await _context.Assignments.FindAsync(request.Assignment.Id);

                _mapper.Map(request.Assignment, assignment);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}