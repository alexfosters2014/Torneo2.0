using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torneo
    {
        public int Id { get; set; }
        public List<Equipo> Inscripciones { get; set; } = new();
        public List<Partido> Fixture { get; set; } = new();
        public string Modalidad { get; set; } = null!;
        public int SetsMax { get; set; }
        public int PuntajeMax { get; set; }
        public string Lugar { get; set; } = null!;
    }
}
