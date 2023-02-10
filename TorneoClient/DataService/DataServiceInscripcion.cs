using Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace TorneoClient.DataService
{
    public class DataServiceInscripcion
    {
        private readonly HttpClient _httpClient;

        public DataServiceInscripcion(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<List<Torneo>> GetTorneosSegunDeporte(string deporte)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/Torneo/Get/{deporte}");
                if (!response.IsSuccessStatusCode)
                {
                    var contentError = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<string>(contentError);
                    throw new Exception(error);
                }

                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject <List<Torneo>> (content);
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> NuevaInscripcionATorneo(Torneo torneo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/Torneo/Inscripcion", torneo);
                if (!response.IsSuccessStatusCode)
                {
                    var contentError = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<string>(contentError);
                    throw new Exception(error);
                }

                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<string>(content);
                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
