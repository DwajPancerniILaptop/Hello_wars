using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.BotInfo;

namespace HelloWarsBot.BusinessLogic
{
    public class BlastRadiusHelper : IBlastRadiusHelper
    {
        private BotInfo _arenaInfo;

        public void Initialize(BotInfo arenaInfo)
        {
            _arenaInfo = arenaInfo;
        }

        public List<Point> CalculateRadius(Point point)
        {
            throw new System.NotImplementedException();
        }
    }
}