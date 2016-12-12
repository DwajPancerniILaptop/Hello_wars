using HelloWarsBot.Models.Actions;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IHelloWarsBotService
    {
        BotMove CalculateNextMove();
    }
}
