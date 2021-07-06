using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum Player
    {
        X = 1,
        O = -1,
        Open = 0,
    }


    /// Abstract class for creating new game boards, contains all of the logic needed for the AI to play the game.

    public abstract class GameBoard
    {

        /// Array that contains all of the spaces on the board.

        public Player[,] holders;


        /// Gets or sets a space on the board.

        public abstract Player this[int x, int y] { get; set; }


        /// Determines if all spaces on the board are full.

        public abstract bool IsFull { get; }


        /// Gets the maximum size of the board.

        public abstract int Size { get; }


        /// List of the open spaces available on the current board.

        public abstract List<Space> OpenSquares { get; }


        /// Determines if there is a winner on the current board.

        public abstract Player Winner { get; }


        /// Makes a deap copy of the current board

        public abstract GameBoard Clone();
    }


    /// Describes a space on the board.

    public struct Space
    {
        public int X;
        public int Y;
        public double Rank;

        public Space(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rank = 0;
        }
    }
}
