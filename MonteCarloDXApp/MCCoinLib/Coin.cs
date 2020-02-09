using System;

namespace MCCoinLib
{
    public class Coin
    {
        public double Diameter { get; }
        public double Radius => Diameter / 2.0;

        protected Coin(double diameter)
        {
            Diameter = diameter;
        }

        public static Coin CreateWithDiameter(double diameter)
        {
            if (diameter <= 0) throw new ArgumentOutOfRangeException(nameof(diameter));
            return new Coin(diameter);
        }

        public static Coin CreateWithRadius(double radius)
        {
            return new Coin(2.0 * radius);
        }

        public override string ToString()
        {
            return $"{nameof(Diameter)}: {Diameter}";
        }

        protected bool Equals(Coin other)
        {
            return Diameter.Equals(other.Diameter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coin) obj);
        }

        public override int GetHashCode()
        {
            return Diameter.GetHashCode();
        }

        public static bool operator ==(Coin left, Coin right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coin left, Coin right)
        {
            return !Equals(left, right);
        }
    }
}