namespace WebApplication1.Models
{
    public class PredictionResponse
    {
        public string Response { get; set; }
        public PredictionResponse(string responce)
        {
            Response = responce;
        }
    }
}
