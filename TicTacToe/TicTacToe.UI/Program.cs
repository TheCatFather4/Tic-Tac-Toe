using TicTacToe.UI;
using TicTacToe.UI.Enums;
using TicTacToe.UI.Interfaces;

Console.WriteLine("Welcome to Tic-Tac-Toe!");

IPlayer player1 = PlayerFactory.GeneratePlayer("Player 1 (X) - Human or Computer? (H/C): "); 
IPlayer player2 = PlayerFactory.GeneratePlayer("Player 2 (O) - Human or Computer? (H/C): "); 

GameManager gmr = new GameManager(player1, player2);

IPlayer currentTurn = ConsoleIO.WhoGoesFirst(player1, player2);

Console.WriteLine($"\n{currentTurn.symbol} will go first!");

ConsoleIO.GridInstructions();

PlacementAttempt win;
do
{
    currentTurn.GenerateChoice();
    PlacementAttempt result = gmr.ReportResult(currentTurn.choice);

    if (result == PlacementAttempt.InvalidOffGrid)
    {
        Console.WriteLine("Please choose a valid position on the game board (1-9).");
    }
    else if (result == PlacementAttempt.InvalidOverlap)
    {
        if (currentTurn.display)
        {
            Console.WriteLine("This position is already chosen. Please try again.");
        }
        
    }
    else if (result == PlacementAttempt.SymbolPlaced)
    {
        if (!currentTurn.display)
        {
            Console.WriteLine($"{currentTurn.symbol} chooses position {currentTurn.choice}.");
        }
        gmr.PlaceSymbol(currentTurn.symbol, currentTurn.choice);
        ConsoleIO.GameBoard(gmr.position);
        win = gmr.WinConditionCheck(gmr.position, currentTurn.symbol);
        if (win == PlacementAttempt.XWins || win == PlacementAttempt.OWins || win == PlacementAttempt.Draw)
        {
            break;
        }
        currentTurn = gmr.ChangeTurn(currentTurn, player1, player2);
    }

} while (true);

ConsoleIO.WinMessage(win, currentTurn.symbol); 

