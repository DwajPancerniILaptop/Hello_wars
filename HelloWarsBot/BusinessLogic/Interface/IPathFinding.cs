using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.Algorithm;
using System.Drawing;

namespace HelloWarsBot.BusinessLogic.Interface
{
    public interface IPathFinding
    {
        MoveDirection? CalculatePath(Point startPoint, Point endPoint, AllyMapPoint[,] map, ILocationHelper locationHelper);
    }
}