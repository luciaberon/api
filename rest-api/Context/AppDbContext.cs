using Microsoft.EntityFrameworkCore;
using rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)           
        {
            
        }

        public DbSet<History> History { get; set; }
    }
}
