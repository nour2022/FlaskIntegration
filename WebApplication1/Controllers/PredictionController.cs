using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PredictionController : Controller
    {
        private readonly FlaskApiService _flaskApiService;

        public PredictionController(FlaskApiService flaskApiService)
        {
            _flaskApiService = flaskApiService;
        }

        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] PredictionRequest request)
        {
            var prediction = await _flaskApiService.GetPredictionAsync(request.Request);
            return Ok(new PredictionResponse(prediction));
        }
    }
}
