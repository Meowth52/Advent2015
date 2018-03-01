using System;
using System.Collections.Generic;
namespace Advent2015
{
    internal class Coordinate : IEquatable<Coordinate>
    {
        public int x;
        public int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Coordinate(Coordinate c)
        {
            x = c.x;
            y = c.y;
        }
        public bool IsOn(Coordinate c)
        {
            return (c.x == this.x && c.y == this.y);
        }
        public void AddTo(Coordinate A)
        {
            x += A.x;
            y += A.y;
        }
        public Coordinate GetSum(Coordinate A)
        {
            int x2 = x + A.x;
            int y2 = y + A.y;
            return new Coordinate(x2, y2);
        }
        public bool IsInPositiveBounds(int x2, int y2)
        {
            return (x >= 0 && y >= 0 && x <= x2 && y <= y2);
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }
        public override int GetHashCode()
        {
            int hCode = x ^ y;
            return hCode.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinate);
        }
        public bool Equals(Coordinate obj)
        {
            return obj != null && obj.x == x && obj.y == y;
        }
    }
    class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate b1, Coordinate b2)
        {
            if (b2 == null && b1 == null)
                return true;
            else if (b1 == null | b2 == null)
                return false;
            else if (b1.x == b2.x && b1.y == b2.y)
                return true;
            else
                return false;
        }

        public int GetHashCode(Coordinate bx)
        {
            int hCode = bx.x ^ bx.y;
            return hCode.GetHashCode();
        }
    }
}