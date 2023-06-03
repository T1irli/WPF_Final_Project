using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace BusinessLogicLayer.Services
{
    public static class ChessGame
    {
        private static IFigure[,] board;
        public static bool WhiteTurn { get; private set; }

        static ChessGame()
        {
            board = new IFigure[8,8];
        }

        private static bool CanMove(IFigure figure, Point p) => figure.GetMoves().SelectMany(x => x).Contains(p);

        public static bool CanMove(Point start, Point end) => CanMove(board[start.X, start.Y], end);

        public static void StartGame()
        {
            for(int i = 2; i < 6; i++)
                for(int j = 0; j < 8; j++)
                    board[i, j] = null;

            // Test
            board[3, 6] = new Pawn() { Position = new Point(3, 6), IsWhite = true };
            board[4, 4] = new Knight() { Position = new Point(4, 4), IsWhite = true };
            board[2, 1] = new Bishop() { Position = new Point(2, 1), IsWhite = true };
        }

        public static void Move(Point start, Point end)
        {
            if (board[start.X, start.Y] == null)
                throw new NullReferenceException();
            if (CanMove(board[start.X, start.Y], end))
            {
                board[end.X, end.Y] = board[start.X, start.Y];
                board[start.X, start.Y] = null;
                board[end.X, end.Y].Position = new Point(end.X, end.Y);
            }
        }

        public static List<Point> GetMoves(Point position)
        {
            var list = board[position.X, position.Y].GetMoves();
            List<Point> result = new List<Point>();    
            foreach(var move in list)
                foreach(var point in move)
                {
                    if(point.X < 0 || point.Y < 0 || point.X > 7 || point.Y > 7) continue;
                    if (board[point.X, point.Y] != null) break;
                    result.Add(point);
                }
            return result;
        }
    }
}
