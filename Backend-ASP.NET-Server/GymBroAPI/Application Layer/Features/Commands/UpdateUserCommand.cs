using Application_Layer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.Id == command.Id).FirstOrDefault();
                if (user == null) return default;
                else
                {
                    user.First_name = command.First_name;
                    user.Last_name = command.Last_name;
                    user.Email = command.Email;
                    user.Password = command.Password;

                    await _context.SaveChangesAsync();
                    return user.Id;
                }
            }
        }
    }
}
