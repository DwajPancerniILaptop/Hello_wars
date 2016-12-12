using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.BotInfo;

namespace HelloWarsBot.BusinessLogic
{
    public class LocationHelper : ILocationHelper
    {
        private BotInfo _arenaInfo;

        public void Initialize(BotInfo arenaInfo)
        {
            _arenaInfo = arenaInfo;
        }
    }
}