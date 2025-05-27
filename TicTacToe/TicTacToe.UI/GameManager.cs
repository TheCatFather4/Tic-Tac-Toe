using TicTacToe.UI.Enums;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public class GameManager
    {
        public string[] position { get; private set; } = { " ", " ", " ", " ", " ", " ", " ", " ", " " };

        public GameManager(IPlayer player1, IPlayer player2)
        {
            player1.symbol = "X";
            player2.symbol = "O";
        }
        public void PlaceSymbol(string symbol, int index)
        {
            position[index - 1] = symbol;
        }

        public IPlayer ChangeTurn(IPlayer currentTurn, IPlayer player1, IPlayer player2)
        {
            if (currentTurn == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }
        public PlacementAttempt ReportResult(int index)
        {
            if (index > position.Length || index <= 0)
            {
                return PlacementAttempt.InvalidOffGrid;
            }
            else if (position[index - 1] == " ")
            {
                return PlacementAttempt.SymbolPlaced;
            }
            else 
            {
                return PlacementAttempt.InvalidOverlap;
            }
        }

        public PlacementAttempt WinConditionCheck(string[] postion, string symbol)
        {
            if (position[0] == symbol && position[1] == symbol && position[2] == symbol || 
                position[3] == symbol && position[4] == symbol && position[5] == symbol ||
                position[6] == symbol && position[7] == symbol && position[8] == symbol)
            {
                return WinResult(symbol);
            }
            else if (position[0] == symbol && position[3] == symbol && position[6] == symbol || 
                     position[1] == symbol && position[4] == symbol && position[7] == symbol ||
                     position[2] == symbol && position[5] == symbol && position[8] == symbol)
            {
                return WinResult(symbol);
            }
            else if (position[0] == symbol && position[4] == symbol && position[8] == symbol || 
                     position[2] == symbol && position[4] == symbol && position[6] == symbol)
            {
                return WinResult(symbol);
            }
            else if (BoardFull())
            {
                return PlacementAttempt.Draw;
            }
            else
            {
                return PlacementAttempt.SymbolPlaced;
            }
        }
        public PlacementAttempt WinResult(string symbol)
        {
            if (symbol == "X")
            {
                return PlacementAttempt.XWins;
            }
            else
            {
                return PlacementAttempt.OWins;
            }
        }

        public bool BoardFull()
        {
            if ((position[0] == "X" || position[0] == "O") && (position[1] == "X" || position[1] == "O") && (position[2] == "X" || position[2] == "O") &&
                (position[3] == "X" || position[3] == "O") && (position[4] == "X" || position[4] == "O") && (position[5] == "X" || position[5] == "O") &&
                (position[6] == "X" || position[6] == "O") && (position[7] == "X" || position[7] == "O") && (position[8] == "X" || position[8] == "O"))               
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
