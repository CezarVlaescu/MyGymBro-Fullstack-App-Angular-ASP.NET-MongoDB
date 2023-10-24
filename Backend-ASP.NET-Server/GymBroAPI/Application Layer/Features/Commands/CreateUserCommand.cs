using Application_Layer.Interfaces;
using Domain_Layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var user = new UserEntity();
                user.First_name = command.First_name;
                user.Last_name = command.Last_name;
                user.Email = command.Email;
                user.Password = command.Password;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
