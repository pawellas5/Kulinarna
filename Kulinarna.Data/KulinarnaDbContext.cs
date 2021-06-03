using Kulinarna.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Data
{
    public class KulinarnaDbContext : DbContext
    {
        public KulinarnaDbContext(DbContextOptions<KulinarnaDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
