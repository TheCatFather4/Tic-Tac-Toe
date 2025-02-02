using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public string symbol { get; set; }
        public int choice { get;  set; }
        public bool display { get; set; }

        public void GenerateChoice()
        {
            do
            {
                Console.Write($"{symbol}, choose a position: ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    choice = input;
                    display = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }
            } while (true);
        }
    }
}
