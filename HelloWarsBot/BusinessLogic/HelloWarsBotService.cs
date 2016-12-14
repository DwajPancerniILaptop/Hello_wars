using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.Algorithm;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic
{
    public class HelloWarsBotService : IHelloWarsBotService
    {
        private readonly BotArenaInfo _arenaInfo;
        private AllyMapPoint[,] _allyMap;
        private EnemyMapPoint[,] _enemyMap;
        private readonly ILocationHelper _locationHelper;
        private readonly IBlastRadiusHelper _blastRadiusHelper;
        private readonly IPathFinding _pathFinding;

        public HelloWarsBotService(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter)
        {
            _arenaInfo = arenaInfo;

            InitializeArrays();

            _locationHelper = new LocationHelper();
            _locationHelper.Initialize(_arenaInfo, algorithmParameter);
            _blastRadiusHelper = new BlastRadiusHelper();
            _blastRadiusHelper.Initialize(_arenaInfo, algorithmParameter);
            _pathFinding = new PathFinding();
        }

        public BotMove CalculateNextMove()
        {
            BotMove botMove = new BotMove();
            Point bestPoint = new Point();
            int minPoint = 9999999;
            for (int i = 0; i < _arenaInfo.GameConfig.MapWidth; i++)
            {
                for (int j = 0; j < _arenaInfo.GameConfig.MapHeight; j++)
                {
                    _allyMap[i, j].BoardTile = _locationHelper.GetPointsForBoardTile(i, j);
                    _allyMap[i, j].DistanceToSideOfMap = _locationHelper.GetPointForCloseToSideOfMap(i, j);
                    _allyMap[i, j].DistanceToOpponent = _locationHelper.GetPointForDistanceToEnemy(i, j);
                    _allyMap[i, j].Neighbor = _locationHelper.GetPointForNeighborTiles(i, j);

                    if (_allyMap[i, j].Result < minPoint)
                    {
                        bestPoint = new Point(i,j);
                        minPoint = _allyMap[i, j].Result;
                    }
                }
            }
            
            botMove.Direction = _pathFinding.CalculatePath(_arenaInfo.BotLocation, bestPoint, _allyMap, _locationHelper);

            return botMove;
        }

        private void InitializeArrays()
        {
            _allyMap = new AllyMapPoint[_arenaInfo.GameConfig.MapWidth, _arenaInfo.GameConfig.MapHeight];
            _enemyMap = new EnemyMapPoint[_arenaInfo.GameConfig.MapWidth, _arenaInfo.GameConfig.MapHeight];

            for (int i = 0; i < _arenaInfo.GameConfig.MapWidth; i++)
            {
                for (int j = 0; j < _arenaInfo.GameConfig.MapHeight; j++)
                {
                    _allyMap[i,j] = new AllyMapPoint();
                    _enemyMap[i,j]= new EnemyMapPoint();
                }
            }
        }
    }
}
