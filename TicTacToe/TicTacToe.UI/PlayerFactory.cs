using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Implementations;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public static class PlayerFactory
    {
        public static IPlayer GeneratePlayer(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string choice = Console.ReadLine().ToUpper();
                if (choice == "H")
                {
                    return new HumanPlayer();
                }
                else if (choice == "C")
                {
                    return new ComputerPlayer();
                }
                else
                {
                    Console.WriteLine("You must select (H)uman or (C)omputer");
                }
            } while (true);
        }
    }
}
