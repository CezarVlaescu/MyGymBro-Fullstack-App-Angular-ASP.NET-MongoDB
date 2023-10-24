using Application_Layer.Interfaces;
using Domain_Layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Queries
{
    public class GetUserByIdQuery : IRequest<UserEntity>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
        {
            private readonly IApplicationDbContext _context;

            public GetUserByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }  
            
            public async Task<UserEntity> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.Id == query.Id).FirstOrDefault();
                if (user == null) return null;
                else return user;
            }
        }
    }
}
