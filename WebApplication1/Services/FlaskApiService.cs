using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FlaskApiService
    {
        private readonly HttpClient _httpClient;
        public FlaskApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<string> GetPredictionAsync(List<string> request)
        {
          
            var predictionRequest = new PredictionRequest { Request = request };
            //              "/predict" is the flask api
            var response = await _httpClient.PostAsJsonAsync("/predict", predictionRequest);
            response.EnsureSuccessStatusCode();

            var predictionResponse = await response.Content.ReadFromJsonAsync<PredictionResponse>();
            return predictionResponse.Response;
        }
    }
}
