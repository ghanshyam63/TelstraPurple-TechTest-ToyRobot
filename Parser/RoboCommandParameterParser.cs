using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstraPurple_TechTest_ToyRobot.Interfaces;

namespace TelstraPurple_TechTest_ToyRobot
{
   
    // This class checks the parameters for the "PLACE" command.
    public class RoboCommandParameterParser
    {
        // Number of parameters provided for "PLACE" Command. (X,Y,DIRECTION)
        private const int TotalParam = 3;

        // Number of raw input items expected from user.
        private const int TotalInput = 2;

        // Checks the toy's initial position and the direction it is going to be facing.
        public RoboPlaceCommandParameter ParseParameters(string[] input)
        {
            Direction direction;
            Position position = null;

            // Checks that Place command is followed by valid command parameters (X,Y and F toy's face direction).
            if (input.Length != TotalInput)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,DIRECTION");

            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length != TotalParam)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,DIRECTION");

            // Checks the direction which the toy is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new Position(x, y);

            return new RoboPlaceCommandParameter(position, direction);
        }
    }
}
