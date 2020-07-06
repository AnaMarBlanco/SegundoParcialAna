using Microsoft.EntityFrameworkCore;
using SegundoPacialAna.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoPacialAna.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<TareasDetalle> TareasDetalle { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATA/Database.db");
        }
    }
}
