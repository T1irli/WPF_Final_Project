using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Pawn : IFigure
    {
        private int moveCount = -1;
        private Point position;

        public Point Position { get => position;
            set
            {
                position = value;
                moveCount++;
            }
        }
        public bool IsWhite { get; set; }

        public List<List<Point>> GetMoves()
        {
            if (moveCount == 0)
                return new List<List<Point>>() { new List<Point>(){ new Point(Position.X, Position.Y-1), 
                    new Point(Position.X, Position.Y - 2), } };
            else return new List<List<Point>>() { new List<Point>(){ new Point(Position.X, Position.Y-1) } };
        }
    }
}
