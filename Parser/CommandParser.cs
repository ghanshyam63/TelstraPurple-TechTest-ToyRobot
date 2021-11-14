using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstraPurple_TechTest_ToyRobot.Interfaces;

namespace TelstraPurple_TechTest_ToyRobot
{
    public class CommandParser:IParameterParser
    {
        public enum RoboCommandL
        {
            Place,
            Move,
            Left,
            Right,
            Report
        }
        //Check for valid command is passed.
        public RoboCommandL ValidateCommand(string[] rawInput)
        {
            RoboCommandL command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Sorry,Incorrect Command.");
            return command;
        }

        // Check for valid parameter passed.      
        public RoboPlaceCommandParameter ValidateCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new RoboCommandParameterParser();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}
