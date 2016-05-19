using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearchPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board;
            string word = "bread";
            List<string> strings = new List<string>();

            board = new char[6, 6] {
                { 'm','d','a','e','r','b' },
                { 's','b','a','g','e','l' },
                { 'p','n','m','z','n','w' },
                { 'o','t','l','e','b','u' },
                { 'o','u','b','i','r','d' },
                { 'n','b','l','l','e','b' }
            };

            var s = GetLines(board);

            Console.WriteLine("{0}", s.Where(a => a.Contains(word)).Count());
            
        }

        static List<string> GetLines(char[,] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            List<string> results = new List<string>();
            // horizontal
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] c = new char[board.GetLength(1)];
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    c[col] = board[row, col];
                }
                results.Add(new string(c));
                results.Add(new string(c.Reverse().ToArray()));
            }
            // vertical
            for (int col = 0; col < board.GetLength(1); col++)
            {
                char[] c = new char[board.GetLength(1)];
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    c[row] = board[row, col];
                }
                results.Add(new string(c));
                results.Add(new string(c.Reverse().ToArray()));
            }
            // diagonal down
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] c = new char[board.GetLength(1) - row];
                for (int col = 0; col < board.GetLength(1) - row; col++)
                {
                    c[col] = board[row + col, col];
                }
                results.Add(new string(c));
                results.Add(new string(c.Reverse().ToArray()));
            }
            //diagonal up
             for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] c = new char[row+1];
                for (int col = 0; col < row+1; col++)
                {
                    c[col] = board[row - col, col];
                }
                results.Add(new string(c));
                results.Add(new string(c.Reverse().ToArray()));
            }          
            return results;
        }
        
    }
}
