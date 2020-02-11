using System;
using MCCoinLib.RandomEngines;

namespace MCCoinLib
{
    public class MCSimulationResults
    {
        public long Iteration { get; }
        public long NumberOfHits { get; }
        public Coin Coin { get; }
        public SquareTile SquareTile { get; }
        public double Probability { get; }

        public SamplingMethod SamplingMethod { get; }
            

        public MCSimulationResults(long iteration, long numberOfHits, Coin coin, SquareTile squareTile, SamplingMethod samplingMethod)
        {
            if (iteration <= 0) throw new ArgumentOutOfRangeException(nameof(iteration));
            if (numberOfHits <= 0) throw new ArgumentOutOfRangeException(nameof(numberOfHits));
            Iteration = iteration;
            NumberOfHits = numberOfHits;
            Probability = (double)NumberOfHits / Iteration;

            Coin = coin;
            SquareTile = squareTile;
            SamplingMethod = samplingMethod;
        }

        public override string ToString()
        {
            return $"Input data: \n" +
                   $"(1) coin with diameter = {Coin.Diameter}.\n" +
                   $"(2) square tile of size = {SquareTile.XSize}x{SquareTile.YSize}\n" +
                   $"(3) sampling method: {SamplingMethod.ToString()}\n" +
                   $"The coin has probability of {Probability} to land on the square edges.";
        }
    }
}