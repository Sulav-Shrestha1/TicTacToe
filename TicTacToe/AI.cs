using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class AI
    {
        public static Space GetBestMove(GameBoard gb, Player p)
        {
            Space? bestSpace = null;
            List<Space> openSpaces = gb.OpenSquares;
            GameBoard newBoard;

            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = gb.Clone();
                Space newSpace = openSpaces[i];

                newBoard[newSpace.X, newSpace.Y] = p;

                if (newBoard.Winner == Player.Open && newBoard.OpenSquares.Count > 0)
                {
                    Space tempMove = GetBestMove(newBoard, ((Player)(-(int)p)));  //a little hacky, inverts the current player
                    newSpace.Rank = tempMove.Rank;
                }
                else
                {
                    if (newBoard.Winner == Player.Open)
                        newSpace.Rank = 0;
                    else if (newBoard.Winner == Player.X)
                        newSpace.Rank = -1;
                    else if (newBoard.Winner == Player.O)
                        newSpace.Rank = 1;
                }

                //If the new move is better than our previous move, take it
                if (bestSpace == null ||
                   (p == Player.X && newSpace.Rank < ((Space)bestSpace).Rank) ||
                   (p == Player.O && newSpace.Rank > ((Space)bestSpace).Rank))
                {
                    bestSpace = newSpace;
                }
            }

            return (Space)bestSpace;
        }
    }
}
