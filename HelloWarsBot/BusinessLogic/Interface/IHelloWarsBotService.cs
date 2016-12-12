using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IHelloWarsBotService
    {
        BotMove CalculateNextMove(BotArenaInfo arenaInfo);
    }
}
