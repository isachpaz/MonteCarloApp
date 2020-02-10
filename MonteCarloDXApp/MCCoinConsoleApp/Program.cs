using System;
using MCCoinLib;
using MCCoinLib.RandomEngines;

namespace MCCoinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = MCSimulationSettings.Create(numberTrials: 100000);
            var randomEngineService = new Random2DEngineService();
            var coin = Coin.CreateWithDiameter(1.0);
            var squareTile = SquareTile.Create(10.0);

            MCCoinSimulation simulation = new MCCoinSimulation(settings, randomEngineService);
           
            simulation.Finished += results =>
            {
                Console.WriteLine($"MC simulation finished.\n{results}");
            };
            var probability = simulation.Run(coin: coin, squareTile: squareTile, method: SamplingMethod.Halton);
            Console.ReadKey();

            simulation.ResultsUpdated += results =>
            {
                var prop = (double)results.NumberOfHits / (double)results.Iteration;
                Console.WriteLine($"Iteration: {results.Iteration} " +
                                  $"Hits: {results.NumberOfHits}" +
                                  $"Probability: {prop}");
            };

        }

    }
}
