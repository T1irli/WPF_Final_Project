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

        public static List<IFigure> WhiteFigures { get; private set; }
        public static List<IFigure> BlackFigures { get; private set; }

        static ChessGame()
        {
            board = new IFigure[8,8];
            WhiteFigures = new List<IFigure>();
            BlackFigures = new List<IFigure>();
        }

        public static bool CanMove(Point start, Point end) => GetMoves(start).Contains(end) || GetAttacks(start).Contains(end);

        public static void StartGame()
        {
            for(int i = 2; i < 6; i++)
                for(int j = 0; j < 8; j++)
                    board[i, j] = null;

            // Test
            //board[3, 6] = new Pawn() { Position = new Point(3, 6), IsWhite = true };
            //board[4, 4] = new Knight() { Position = new Point(4, 4), IsWhite = true };
            //board[2, 1] = new Bishop() { Position = new Point(2, 1), IsWhite = true };

            for(int i = 0; i < 8; i++)
            {
                board[i, 6] = new Pawn() { Position = new Point(i, 6), IsWhite = true };
            }
            board[0, 7] = new Tower() { Position = new Point(0, 7), IsWhite = true };
            board[7, 7] = new Tower() { Position = new Point(7, 7), IsWhite = true };
            board[1, 7] = new Knight() { Position = new Point(1, 7), IsWhite = true };
            board[6, 7] = new Knight() { Position = new Point(6, 7), IsWhite = true };
            board[2, 7] = new Bishop() { Position = new Point(2, 7), IsWhite = true };
            board[5, 7] = new Bishop() { Position = new Point(5, 7), IsWhite = true };
            board[3, 7] = new Queen() { Position = new Point(3, 7), IsWhite = true };
            board[4, 7] = new King() { Position = new Point(4, 7), IsWhite = true };

            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn() { Position = new Point(i, 1), IsWhite = false };
            }
            board[0, 0] = new Tower() { Position = new Point(0, 0), IsWhite = false };
            board[7, 0] = new Tower() { Position = new Point(7, 0), IsWhite = false };
            board[1, 0] = new Knight() { Position = new Point(1, 0), IsWhite = false };
            board[6, 0] = new Knight() { Position = new Point(6, 0), IsWhite = false };
            board[2, 0] = new Bishop() { Position = new Point(2, 0), IsWhite = false };
            board[5, 0] = new Bishop() { Position = new Point(5, 0), IsWhite = false };
            board[3, 0] = new Queen() { Position = new Point(3, 0), IsWhite = false };
            board[4, 0] = new King() { Position = new Point(4, 0), IsWhite = false };

            foreach (var item in board)
            {
                if(item == null) continue;
                if (item.IsWhite)
                    WhiteFigures.Add(item);
                else BlackFigures.Add(item);
            }
        }

        public static void Move(Point start, Point end)
        {
            if (board[start.X, start.Y] == null)
                throw new NullReferenceException();
            if (CanMove(start, end))
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
                    if (board[point.X, point.Y] != null)
                        break;
                    result.Add(point);
                }
            return result;
        }

        public static List<Point> GetAttacks(Point position)
        {
            if (board[position.X, position.Y] is Pawn)
            {
                List<Point> _result = new List<Point>();
                if (board[position.X, position.Y].IsWhite)
                {
                    if (position.X > 0 && position.Y > 0 && board[position.X - 1, position.Y - 1] != null &&
                        !board[position.X - 1, position.Y - 1].IsWhite)
                        _result.Add(new Point(position.X - 1, position.Y - 1));
                    if (position.X < 7 && position.Y > 0 && board[position.X + 1, position.Y - 1] != null &&
                        !board[position.X + 1, position.Y - 1].IsWhite)
                        _result.Add(new Point(position.X + 1, position.Y - 1));
                }
                else
                {
                    if (position.X > 0 && position.Y < 7 && board[position.X - 1, position.Y + 1] != null &&
                        board[position.X - 1, position.Y + 1].IsWhite)
                        _result.Add(new Point(position.X - 1, position.Y + 1));
                    if (position.X < 7 && position.Y < 7 && board[position.X + 1, position.Y + 1] != null &&
                        board[position.X + 1, position.Y + 1].IsWhite)
                        _result.Add(new Point(position.X + 1, position.Y + 1));
                }
                return _result;
            }
            var list = board[position.X, position.Y].GetMoves();
            List<Point> result = new List<Point>();
            foreach (var move in list)
                foreach (var point in move)
                {
                    if (point.X < 0 || point.Y < 0 || point.X > 7 || point.Y > 7) continue;
                    if (board[point.X, point.Y] != null)
                    {
                        if (board[point.X, point.Y].IsWhite != board[position.X, position.Y].IsWhite)
                        {
                            result.Add(point);
                            break;
                        }
                        else break;
                    }
                }

            return result;
        }
    }
}
