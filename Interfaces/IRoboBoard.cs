using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstraPurple_TechTest_ToyRobot.Interfaces
{
    public interface IRoboBoard
    {
        bool IsValidPosition(Position position);
    }
}
