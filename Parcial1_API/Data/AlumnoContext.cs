using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial1_API.Model;

namespace Parcial1_API.Data
{
    public class AlumnoContext : DbContext
    {
        public AlumnoContext (DbContextOptions<AlumnoContext> options)
            : base(options)
        {
        }

        public DbSet<Parcial1_API.Model.Alumno> Alumno { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>().HasData(
                new Alumno { ID = 1, Matricula = 2024001, Nombre = "Ana López", Edad = 20, Carrera = "Ingeniería" },
                new Alumno { ID = 2, Matricula = 2024002, Nombre = "Luis Pérez", Edad = 22, Carrera = "Derecho" },
                new Alumno { ID = 3, Matricula = 2024003, Nombre = "María Gómez", Edad = 21, Carrera = "Medicina" }
            );
        }
    }
}
