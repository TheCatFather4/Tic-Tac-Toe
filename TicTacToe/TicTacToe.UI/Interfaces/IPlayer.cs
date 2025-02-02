using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI.Interfaces
{
    public interface IPlayer
    {
        string symbol { get; set; }
        int choice { get;  set; }
        bool display { get; set; }
        void GenerateChoice();
    }
}
