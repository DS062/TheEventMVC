using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEvent.Models;
using Microsoft.EntityFrameworkCore;

namespace TheEvent.Data
{
    public class TheEventContext : DbContext
    {
        public TheEventContext (DbContextOptions<TheEventContext> options)
            : base(options)
        {
        }

        public DbSet<Schedules> Schedules { get; set; }

        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Speakers> Speakers { get; set; }
    }
}
