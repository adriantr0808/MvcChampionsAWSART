using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcChampionsAWSART.Models
{
    [Table("JUGADORES")]
    public class Jugador
    {
        [Key]
        [Column("IDJUGADOR")]
        public int Id_Jugador { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("POSICION")]
        public string Posicion { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("IDEQUIPO")]
        public int Id_Equipo { get; set; }
    }
}
