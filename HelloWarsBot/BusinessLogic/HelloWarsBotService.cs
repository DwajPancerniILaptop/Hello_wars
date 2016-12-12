using HelloWarsBot.BusinessLogic.Interface;
using HelloWarsBot.Models.Actions;
using HelloWarsBot.Models.Algorithm;
using HelloWarsBot.Models.State;

namespace HelloWarsBot.BusinessLogic
{
    public class HelloWarsBotService : IHelloWarsBotService
    {
        private BotArenaInfo _arenaInfo;
        private AllyMapPoint[,] _allyMap;
        private EnemyMapPoint[,] _enemyMap;
        private ILocationHelper _locationHelper;
        private IBlastRadiusHelper _blastRadiusHelper;
        private IPathFinding _pathFinding;
        private AlgorithmParameter _algorithmParameter;

        public HelloWarsBotService(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter)
        {
            _arenaInfo = arenaInfo;
            _algorithmParameter = algorithmParameter;

            InitializeArrays();

            _locationHelper = new LocationHelper();
            _locationHelper.Initialize(_arenaInfo, _algorithmParameter);
            _blastRadiusHelper = new BlastRadiusHelper();
            _blastRadiusHelper.Initialize(_arenaInfo, _algorithmParameter);
            _pathFinding = new PathFinding();
        }

        public BotMove CalculateNextMove()
        {
            BotMove botMove = new BotMove();
            for (int i = 0; i < _arenaInfo.GameConfig.MapWidth; i++)
            {
                for (int j = 0; j < _arenaInfo.GameConfig.MapHeight; j++)
                {
                    _allyMap[i, j].BoardTile = _locationHelper.GetPointsForBoardTile(i, j);
                }
            }

            botMove.Direction = _pathFinding.CalculatePath(_arenaInfo.BotLocation, _arenaInfo.OpponentLocations[0], _allyMap, _locationHelper);

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
