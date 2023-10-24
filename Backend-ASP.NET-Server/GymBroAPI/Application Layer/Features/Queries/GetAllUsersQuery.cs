using Application_Layer.Interfaces;
using Domain_Layer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserEntity>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllUsersQueryHandler(IApplicationDbContext context) 
            {
                _context = context;
            }

            public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var usersList = await _context.Users.ToListAsync(cancellationToken);
                if (usersList == null) return null;
                return usersList.AsReadOnly();
            }
        }
    }
}
