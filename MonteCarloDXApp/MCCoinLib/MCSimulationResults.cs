namespace MCCoinLib
{
    public class MCSimulationResults
    {
        public long Iteration { get; }
        public long NumberOfHits { get; }

        public MCSimulationResults(long iteration, long numberOfHits)
        {
            Iteration = iteration;
            NumberOfHits = numberOfHits;
        }

    }
}