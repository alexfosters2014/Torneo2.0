using BaseDatosContext;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EquiposService
    {
        private readonly TorneoContext _db;
        public EquiposService(TorneoContext _db)
        {
            this._db = _db;
        }

        public Task<Equipo> GetEquipo(int id)
        {

        }

    }
}
