using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        public string symbol { get; set; }
        public int choice { get; set; }
        public bool display { get; set; }

        public void GenerateChoice()
        {
            Random rng = new Random();
            choice = rng.Next(1, 10);
            display = false;
        }
    }
}
