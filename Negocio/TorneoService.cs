using BaseDatosContext;
using Entidades;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Negocio.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TorneoService
    {
        private readonly TorneoContext _db;
        public TorneoService(TorneoContext db)
        {
            _db = db;
        }

        public async Task<List<Torneo>> GetTorneosDeporteInscripcion(string deporte)
        {
            return _db.Torneos.Include(i => i.Inscripciones)
                              .Where(t => t.Deporte== deporte).ToList();
        }

        public async Task<string> InscribirEquipo(Torneo torneo)
        {
            try
            {
                string mensajeError = "";

                ValidadorInscripcion validacion = new(_db);
                ValidationResult result = validacion.Validate(torneo);
                if (!result.IsValid)
                {
                    result.Errors.ForEach(f => mensajeError += f.ErrorMessage);
                    throw new Exception(mensajeError);
                }

                var torneoDB = await _db.Torneos.Include(i => i.Inscripciones)
                                                .SingleOrDefaultAsync(s=> s.Id == torneo.Id);

                if (torneoDB == null) throw new Exception("no existe el torneo seleccionado");

                torneoDB.Inscripciones.Add(torneo.Inscripciones[0]);
                await _db.SaveChangesAsync();
                return "Felicidades, se ha inscripto satisfactoriamente al torneo " + torneoDB.Nombre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
