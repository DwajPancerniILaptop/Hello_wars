using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.State;
using HelloWarsBot.Models.Algorithm;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace HelloWarsBot.BusinessLogic
{
    public class LocationHelper : ILocationHelper
    {
        private BotArenaInfo _arenaInfo;
        private AlgorithmParameter _algorithmParameter;

        public void Initialize(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter)
        {
            _arenaInfo = arenaInfo;
            _algorithmParameter = algorithmParameter;
        }

        public int GetPointsForBoardTile(int x, int y)
        {
            var boardTile = _arenaInfo.Board[x, y];

            switch (boardTile)
            {
                case BoardTile.Empty:
                    return 0;
                case BoardTile.Fortified:
                    return _algorithmParameter.BoardTilePoints;
                case BoardTile.Regular:
                    return _algorithmParameter.BoardTilePoints;
                case BoardTile.Indestructible:
                    return _algorithmParameter.BoardTilePoints;
            }

            return 0;
        }

        public List<Point> GetNeighbours(Point point)
        {
            List<Point> list = new List<Point>();
            if (point.X > 0)
            {
                list.Add(new Point(point.X - 1, point.Y));
            }
            if (point.Y < _arenaInfo.GameConfig.MapHeight-1)
            {
                list.Add(new Point(point.X, point.Y + 1));
            }
            if (point.X < _arenaInfo.GameConfig.MapWidth - 1)
            {
                list.Add(new Point(point.X + 1, point.Y));
            }
            if (point.Y > 0)
            {
                list.Add(new Point(point.X, point.Y - 1));
            }

            return list;
        }

        public int GetStreightLine(Point point)
        {
            return Math.Abs(_arenaInfo.OpponentLocations[0].X - point.X) + Math.Abs(_arenaInfo.OpponentLocations[0].Y - point.Y);
        }
    }
}