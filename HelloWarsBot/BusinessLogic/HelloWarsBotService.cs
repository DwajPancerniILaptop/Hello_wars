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
        private AlgorithmParameter _algorithmParameter;

        public HelloWarsBotService(BotArenaInfo arenaInfo, AlgorithmParameter algorithmParameter)
        {
            _arenaInfo = arenaInfo;
            _algorithmParameter = algorithmParameter;

            InitializeArrays();

            _locationHelper = new LocationHelper();
            _locationHelper.Initialize(_arenaInfo);
            _blastRadiusHelper = new BlastRadiusHelper();
            _blastRadiusHelper.Initialize(_arenaInfo);
        }

        public BotMove CalculateNextMove()
        {
            return new BotMove();
        }

        private void InitializeArrays()
        {
            _allyMap = new AllyMapPoint[_arenaInfo.Board.GetLength(0), _arenaInfo.Board.GetLength(1)];
            _enemyMap = new EnemyMapPoint[_arenaInfo.Board.GetLength(0), _arenaInfo.Board.GetLength(1)];

            for (int i = 0; i < _arenaInfo.Board.GetLength(0); i++)
            {
                for (int j = 0; j < _arenaInfo.Board.GetLength(1); j++)
                {
                    _allyMap[i,j] = new AllyMapPoint();
                    _enemyMap[i,j]= new EnemyMapPoint();
                }
            }
        }
    }
}
