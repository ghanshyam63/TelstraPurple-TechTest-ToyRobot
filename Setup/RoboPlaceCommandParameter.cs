namespace TelstraPurple_TechTest_ToyRobot
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    public class RoboPlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public RoboPlaceCommandParameter(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}