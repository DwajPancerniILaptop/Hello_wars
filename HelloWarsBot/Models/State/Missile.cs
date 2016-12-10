using System.Drawing;
using HelloWarsBot.Models.Actions;

namespace HelloWarsBot.Models.State
{
    public class Missile
    {
        public Point Location { get; set; }
        public int ExplosionRadius { get; set; }
        public MoveDirection MoveDirection { get; set; }
    }
}
