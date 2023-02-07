using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; } = null!;
        public string Caratula { get; set; } = null!;
        public List<Jugador> Jugadores { get; set; } = new();
        public string Deporte { get; set; } = null!;
        public List<Torneo> Torneos { get; set; }
    }
}
