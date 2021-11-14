using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstraPurple_TechTest_ToyRobot.Interfaces;
using static TelstraPurple_TechTest_ToyRobot.CommandParser;

namespace TelstraPurple_TechTest_ToyRobot
{
    public class RoboBehaviour
    {
        public IRoboMovement ToyRobot { get; private set; }
        public IRoboBoard SquareBoard { get; private set; }
        public IParameterParser InputParser { get; private set; }

        public RoboBehaviour(IRoboMovement toyRobot, IRoboBoard squareBoard, IParameterParser inputParser)
        {
            ToyRobot = toyRobot;
            SquareBoard = squareBoard;
            InputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var command = InputParser.ValidateCommand(input);
            if (command != RoboCommandL.Place && ToyRobot.Position == null) return string.Empty;

            switch (command)
            {
                case RoboCommandL.Place:
                    var placeCommandParameter = InputParser.ValidateCommandParameter(input);
                    if (SquareBoard.IsValidPosition(placeCommandParameter.Position))
                        ToyRobot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case RoboCommandL.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (SquareBoard.IsValidPosition(newPosition))
                        ToyRobot.Position = newPosition;
                    break;
                case RoboCommandL.Left:
                    ToyRobot.RotateLeft();
                    break;
                case RoboCommandL.Right:
                    ToyRobot.RotateRight();
                    break;
                case RoboCommandL.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Current Position: {0},{1},{2}", ToyRobot.Position.X,
                ToyRobot.Position.Y, ToyRobot.Direction.ToString().ToUpper());
        }
    }
}
