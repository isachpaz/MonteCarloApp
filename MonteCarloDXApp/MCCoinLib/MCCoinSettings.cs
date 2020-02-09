using System;

namespace MCCoinLib
{
    public class MCCoinSettings
    {
        public int NumberTrials { get; }
        public int ReportEveryIteration { get; }

        protected MCCoinSettings(int numberTrials, int reportEveryIteration)
        {
            NumberTrials = numberTrials;
            ReportEveryIteration = reportEveryIteration;
        }

        public static MCCoinSettings Create(int numberTrials, int reportEveryIteration = 1)
        {
            if (numberTrials <= 0) throw new ArgumentOutOfRangeException(nameof(numberTrials));
            if (reportEveryIteration <= 0) throw new ArgumentOutOfRangeException(nameof(reportEveryIteration));

            return new MCCoinSettings(
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