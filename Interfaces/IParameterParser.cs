using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TelstraPurple_TechTest_ToyRobot.CommandParser;

namespace TelstraPurple_TechTest_ToyRobot.Interfaces
{
    public interface IParameterParser
    {
        RoboCommandL ValidateCommand(string[] rawInput);

        // This extracts the parameters from the user's input.        
        RoboPlaceCommandParameter ValidateCommandParameter(string[] input);
    }
}
