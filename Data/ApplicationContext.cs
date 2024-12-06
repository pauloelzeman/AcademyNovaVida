using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcademyNovaVida.Models;

namespace AcademyNovaVida.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<AcademyNovaVida.Models.Professor> Professor { get; set; } = default!;
        public DbSet<AcademyNovaVida.Models.Aluno> Aluno { get; set; } = default!;
    }
}
