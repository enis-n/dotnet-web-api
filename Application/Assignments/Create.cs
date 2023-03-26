using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Assignments
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Assignment Assignment { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Assignment).SetValidator(new AssignmentValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(
                        x => x.UserName == _userAccessor.GetUserName());

                var attendee = new AssignmentAttendee
                {
                    AppUser = user,
                    Assignment = request.Assignment,
                    IsHost = true
                };

                request.Assignment.Attendees.Add(attendee);

                _context.Assignments.Add(request.Assignment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create assignment");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}