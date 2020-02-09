﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCCoinLib.RandomEngines;
using QuasiRandomGeneratorsLib;

namespace MCCoinLib
{
    public delegate void IntermediateResultsHandler(MCCoinResults results);

    public delegate void SimulationFinishedHandler(MCCoinResults results);

    public class MCCoinSimulation
    {
        public event IntermediateResultsHandler ResultsUpdated;
        public event SimulationFinishedHandler Finished;
        public MCCoinSettings McCoinSettings { get; }
        public IRandom2DEngine Random2DEngine { get; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mcCoinSettings">MCCoinSettings parameter</param>
        /// <param name="random2DEngine">Default random engine is HaltonSequence2DEngine</param>
        public MCCoinSimulation(MCCoinSettings mcCoinSettings, IRandom2DEngine random2DEngine = null)
        {
            McCoinSettings = mcCoinSettings ?? throw new ArgumentNullException(nameof(mcCoinSettings));
            Random2DEngine = random2DEngine ?? HaltonSequence2DEngine.Create();
        }

        public double Run(Coin coin, SquareTile squareTile)
        {
            if (coin == null) throw new ArgumentNullException(nameof(coin));
            if (squareTile == null) throw new ArgumentNullException(nameof(squareTile));

            var samples = Random2DEngine.GetDoubles().Take(this.McCoinSettings.NumberTrials);
            long nNumberOfHits = 0;
            long nIterations = 0;

            foreach (Tuple<double, double> xySample in samples)
            {
                ++nIterations;
                var dX = xySample.Item1;
                var dY = xySample.Item2;

                if (squareTile.CollisionCheckWithCoin(dX, dY, coin.Radius))
                {
                    ++nNumberOfHits;
                    if (nIterations % McCoinSettings.ReportEveryIteration == 0)
                    {
                        OnResultsUpdated(new MCCoinResults(nIterations, nNumberOfHits));
                    }
                }
            }

            var probability = (double) nNumberOfHits / nIterations;
            OnFinished(new MCCoinResults(nIterations, nNumberOfHits));
            return probability;
        }


        protected virtual void OnResultsUpdated(MCCoinResults results)
        {
            ResultsUpdated?.Invoke(results);
        }

        protected virtual void OnFinished(MCCoinResults results)
        {
            Finished?.Invoke(results);
        }
    }
}