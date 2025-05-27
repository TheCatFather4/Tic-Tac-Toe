using TicTacToe.UI.Enums;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public static class ConsoleIO
    {
        public static IPlayer WhoGoesFirst(IPlayer player1, IPlayer player2)
        {
            Random rng = new Random();
            int result = rng.Next(1, 3);
            if (result == 1)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

        public static void GridInstructions()
        {
            Console.WriteLine("\nHere are the positions of the grid: \n");
            Console.WriteLine("\n 1 | 2 | 3 \n---+---+---\n 4 | 5 | 6 \n---+---+---\n 7 | 8 | 9 \n");
        }
       
        public static void GameBoard(string[] position)
        {
            Console.WriteLine($"\n {position[0]} | {position[1]} | {position[2]} " +
                  $"\n---+---+---" +
                  $"\n {position[3]} | {position[4]} | {position[5]} " +
                  $"\n---+---+---" +
                  $"\n {position[6]} | {position[7]} | {position[8]} \n");
        }

        public static void WinMessage(PlacementAttempt win, string symbol)
        {
            if (win == PlacementAttempt.XWins || win == PlacementAttempt.OWins)
            {
                Console.WriteLine($"{symbol} wins!");
            }
            else
            {
                Console.WriteLine("You tied!");
            }
        }
    }
}
