using MFIHub.Infra.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFIHub.Infra.Data.Context
{
    public class MFIHubContext : IdentityDbContext<User>
    {
        public DbSet<Topic>? Topics { get; set; }
        public MFIHubContext(DbContextOptions options) : base(options)
        {
        }

        protected MFIHubContext()
        {
        }
    }
}
