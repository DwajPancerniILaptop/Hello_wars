using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IBlastRadiusHelper
    {
        void Initialize(BotArenaInfo arenaInfo);

        List<Point> CalculateBombRadius(Point point);

        List<Point> CalculateMissileRadius(Point point);
    };
}
