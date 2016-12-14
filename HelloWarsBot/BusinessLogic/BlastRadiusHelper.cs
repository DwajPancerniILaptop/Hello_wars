using System.Collections.Generic;
using System.Drawing;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.Actions;
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
            _algorithmParameter = algorithmParameter;
        }

        public List<LocationPoint> CalculateBombRadius(Point point)
        {
            throw new System.NotImplementedException();
        }

        public List<LocationPoint> CalculateMissileRadius(Point point)
        {
            throw new System.NotImplementedException();
        }

        public List<LocationPoint> CalculatePenaltyForBombs()
        {
            foreach (var arenaInfoMissile in _arenaInfo.Missiles)
            {
                
            }

            return new List<LocationPoint>();
        }

        public List<LocationPoint> CalculateMissleExplosion(Missile missle)
        {
            bool continueSearching = true;
            Point nextLocation = new Point();
            Point nextLocation2;
            while (continueSearching)
            {
                nextLocation = missle.Location;
                switch (missle.MoveDirection)
                {
                        case MoveDirection.Down:
                        nextLocation.Y++;
                        break;
                        case MoveDirection.Left:
                        nextLocation.X--;
                        break;
                        case MoveDirection.Right:
                        nextLocation.X++;
                        break;
                        case MoveDirection.Up:
                        nextLocation.Y--;
                        break;
                }

                nextLocation2 = nextLocation;
                if (_arenaInfo.GameConfig.IsFastMissileModeEnabled)
                {
                    switch (missle.MoveDirection)
                    {
                        case MoveDirection.Down:
                            nextLocation2.Y++;
                            break;
                        case MoveDirection.Left:
                            nextLocation2.X--;
                            break;
                        case MoveDirection.Right:
                            nextLocation2.X++;
                            break;
                        case MoveDirection.Up:
                            nextLocation2.Y--;
                            break;
                    }
                }

                //TODO warunki na skraj mapy
                if (_arenaInfo.Board[nextLocation2.X, nextLocation2.Y] != BoardTile.Empty)
                {
                    continueSearching = false;
                }
            }

            return CalculateMissileRadius(nextLocation);
        }
    }
}