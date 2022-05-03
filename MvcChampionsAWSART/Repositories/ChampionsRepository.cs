using Microsoft.Extensions.Configuration;
using MvcChampionsAWSART.Data;
using MvcChampionsAWSART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Repositories
{
    public class ChampionsRepository
    {
        private ChampionsContext context;
        private string urlBucket;
        public ChampionsRepository(ChampionsContext context, IConfiguration configuration)
        {
            this.context = context;
            this.urlBucket = configuration.GetValue<string>("AWS:UrlBucket");
        }

        public List<Jugador> GetJugadores()
        {
            List<Jugador> jugadores = this.context.Jugadores.ToList();

            foreach (Jugador j in jugadores)
            {
                    j.Imagen = this.urlBucket + j.Imagen;
            }
            return jugadores;
        }

        public List<Equipo> GetEquipos()
        {
            List<Equipo> equipos = this.context.Equipos.ToList();
            return equipos;
        }

        private int GetMaxId()
        {
            return this.context.Jugadores.Max(x => x.Id_Jugador + 1);
        }
        public void InsertJugador( string nombre, string posicion, string imagen, int idequipo)
        {
            Jugador j = new Jugador();
            j.Id_Jugador = this.GetMaxId();
            j.Nombre = nombre;
            j.Posicion = posicion;
            j.Imagen = imagen;
            j.Id_Equipo = idequipo;
            this.context.Jugadores.Add(j);
            this.context.SaveChanges();

        }

        public List<Apuesta> GetApuestas()
        {
            List<Apuesta> apuestas = this.context.Apuestas.ToList();
            return apuestas;
        }

        private int GetMaxIdApuesta()
        {
            
            return this.context.Apuestas.Max(x => x.IdApuesta + 1);
        }
        public void InsertApuestas( string usuario, int idequipolocal, int idequipovisitante, int golesequipolocal, int golesequipovisitante)
        {
            Apuesta a = new Apuesta();
            a.IdApuesta = this.GetMaxIdApuesta();
            a.Usuario = usuario;
            a.IdEquipoLocal = idequipolocal;
            a.IdEquipoVisitante = idequipovisitante;
            a.GolesEquipoLocal = golesequipolocal;
            a.GolesEquipoVisitante = golesequipovisitante;
            this.context.Apuestas.Add(a);
            this.context.SaveChanges();
        }

    }
}
