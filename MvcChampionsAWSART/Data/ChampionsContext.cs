using Microsoft.EntityFrameworkCore;
using MvcChampionsAWSART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Data
{
    public class ChampionsContext:DbContext
    {
        public ChampionsContext(DbContextOptions<ChampionsContext> options) : base(options) { }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Apuesta> Apuestas { get; set; }
    }
}
