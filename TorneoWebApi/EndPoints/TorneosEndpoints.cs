using Entidades;
using Negocio;

namespace TorneoWebApi.EndPoints
{
    public static class TorneosEndpoints
    {
        public static void MapTorneosEndpoints(this WebApplication app)
        {
            app.MapGet("/Torneo/Get/{deporte}", GetTorneoDeporte);
            app.MapPost("/Torneo/Inscripcion", InscribirEquipoATorneo);
            app.MapPost("/Torneo/Crear", CrearTorneo);
        }

        public static async Task<IResult> GetTorneoDeporte(TorneoService torneoService, string deporte)
        {
            try
            {
                var resultado = await torneoService.GetTorneosDeporteInscripcion(deporte);
                if (resultado == null) return Results.BadRequest("El torneo no está ingresado en el sistema");

                return Results.Ok(resultado);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public static async Task<IResult> InscribirEquipoATorneo(TorneoService torneoService, Torneo torneo)
        {
            try
            {
                var resultado = await torneoService.InscribirEquipo(torneo);
                if (resultado == null) return Results.BadRequest("El torneo no está ingresado en el sistema");

                return Results.Ok(resultado);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public static async Task<IResult> CrearTorneo(TorneoService torneoService, Torneo torneo)
        {
            try
            {
                var resultado = await torneoService.CrearTorneo(torneo);
                if (resultado == null) return Results.BadRequest("El torneo no se ha podido crear");

                return Results.Ok(resultado);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

    }
}
