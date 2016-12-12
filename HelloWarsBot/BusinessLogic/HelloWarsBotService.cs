using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic
{
    public class HelloWarsBotService : IHelloWarsBotService
    {
        public BotMove CalculateNextMove(BotArenaInfo arenaInfo)
        {
            return new BotMove();
        }
    }
}
