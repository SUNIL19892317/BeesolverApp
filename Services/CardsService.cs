using Microsoft.AspNetCore.Mvc;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MyApi.Model;

namespace MyApi.Services
{
    public class CardsService : ICardsService
    {
        /// <summary>
        /// This Function is used to Get the Cards List using Api
        /// </summary>
        /// <param name="cardModel"></param>
        /// <returns></returns>
        public async Task<IOperationResult<List<ICard>>> GetCardsList(CardModel cardModel) 
        {
            IMtgServiceProvider serviceProvider = new MtgServiceProvider();
            ICardService service = serviceProvider.GetCardService();
            //IOperationResult<List<ICard>> result1 = await service.AllAsync();
            IOperationResult<List<ICard>> result = await service.Where(x => x.Name, cardModel.Names)
                      .Where(x => x.Colors, cardModel.Colors)
                      .Where(x => x.Types, cardModel.Types)
                      .AllAsync();
            return result;
        }
    }
}
