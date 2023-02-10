using BaseDatosContext;
using Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Validaciones
{
    public class ValidadorInscripcion : AbstractValidator<Torneo>
    {
        private readonly TorneoContext _db;
        public ValidadorInscripcion(TorneoContext _db)
        {
            this._db = _db;

            RuleFor(to => to.Inscripciones).NotNull().NotEmpty().WithMessage("No seleccionó ningun esquipo a inscribir");
            RuleFor(to => to.Id).NotNull().Must(EquipoNoInscripto).WithMessage("El equipo ya está inscripto en el Torneo seleccionado");
        }

        private bool EquipoNoInscripto(Torneo torneo, int id)
        {
            return !_db.Torneos.Any(to => to.Id == id && to.Inscripciones.Any( eq => eq.Id == torneo.Inscripciones[0].Id));
        }
    }
}
