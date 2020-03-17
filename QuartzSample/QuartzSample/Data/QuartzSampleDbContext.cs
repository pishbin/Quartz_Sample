using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuartzSample.Models;

namespace QuartzSample.Data
{
    public class QuartzSampleDbContext : DbContext
    {
        public QuartzSampleDbContext (DbContextOptions<QuartzSampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
