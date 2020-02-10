using System;
using System.Collections.Generic;

namespace MCCoinLib.RandomEngines
{
    public class RandomSequence2DEngine : IRandom2DEngine
    {
        private Random _randomX;
        private Random _randomY;

        protected RandomSequence2DEngine(int seedX, int seedY)
        {
            _randomX = new Random(seedX);
            _randomY = new Random(seedY);
        }

        public static IRandom2DEngine Create(int seedX = 10, int seedY = 100)
        {
            return new RandomSequence2DEngine(seedX, seedY);
        }

        public IEnumerable<Tuple<double, double>> GetDoubles()
        {
            while (true)
            {
                yield return new Tuple<double, double>(_randomX.NextDouble(), _randomY.NextDouble());
            }
        }
    }
}