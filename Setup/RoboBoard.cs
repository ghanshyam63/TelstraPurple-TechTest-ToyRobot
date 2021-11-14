using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstraPurple_TechTest_ToyRobot.Interfaces;

namespace TelstraPurple_TechTest_ToyRobot
{
    class RoboBoard:IRoboBoard
    {
       
            public int Rows { get; private set; }
            public int Columns { get; private set; }

            public RoboBoard(int rows, int columns)
            {
                this.Rows = rows;
                this.Columns = columns;
            }

            // Check whether the position specified is inside the boundaries of the square board.
            public bool IsValidPosition(Position position)
            {
                return position.X < Columns && position.X >= 0 &&
                       position.Y < Rows && position.Y >= 0;
            }
        
    }
}
