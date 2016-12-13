using HelloWarsBot.Models.State;

namespace HelloWarsBot.Models.Algorithm
{
    public class AlgorithmParameter
    {
        public AlgorithmParameter(TankBlasterConfig config)
        {
            BoardTilePoints = 1000;
            TilesFromSideOfMap = 3;
            PenaltyForCloseToSideOfMap = 9;
            TilesFromEnemy = (config.BombBlastRadius + config.MissileBlastRadius)/2;
            PenaltyForTooCloseToEnemy = 5;
            PenaltyForTooFarFromEnemy = 1;
            PenaltyForNeighborTiles = 5;
        }

        public int BoardTilePoints { get; set; }

        public int TilesFromSideOfMap { get; set; }

        public int PenaltyForCloseToSideOfMap { get; set; }

        public int TilesFromEnemy { get; set; }

        public int PenaltyForTooCloseToEnemy { get; set; }

        public int PenaltyForTooFarFromEnemy { get; set; }

        public int PenaltyForNeighborTiles { get; set; }
    }
}