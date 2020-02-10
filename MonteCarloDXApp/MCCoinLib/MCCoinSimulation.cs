using System;
using System.Linq;
using MCCoinLib.RandomEngines;

namespace MCCoinLib
{
    public delegate void IntermediateResultsHandler(MCSimulationResults results);

    public delegate void SimulationFinishedHandler(MCSimulationResults results);

    public class MCCoinSimulation
    {
        public event IntermediateResultsHandler ResultsUpdated;
        public event SimulationFinishedHandler Finished;
        public MCSimulationSettings SimulationSettings { get; }
        public IRandom2DEngine Random2DEngine { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mcSimulationSettings">MCCoinSettings parameter</param>
        /// <param name="random2DEngine">Default random engine is HaltonSequence2DEngine</param>
        public MCCoinSimulation(MCSimulationSettings mcSimulationSettings, IRandom2DEngine random2DEngine = null)
        {
            SimulationSettings = mcSimulationSettings ?? throw new ArgumentNullException(nameof(mcSimulationSettings));
            Random2DEngine = random2DEngine ?? HaltonSequence2DEngine.Create();
        }

        public double Run(Coin coin, SquareTile squareTile)
        {
            if (coin == null) throw new ArgumentNullException(nameof(coin));
            if (squareTile == null) throw new ArgumentNullException(nameof(squareTile));

            var samples = Random2DEngine.GetDoubles().Take(this.SimulationSettings.NumberTrials);
            long nNumberOfHits = 0;
            long nIterations = 0;

            foreach (Tuple<double, double> xySample in samples)
            {
                ++nIterations;
                var cordinatesOnSquareTile = squareTile.TransformCoordinates(xySample);
                var dX = cordinatesOnSquareTile.Item1;
                var dY = cordinatesOnSquareTile.Item2;
                
                if (squareTile.CollisionCheckWithCoin(dX, dY, coin.Radius))
                {
                    ++nNumberOfHits;
                    if (nIterations % SimulationSettings.ReportEveryIteration == 0)
                    {
                        OnResultsUpdated(new MCSimulationResults(nIterations, nNumberOfHits));
                    }
                }
            }

            var probability = (double) nNumberOfHits / nIterations;
            OnFinished(new MCSimulationResults(nIterations, nNumberOfHits));
            return probability;
        }


        protected virtual void OnResultsUpdated(MCSimulationResults results)
        {
            ResultsUpdated?.Invoke(results);
        }

        protected virtual void OnFinished(MCSimulationResults results)
        {
            Finished?.Invoke(results);
        }
    }
}