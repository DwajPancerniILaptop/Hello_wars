using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.Models.State;
using HelloWarsBot.Models.Algorithm;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IBlastRadiusHelper
    {
        void Initialize(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter);

        List<LocationPoint> CalculateBombRadius(Point point);

        List<LocationPoint> CalculateMissileRadius(Point point);
    };
}
