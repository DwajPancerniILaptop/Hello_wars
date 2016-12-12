using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.Models.BotInfo;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IBlastRadiusHelper
    {
        void Initialize(BotInfo arenaInfo);

        List<Point> CalculateRadius(Point point);
    };
}
