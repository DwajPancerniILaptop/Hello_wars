namespace HelloWarsBot.Models.Actions
{
    public class BotMove
    {
        public MoveDirection? Direction { get; set; }
        public BotAction Action { get; set; }
        public MoveDirection FireDirection { get; set; }
    }
}
