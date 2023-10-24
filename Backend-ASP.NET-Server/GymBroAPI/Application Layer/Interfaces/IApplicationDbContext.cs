using Domain_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        Task<int> SaveChangesAsync();
        Task DeleteChangesAsync();
    }
}
