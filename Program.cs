using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelstraPurple_TechTest_ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            string welcomeNoteFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\WelcomeNote.txt";


            if (File.Exists(welcomeNoteFilePath))
            {
                string[] welcomenote = File.ReadAllLines(welcomeNoteFilePath);              
                foreach(var line in welcomenote)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Welcome to Telstra Purple Toy Robot");
            }

            RoboBoard sixBySixBoard = new RoboBoard(6, 6);
            CommandParser commandParser = new CommandParser();
            RoboMovement movement = new RoboMovement();
            var simulator = new RoboBehaviour(movement, sixBySixBoard, commandParser);

            var exitApp = false;
         
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.ToUpper().Equals("EXIT"))
                    exitApp = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!exitApp);


        }
    }
}
