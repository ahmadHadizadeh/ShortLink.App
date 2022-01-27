using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShortLink.Models;

namespace ShortLink.Data
{
    public class ShortLinkContext : DbContext
    {
        public ShortLinkContext (DbContextOptions<ShortLinkContext> options)
            : base(options)
        {
        }

        public DbSet<ShortLink.Models.Product> Product { get; set; }
    }
}
