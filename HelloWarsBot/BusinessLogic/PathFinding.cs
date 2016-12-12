using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.Algorithm;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HelloWarsBot.BusinessLogic
{
    public class PathFinding : IPathFinding
    {
        public MoveDirection? CalculatePath(Point startPoint, Point endPoint, AllyMapPoint[,] map, ILocationHelper locationHelper)
        {
            List<Point> closestSet = new List<Point>();
            List<Point> openSet = new List<Point>();
            openSet.Add(startPoint);

            Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();

            Dictionary<Point, int> gScore = new Dictionary<Point, int>();
            Dictionary<Point, int> fScore = new Dictionary<Point, int>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    gScore.Add(new Point(i, j), 100000000);
                    fScore.Add(new Point(i, j), 100000000);
                }
            }

            gScore[startPoint] = 0;
            fScore[startPoint] = locationHelper.GetStreightLine(startPoint);

            while (openSet.Any())
            {
                var current = openSet.OrderBy(s => fScore[s]).First();
                if (current == endPoint)
                {
                    return returnPath(current, cameFrom);
                }
                openSet.Remove(current);
                closestSet.Add(current);

                foreach (Point neighbor in locationHelper.GetNeighbours(current))
                {
                    if (closestSet.Contains(neighbor))
                    {
                        continue;
                    }

                    if (map[neighbor.X, neighbor.Y].Result >= 1000)
                    {
                        continue;
                    }

                    var temp_distance = gScore[current] + map[neighbor.X, neighbor.Y].Result;
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                    else if (temp_distance >= gScore[neighbor])
                    {
                        continue;
                    }

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = temp_distance;
                    fScore[neighbor] = gScore[neighbor] + locationHelper.GetStreightLine(neighbor);
                }
            }

            return null;
        }

        private MoveDirection? returnPath(Point current, Dictionary<Point, Point> cameFrom)
        {
            Point nextMove = new Point();
            while (cameFrom.ContainsKey(current))
            {
                nextMove = current;
                current = cameFrom[current];
            }

            if (nextMove.X > current.X)
            {
                return MoveDirection.Right;
            }
            else if (nextMove.X < current.X)
            {
                return MoveDirection.Left;
            }
            else
            {
                if (nextMove.Y > current.Y)
                {
                    return MoveDirection.Down;
                }
                else if (nextMove.Y < current.Y)
                {
                    return MoveDirection.Up;
                }
            }

            return null;
        }
    }
}