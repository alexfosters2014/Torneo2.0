using Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;

namespace TorneoClient.DataService
{
    public class DataServiceTorneo
    {

        private readonly HttpClient _httpClient;

        public DataServiceTorneo(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<int> CrearTorneo(Torneo torneo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/Torneo/Crear", torneo);
                if (!response.IsSuccessStatusCode)
                {
                    var contentError = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<string>(contentError);
                    throw new Exception(error);
                }

                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<int>(content);
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Partido> CrearFixtureAut(Torneo torneo)
        {
            List<Partido> partidos = new();

            switch (torneo.Modalidad)
            {
                case "ED":
                    partidos = CrearFixtureEliminacionDirecta(torneo);
                    break;
                case "DE":
                    partidos = new();
                    break;

            }
            return partidos;
        }

        private List<Partido> CrearFixtureEliminacionDirecta(Torneo torneo)
        {
            List<Partido> fixture = new();

            int cantEquipos = torneo.Inscripciones.Count;
            int cantPartidos = cantEquipos - 1;
            int cantJornadas = CantidadJornalesEDRecursivo(cantEquipos);
            int ajusteEqNoJueganPrimeraRonda = (int)Math.Pow(2, cantJornadas) - cantEquipos;

            torneo.Inscripciones.ForEach(equipo =>
            {
                Partido partido = new()
                {
                    Local = equipo,
                    Orden = 0,
                    Ronda = 0,
                    Guid = new Guid(),
                    RondaDescanso = true
                };
                fixture.Add(partido);
            });

            fixture = FixtureEDRecursivo(fixture, ajusteEqNoJueganPrimeraRonda, 1, cantJornadas);

            return fixture;
        }



        private int CantidadJornalesEDRecursivo(int cantEq, int total = 0, int jornadas = 0)
        {
            if (total > cantEq) return jornadas;

            jornadas++;
            total = (int)Math.Pow(2, jornadas);

            return CantidadJornalesEDRecursivo(cantEq, total, jornadas);
        }



        private List<Partido> FixtureEDRecursivo(List<Partido> fixture, int ajustePrimeraRonda, int rondaActual, int jornadas)
        {
            int cantPartidos = fixture.Count;
            if (rondaActual > jornadas) return fixture;

            List<Partido> auxFiltroFixture = new List<Partido>();
            List<Partido> aux = new List<Partido>();

            if (ajustePrimeraRonda > 0)
            {
                for (int i = 0; i < cantPartidos - ajustePrimeraRonda; i += 2)
                {
                    Partido partido = new Partido()
                    {
                        Local = fixture[i].Local,
                        Visitante = fixture[i + 1].Local,
                        Guid = new Guid(),
                        Ronda = rondaActual,
                        Orden = 0,
                        RondaDescanso = false
                    };
                    aux.Add(partido);
                    fixture.Remove(fixture[i]);
                    fixture.Remove(fixture[i + 1]);
                }
                fixture.ForEach(f => f.Ronda = rondaActual);
                aux.AddRange(fixture);
                rondaActual++;
                ajustePrimeraRonda = 0;

                return FixtureEDRecursivo(aux, ajustePrimeraRonda, rondaActual, jornadas);
            }

            auxFiltroFixture = fixture.Where(w => w.Ronda == rondaActual - 1).ToList();

            int cantPartidosFiltrados = auxFiltroFixture.Count;

            for (int i = 0; i < cantPartidos; i += 2)
            {
                Partido partido = new()
                {
                    Local = fixture[i].RondaDescanso ? fixture[i].Local : null,
                    Visitante = fixture[i + 1].RondaDescanso ? fixture[i + 1].Local : null,
                    Guid = Guid.NewGuid(),
                    Ronda = rondaActual,
                    RondaDescanso = false
                };
                auxFiltroFixture[i].PartidoSiguienteGuid = partido.Guid;
                auxFiltroFixture[i + 1].PartidoSiguienteGuid = partido.Guid;
                aux.Add(partido);


            }

            auxFiltroFixture.RemoveAll(r => r.RondaDescanso == true);
            auxFiltroFixture.AddRange(aux);
            rondaActual++;
            return FixtureEDRecursivo(auxFiltroFixture, 0, rondaActual, jornadas);

        }


        public async Task<List<Torneo>> GetTorneosVigentes(string nomobreTorneo)
        {
            return new List<Torneo>();
        }



    }
}
