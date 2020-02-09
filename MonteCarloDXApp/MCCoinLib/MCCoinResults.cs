namespace MCCoinLib
{
    public class MCCoinResults
    {
        public long Iteration { get; }
        public long NumberOfHits { get; }

        public MCCoinResults(long iteration, long numberOfHits)
        {
            Iteration = iteration;
            NumberOfHits = numberOfHits;
        }

    }
}