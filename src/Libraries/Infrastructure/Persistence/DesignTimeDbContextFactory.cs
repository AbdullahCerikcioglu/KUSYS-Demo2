using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfDbContext>
    {
        public EfDbContext CreateDbContext(string[] args)
        {       

            DbContextOptionsBuilder<EfDbContext> dbContext = new();
            dbContext.UseSqlServer(Configuration.ConnectionString);
            return new(dbContext.Options);
        }
    }
}
