using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppWASM.Helpers
{
    public class GameHelpers
    {
        public static GameStatus CalculateGameStatus(char[] squares)
        {
            //winning game combinations
            int[,] winningCombos = new int[8, 3]
            {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 },
            };
            //returns who won the game
            for (int i = 0; i < 8; i++)
            {
                if (squares[winningCombos[i, 0]] != ' '
                    && squares[winningCombos[i, 0]] == squares[winningCombos[i, 1]]
                    && squares[winningCombos[i, 0]] == squares[winningCombos[i, 2]])
                {
                    return squares[winningCombos[i, 0]] == 'X' ? GameStatus.X_wins : GameStatus.O_wins;
                }
            }
            //when game is draw
            bool isBoardFull = true;
            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i] == ' ')
                {
                    isBoardFull = false;
                    break;
                }
            }
            return isBoardFull ? GameStatus.Draw : GameStatus.NotYetFiniched;
        }
    }

    //all possible game status
    public enum GameStatus
    {
        X_wins,
        O_wins,
        Draw,
        NotYetFiniched
    }
}
