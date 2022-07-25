using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kurs_final.Models;

namespace Kurs_final.Data
{
    public class Kurs_finalContext : DbContext
    {
        public Kurs_finalContext (DbContextOptions<Kurs_finalContext> options)
            : base(options)
        {
        }

        public DbSet<Kurs_final.Models.Patient> Patient { get; set; }

        public DbSet<Kurs_final.Models.Doctor> Doctor { get; set; }
    }
}
