using System;

namespace MCCoinLib
{
    public class MCSimulationSettings
    {
        public int NumberTrials { get; }
        public int ReportEveryIteration { get; }

        protected MCSimulationSettings(int numberTrials, int reportEveryIteration)
        {
            NumberTrials = numberTrials;
            ReportEveryIteration = reportEveryIteration;
        }

        public static MCSimulationSettings Create(int numberTrials, int reportEveryIteration = 1)
        {
            if (numberTrials <= 0) throw new ArgumentOutOfRangeException(nameof(numberTrials));
            if (reportEveryIteration <= 0) throw new ArgumentOutOfRangeException(nameof(reportEveryIteration));

            return new MCSimulationSettings(
                numberTrials,
                reportEveryIteration
            );
        }

        public override string ToString()
        {
            return
                $"{nameof(NumberTrials)}: {NumberTrials}";
        }
    }
}