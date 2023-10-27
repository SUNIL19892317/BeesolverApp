using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MyApi.Model;

namespace MyApi.Services
{
    public interface ICardsService
    {
        public Task<IOperationResult<List<ICard>>> GetCardsList(CardModel cardModel);
    }
}
