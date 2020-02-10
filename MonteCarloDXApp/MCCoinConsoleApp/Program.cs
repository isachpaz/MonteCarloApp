using System;
using MCCoinLib;

namespace MCCoinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MCSimulationSettings settings = MCSimulationSettings.Create(
                numberTrials: 100000,
                reportEveryIteration: 100);
            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(2.0);

            MCCoinSimulation simulation = new MCCoinSimulation(settings);
            simulation.ResultsUpdated += results =>
            {
                var prop = (double) results.NumberOfHits / (double) results.Iteration;
                Console.WriteLine($"Iteration: {results.Iteration} " +
                                  $"Hits: {results.NumberOfHits}" +
                                  $"Probability: {prop}");
            };

            simulation.Finished += results =>
            {
                var prop = (double)results.NumberOfHits / (double)results.Iteration;
                Console.WriteLine($"MC simulation finished: Probability = {prop}");
            };
            var probability = simulation.Run(coin: coin, squareTile: squareTile);
            Console.ReadKey();
        }

    }
}
