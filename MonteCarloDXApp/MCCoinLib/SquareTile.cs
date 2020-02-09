using System;

namespace MCCoinLib
{
    public class SquareTile
    {
        public double XSize { get; }
        public double YSize => XSize;

        protected SquareTile(double xSize)
        {
            XSize = xSize;
        }

        public override string ToString()
        {
            return $"{nameof(XSize)}: {XSize}";
        }

        protected bool Equals(SquareTile other)
        {
            return XSize.Equals(other.XSize);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SquareTile) obj);
        }

        public override int GetHashCode()
        {
            return XSize.GetHashCode();
        }

        public static bool operator ==(SquareTile left, SquareTile right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SquareTile left, SquareTile right)
        {
            return !Equals(left, right);
        }

        public static SquareTile Create(double xSize)
        {
            if (xSize <= 0) throw new ArgumentOutOfRangeException(nameof(xSize));
            return new SquareTile(xSize);
        }
    }
}