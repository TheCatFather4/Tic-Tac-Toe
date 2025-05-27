using NUnit.Framework;
using TicTacToe.UI;
using TicTacToe.UI.Enums;
using TicTacToe.UI.Implementations;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests
{
    public class TicTacToeTests
    {
        public PlacementAttempt XWins_Row(int a, int b, int c)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p1.symbol, a);
            gmr.PlaceSymbol(p1.symbol, b);
            gmr.PlaceSymbol(p1.symbol, c);
            return gmr.WinConditionCheck(gmr.position, p1.symbol);
        }

        public PlacementAttempt OWins_Row(int a, int b, int c)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p2.symbol, a);
            gmr.PlaceSymbol(p2.symbol, b);
            gmr.PlaceSymbol(p2.symbol, c);
            return gmr.WinConditionCheck(gmr.position, p2.symbol);
        }

        public PlacementAttempt XPlace_Tie(int a, int b, int c, int d, int e, int f, int g, int h, int i)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p1.symbol, a);
            gmr.PlaceSymbol(p2.symbol, b);
            gmr.PlaceSymbol(p1.symbol, c);
            gmr.PlaceSymbol(p2.symbol, d);
            gmr.PlaceSymbol(p1.symbol, e);
            gmr.PlaceSymbol(p2.symbol, f);
            gmr.PlaceSymbol(p1.symbol, g);
            gmr.PlaceSymbol(p2.symbol, h);
            gmr.PlaceSymbol(p1.symbol, i);
            return gmr.WinConditionCheck(gmr.position, p1.symbol);
        }

        public PlacementAttempt OPlace_Tie(int a, int b, int c, int d, int e, int f, int g, int h, int i)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p2.symbol, a);
            gmr.PlaceSymbol(p1.symbol, b);
            gmr.PlaceSymbol(p2.symbol, c);
            gmr.PlaceSymbol(p1.symbol, d);
            gmr.PlaceSymbol(p2.symbol, e);
            gmr.PlaceSymbol(p1.symbol, f);
            gmr.PlaceSymbol(p2.symbol, g);
            gmr.PlaceSymbol(p1.symbol, h);
            gmr.PlaceSymbol(p2.symbol, i);
            return gmr.WinConditionCheck(gmr.position, p1.symbol);
        }

        public PlacementAttempt InvalidPlacement_X(int position)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p2.symbol, position);
            p1.choice = position;
            return gmr.ReportResult(p1.choice);
        }

        public PlacementAttempt InvalidPlacement_O(int position)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            gmr.PlaceSymbol(p1.symbol, position);
            p2.choice = position;
            return gmr.ReportResult(p2.choice);
        }

        public PlacementAttempt GridPlace_X(int position)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            p1.choice = position;
            return gmr.ReportResult(p1.choice);
        }

        public PlacementAttempt GridPlace_O(int position)
        {
            IPlayer p1 = new HumanPlayer();
            IPlayer p2 = new HumanPlayer();
            GameManager gmr = new GameManager(p1, p2);

            p2.choice = position;
            return gmr.ReportResult(p2.choice);
        }

        [Test]
        public void XO_Win_Vertical()
        {
            var xWin1 = XWins_Row(1, 4, 7);
            var xWin2 = XWins_Row(2, 5, 8);
            var xWin3 = XWins_Row(3, 6, 9);
            Assert.That(xWin1, Is.EqualTo(PlacementAttempt.XWins));
            Assert.That(xWin2, Is.EqualTo(PlacementAttempt.XWins));
            Assert.That(xWin3, Is.EqualTo(PlacementAttempt.XWins));

            var oWin1 = OWins_Row(1, 4, 7);
            var oWin2 = OWins_Row(2, 5, 8);
            var oWin3 = OWins_Row(3, 6, 9);
            Assert.That(oWin1, Is.EqualTo(PlacementAttempt.OWins));
            Assert.That(oWin2, Is.EqualTo(PlacementAttempt.OWins));
            Assert.That(oWin3, Is.EqualTo(PlacementAttempt.OWins));
        }

        [Test]
        public void XO_Win_Horizontal()
        {
            var xWin1 = XWins_Row(1, 2, 3);
            var xWin2 = XWins_Row(4, 5, 6);
            var xWin3 = XWins_Row(7, 8, 9);
            Assert.That(xWin1, Is.EqualTo(PlacementAttempt.XWins));
            Assert.That(xWin2, Is.EqualTo(PlacementAttempt.XWins));
            Assert.That(xWin3, Is.EqualTo(PlacementAttempt.XWins));

            var oWin1 = OWins_Row(1, 2, 3);
            var oWin2 = OWins_Row(4, 5, 6);
            var oWin3 = OWins_Row(7, 8, 9);
            Assert.That(oWin1, Is.EqualTo(PlacementAttempt.OWins));
            Assert.That(oWin2, Is.EqualTo(PlacementAttempt.OWins));
            Assert.That(oWin3, Is.EqualTo(PlacementAttempt.OWins));
        }

        [Test]
        public void XO_Win_Diagonal()
        {
            var xWin1 = XWins_Row(1, 5, 9);
            var xWin2 = XWins_Row(3, 5, 7);            
            Assert.That(xWin1, Is.EqualTo(PlacementAttempt.XWins));
            Assert.That(xWin2, Is.EqualTo(PlacementAttempt.XWins));
         

            var oWin1 = OWins_Row(1, 5, 9);
            var oWin2 = OWins_Row(3, 5, 7);         
            Assert.That(oWin1, Is.EqualTo(PlacementAttempt.OWins));
            Assert.That(oWin2, Is.EqualTo(PlacementAttempt.OWins));           
        }

        [Test]
        public void X_First_Tie()
        {
            var xTie1 = XPlace_Tie(1, 2, 5, 3, 6, 4, 7, 9, 8);
            var xTie2 = XPlace_Tie(7, 4, 1, 3, 8, 5, 2, 9, 6);
            var xTie3 = OPlace_Tie(8, 9, 7, 4, 6, 3, 5, 2, 1);
            var xTie4 = OPlace_Tie(6, 9, 2, 5, 8, 3, 1, 4, 7);
            Assert.That(xTie1, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(xTie2, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(xTie3, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(xTie4, Is.EqualTo(PlacementAttempt.Draw));
        }

        [Test]
        public void O_First_Tie()
        {
            var oTie1 = OPlace_Tie(1, 2, 5, 3, 6, 4, 7, 9, 8);
            var oTie2 = OPlace_Tie(7, 4, 1, 3, 8, 5, 2, 9, 6);
            var oTie3 = OPlace_Tie(8, 9, 7, 4, 6, 3, 5, 2, 1);
            var oTie4 = OPlace_Tie(6, 9, 2, 5, 8, 3, 1, 4, 7);
            Assert.That(oTie1, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(oTie2, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(oTie3, Is.EqualTo(PlacementAttempt.Draw));
            Assert.That(oTie4, Is.EqualTo(PlacementAttempt.Draw));
        }

        [Test]
        public void X_Invalid_Placement()
        {
            var xPos1 = InvalidPlacement_X(1);
            var xPos2 = InvalidPlacement_X(2);
            var xPos3 = InvalidPlacement_X(3);
            var xPos4 = InvalidPlacement_X(4);
            var xPos5 = InvalidPlacement_X(5);
            var xPos6 = InvalidPlacement_X(6);
            var xPos7 = InvalidPlacement_X(7);
            var xPos8 = InvalidPlacement_X(8);
            var xPos9 = InvalidPlacement_X(9);
            Assert.That(xPos1, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos2, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos3, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos4, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos5, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos6, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos7, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos8, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(xPos9, Is.EqualTo(PlacementAttempt.InvalidOverlap));
        }

        [Test]
        public void O_Invalid_Placement()
        {
            var oPos1 = InvalidPlacement_O(1);
            var oPos2 = InvalidPlacement_O(2);
            var oPos3 = InvalidPlacement_O(3);
            var oPos4 = InvalidPlacement_O(4);
            var oPos5 = InvalidPlacement_O(5);
            var oPos6 = InvalidPlacement_O(6);
            var oPos7 = InvalidPlacement_O(7);
            var oPos8 = InvalidPlacement_O(8);
            var oPos9 = InvalidPlacement_O(9);
            Assert.That(oPos1, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos2, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos3, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos4, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos5, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos6, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos7, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos8, Is.EqualTo(PlacementAttempt.InvalidOverlap));
            Assert.That(oPos9, Is.EqualTo(PlacementAttempt.InvalidOverlap));
        }

        [Test]
        public void XO_Off_Grid()
        {
            var xOffP = GridPlace_X(10);
            var xOffZ = GridPlace_X(0);
            var xOffN = GridPlace_X(-1);
            Assert.That(xOffP, Is.EqualTo(PlacementAttempt.InvalidOffGrid));
            Assert.That(xOffZ, Is.EqualTo(PlacementAttempt.InvalidOffGrid));
            Assert.That(xOffN, Is.EqualTo(PlacementAttempt.InvalidOffGrid));

            var oOffP = GridPlace_O(10);
            var oOffZ = GridPlace_O(0);
            var oOffN = GridPlace_O(-1);
            Assert.That(oOffP, Is.EqualTo(PlacementAttempt.InvalidOffGrid));
            Assert.That(oOffZ, Is.EqualTo(PlacementAttempt.InvalidOffGrid));
            Assert.That(oOffN, Is.EqualTo(PlacementAttempt.InvalidOffGrid));
        }

        [Test]
        public void X_On_Grid()
        {
            var xOn1 = GridPlace_X(1);
            var xOn2 = GridPlace_X(2);
            var xOn3 = GridPlace_X(3);
            var xOn4 = GridPlace_X(4);
            var xOn5 = GridPlace_X(5);
            var xOn6 = GridPlace_X(6);
            var xOn7 = GridPlace_X(7);
            var xOn8 = GridPlace_X(8);
            var xOn9 = GridPlace_X(9);
            Assert.That(xOn1, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn2, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn3, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn4, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn5, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn6, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn7, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn8, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(xOn9, Is.EqualTo(PlacementAttempt.SymbolPlaced));
        }

        [Test]
        public void O_On_Grid()
        {
            var oOn1 = GridPlace_O(1);
            var oOn2 = GridPlace_O(2);
            var oOn3 = GridPlace_O(3);
            var oOn4 = GridPlace_O(4);
            var oOn5 = GridPlace_O(5);
            var oOn6 = GridPlace_O(6);
            var oOn7 = GridPlace_O(7);
            var oOn8 = GridPlace_O(8);
            var oOn9 = GridPlace_O(9);
            Assert.That(oOn1, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn2, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn3, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn4, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn5, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn6, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn7, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn8, Is.EqualTo(PlacementAttempt.SymbolPlaced));
            Assert.That(oOn9, Is.EqualTo(PlacementAttempt.SymbolPlaced));
        }
    }
}
