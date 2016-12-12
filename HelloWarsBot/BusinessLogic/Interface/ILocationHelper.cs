using HelloWarsBot.Models.State;
using HelloWarsBot.Models.Algorithm;
using System.Drawing;
using System.Collections.Generic;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface ILocationHelper
    {
        void Initialize(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter);

        int GetPointsForBoardTile(int x,int y);

        List<Point> GetNeighbours(Point point);

        int GetStreightLine(Point point);
    }
}
