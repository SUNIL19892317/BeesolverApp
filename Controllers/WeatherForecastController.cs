using Microsoft.AspNetCore.Mvc;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MyApi.Model;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api/[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ICardsService _cardsService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICardsService cardsService)
    {
        _logger = logger;
        _cardsService = cardsService;
    }

    
    /// <summary>
    /// API to get the Cards List
    /// </summary>
    /// <param name="Names"></param>
    /// <param name="Colors"></param>
    /// <param name="Types"></param>
    /// <returns></returns>
    [Route("GetCardsList")]
    [HttpPost]
    public async Task<IActionResult> GetCardsList(string Names, string Colors, string Types)
    {
        try
        {
            CardModel cardModel = new CardModel();
            cardModel.Names = Names;
            cardModel.Colors = Colors;
            cardModel.Types = Types;
            IOperationResult<List<ICard>> result = await _cardsService.GetCardsList(cardModel);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return Ok(result.Exception);
            }
            
        }
        catch (Exception ex)
        {
            return Ok(Convert.ToString(ex.Message));
        }
    }
}
