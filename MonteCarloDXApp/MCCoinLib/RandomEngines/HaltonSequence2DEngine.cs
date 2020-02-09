using System;
using System.Collections.Generic;
using QuasiRandomGeneratorsLib;

namespace MCCoinLib.RandomEngines
{
    public class HaltonSequence2DEngine : IRandom2DEngine
    {
        QuasiRandomGeneratorsLib.HaltonSequence2D _seq = new HaltonSequence2D();

        public IEnumerable<Tuple<double, double>> GetDoubles()
        {
            return _seq.GetDoubles();
        }

        public static IRandom2DEngine Create()
        {
            return new HaltonSequence2DEngine();
        }
    }
}