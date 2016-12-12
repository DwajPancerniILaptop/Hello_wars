using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic
{
    public class LocationHelper : ILocationHelper
    {
        private BotArenaInfo _arenaInfo;

        public void Initialize(BotArenaInfo arenaInfo)
        {
            _arenaInfo = arenaInfo;
        }
    }
}