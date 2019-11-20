using System;

namespace Lab2
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Length()
        {
            int x2 = X * X;
            int y2 = Y * Y;

            return Math.Sqrt(x2 + y2);
        }

        public bool Equals(Position p)
        {
            if (p.X == X && p.Y == Y)
                return true;
            else
                return false;
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            else if (p1.Equals(p2))
            {
                return p1.X > p2.X;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Position p1, Position p2)
        {
            return p2 > p1;
        }

        public static Position operator +(Position p1, Position p2)
        {
            int newValueX = p1.X + p2.X;
            int newValueY = p1.Y + p2.Y;

            Position newPos = new Position(newValueX, newValueY);
            return newPos;
        }

        public static Position operator -(Position p1, Position p2)
        {
            int newValueX = p1.X - p2.X;
            int newValueY = p1.Y - p2.Y;

            if (newValueX < 0)
            {
                newValueX *= -1;
            }
            if (newValueY < 0)
            {
                newValueY *= -1;
            }

            Position newPos = new Position(newValueX, newValueY);
            return newPos;
        }

        public static double operator %(Position p1, Position p2)
        {
            double newValueX2 = (p1.X - p2.X) * (p1.X - p2.X);
            double newValueY2 = (p1.Y - p2.Y) * (p1.Y - p2.Y);

            return Math.Sqrt(newValueX2 + newValueY2);
        }
    }
}