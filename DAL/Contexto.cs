using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoPacialAna.DAL
{
    class Contexto : DbContext
    {
        //por donde enviaron eso?
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATA/Database.db");
        }
    }
}
