using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.State;
using HelloWarsBot.Models.Algorithm;

namespace HelloWarsBot.BusinessLogic
{
    public class BlastRadiusHelper : IBlastRadiusHelper
    {
        private BotArenaInfo _arenaInfo;
        private AlgorithmParameter _algorithmParameter;

        public void Initialize(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter)
        {
            _arenaInfo = arenaInfo;
        }

        public List<LocationPoint> CalculateBombRadius(Point point)
        {
            throw new System.NotImplementedException();
        }

        public List<LocationPoint> CalculateMissileRadius(Point point)
        {
            throw new System.NotImplementedException();
        }
    }
}