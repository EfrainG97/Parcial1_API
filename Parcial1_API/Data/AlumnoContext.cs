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
                new Alumno { ID = 3, Matricula = 2024003, Nombre = "María Gómez", Edad = 21, Carrera = "Medicina" },
                new Alumno { ID = 4, Matricula = 2024004, Nombre = "Carlos Ruiz", Edad = 23, Carrera = "Arquitectura" },
                new Alumno { ID = 5, Matricula = 2024005, Nombre = "Sofía Torres", Edad = 19, Carrera = "Psicología" },
                new Alumno { ID = 6, Matricula = 2024006, Nombre = "Jorge Díaz", Edad = 24, Carrera = "Contaduría" },
                new Alumno { ID = 7, Matricula = 2024007, Nombre = "Valeria Ramos", Edad = 20, Carrera = "Informática" },
                new Alumno { ID = 8, Matricula = 2024008, Nombre = "Miguel Sánchez", Edad = 22, Carrera = "Administración" },
                new Alumno { ID = 9, Matricula = 2024009, Nombre = "Lucía Navarro", Edad = 21, Carrera = "Biología" },
                new Alumno { ID = 10, Matricula = 2024010, Nombre = "Daniel Herrera", Edad = 23, Carrera = "Economía" }
            );
        }
    }
}
