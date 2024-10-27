using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sabados_Dan_Lab2.Models;

namespace Sabados_Dan_Lab2.Data
{
    public class Sabados_Dan_Lab2Context : DbContext
    {
        public Sabados_Dan_Lab2Context (DbContextOptions<Sabados_Dan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sabados_Dan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Sabados_Dan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Sabados_Dan_Lab2.Models.Author> Authors { get; set; } = default;
        public DbSet<Sabados_Dan_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
