namespace HelloWarsBot.Models.Algorithm
{
    public class AllyMapPoint
    {
        public int BoardTile { get; set; }

        public int Danger { get; set; }

        public int Result 
        {
            get
            {
                return BoardTile + Danger; 
                
            }
        }
    }
}