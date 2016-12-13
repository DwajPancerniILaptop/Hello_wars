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

        List<Point> GetNeighbours(int x, int y);

        int GetStreightLine(Point point);

        int GetStreightLine(int x, int y);

        int GetPointForCloseToSideOfMap(int x, int y);

        int GetPointForDistanceToEnemy(int x, int y);

        int GetPointForNeighborTiles(int x, int y);
    }
}
