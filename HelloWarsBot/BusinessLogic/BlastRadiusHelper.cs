using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic
{
    public class BlastRadiusHelper : IBlastRadiusHelper
    {
        private BotArenaInfo _arenaInfo;

        public void Initialize(BotArenaInfo arenaInfo)
        {
            _arenaInfo = arenaInfo;
        }

        public List<Point> CalculateBombRadius(Point point)
        {
            throw new System.NotImplementedException();
        }

        public List<Point> CalculateMissileRadius(Point point)
        {
            throw new System.NotImplementedException();
        }
    }
}