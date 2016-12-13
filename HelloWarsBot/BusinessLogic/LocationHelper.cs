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
            return GetNeighbours(point.X, point.Y);
        }

        public List<Point> GetNeighbours(int x ,int y)
        {
            List<Point> list = new List<Point>();
            if (x > 0)
            {
                list.Add(new Point(x- 1, y));
            }
            if (y < _arenaInfo.GameConfig.MapHeight - 1)
            {
                list.Add(new Point(x, y + 1));
            }
            if (x < _arenaInfo.GameConfig.MapWidth - 1)
            {
                list.Add(new Point(x + 1, y));
            }
            if (y > 0)
            {
                list.Add(new Point(x, y - 1));
            }

            return list;
        }

        public int GetStreightLine(Point point)
        {
            return GetStreightLine(point.X, point.Y);
        }

        public int GetStreightLine(int x, int y)
        {
            return Math.Abs(_arenaInfo.OpponentLocations[0].X - x) + Math.Abs(_arenaInfo.OpponentLocations[0].Y - y);
        }

        public int GetPointForCloseToSideOfMap(int x, int y)
        {
            int penalty = 0;

            if (x < _algorithmParameter.TilesFromSideOfMap)
            {
                penalty += _algorithmParameter.PenaltyForCloseToSideOfMap*
                           (_algorithmParameter.TilesFromSideOfMap - x)/
                           _algorithmParameter.TilesFromSideOfMap;
            }
            else if (_arenaInfo.GameConfig.MapWidth - x - 1 < _algorithmParameter.TilesFromSideOfMap)
            {
                penalty += _algorithmParameter.PenaltyForCloseToSideOfMap *
                          (_algorithmParameter.TilesFromSideOfMap -_arenaInfo.GameConfig.MapWidth + x + 1) /
                          _algorithmParameter.TilesFromSideOfMap;
            }

            if (y < _algorithmParameter.TilesFromSideOfMap)
            {
                penalty += _algorithmParameter.PenaltyForCloseToSideOfMap *
                           (_algorithmParameter.TilesFromSideOfMap - y) /
                           _algorithmParameter.TilesFromSideOfMap;
            }
            else if (_arenaInfo.GameConfig.MapHeight - y - 1 < _algorithmParameter.TilesFromSideOfMap)
            {
                penalty += _algorithmParameter.PenaltyForCloseToSideOfMap *
                          (_algorithmParameter.TilesFromSideOfMap - _arenaInfo.GameConfig.MapHeight + y + 1) /
                          _algorithmParameter.TilesFromSideOfMap;
            }

            return penalty;
        }

        public int GetPointForDistanceToEnemy(int x, int y)
        {
            var penalty = 0;
            var distance = GetStreightLine(x, y);

            if (distance < _algorithmParameter.TilesFromEnemy)
            {
                penalty = (_algorithmParameter.TilesFromEnemy - distance ) * _algorithmParameter.PenaltyForTooCloseToEnemy;
            }
            else if (distance > _algorithmParameter.TilesFromEnemy)
            {
                penalty = (distance - _algorithmParameter.TilesFromEnemy) * _algorithmParameter.PenaltyForTooFarFromEnemy; 
            }

            return penalty;
        }

        public int GetPointForNeighborTiles(int x, int y)
        {
            var penalty = 0;
            var points = GetNeighbours(x, y);

            foreach (var point in points)
            {
                if (_arenaInfo.Board[point.X, point.Y] != BoardTile.Empty)
                {
                    penalty += _algorithmParameter.PenaltyForNeighborTiles;
                }
            }

            return penalty;
        }
    }
}