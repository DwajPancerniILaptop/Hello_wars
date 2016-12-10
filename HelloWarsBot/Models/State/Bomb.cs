using System.Drawing;

namespace HelloWarsBot.Models.State
{
    public class Bomb
    {
        public Point Location { get; set; }
        public int RoundsUntilExplodes { get; set; }
        public int ExplosionRadius { get; set; }
    }
}
