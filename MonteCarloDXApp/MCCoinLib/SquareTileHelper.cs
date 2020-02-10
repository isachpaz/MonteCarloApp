using System;

namespace MCCoinLib
{
    public static class SquareTileHelper
    {
        public static bool CollisionCheckWithCoin(this SquareTile square, double coinCenterX, double coinCenterY, double radius)
        {
            bool bIsCrossed = coinCenterX + radius > square.XSize ||
                              coinCenterY + radius > square.YSize ||
                              coinCenterX - radius < 0.0 ||
                              coinCenterY - radius < 0.0;
            return bIsCrossed;
        }

        public static Tuple<double, double> TransformCoordinates(this SquareTile square, Tuple<double, double> xy)
        {
            return new Tuple<double, double>(square.XSize*xy.Item1, square.YSize*xy.Item2);
        }
    }
}