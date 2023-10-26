using Microsoft.AspNetCore.Mvc;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

    }

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}

    /// <summary>
    /// Api to get the Card Details
    /// </summary>
    /// <param name="Names"></param>
    /// <param name="Colors"></param>
    /// <param name="Types"></param>
    /// <returns></returns>
    [Route("GetCardList")]
    [HttpPost]
    public async Task<IActionResult> GetCardList(string Names, string Colors, string Types)
    {
        try
        {
            IMtgServiceProvider serviceProvider = new MtgServiceProvider();

            ICardService service = serviceProvider.GetCardService();
            //IOperationResult<List<ICard>> result1 = await service.AllAsync();

            IOperationResult<List<ICard>> result = await service.Where(x => x.Name, Names)
                      .Where(x => x.Colors, Colors)
                      .Where(x => x.Types, Types)
                      .AllAsync();

            if (result.IsSuccess)
            {
                var value = result.Value;
            }
            else
            {
                var exception = result.Exception;
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok(Convert.ToString(ex.Message));
        }
    }
}
