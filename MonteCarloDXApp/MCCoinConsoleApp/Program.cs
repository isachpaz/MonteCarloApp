using System;
using MCCoinLib;
using MCCoinLib.RandomEngines;

namespace MCCoinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = MCSimulationSettings.Create(numberTrials: 1000000, reportEveryIteration: 10000);
            var randomEngineService = new Random2DEngineService();

            var simulation = new MCCoinSimulation(settings, randomEngineService);

            simulation.ResultsUpdated += results =>
            {
                var prop = (double) results.NumberOfHits / (double) results.Iteration;
                Console.WriteLine($"Iteration: {results.Iteration} " +
                                  $"Hits: {results.NumberOfHits} " +
                                  $"Probability: {prop}");
            };

            simulation.Finished += results => { Console.WriteLine($"MC simulation finished.\n{results}"); };

            simulation.Run(Coin.CreateWithDiameter(1.0),
                SquareTile.Create(10.0),
                SamplingMethod.RandomUniform);
            Console.ReadKey();
        }
    }
}