using System;
using System.Collections.Generic;

namespace MCCoinLib.RandomEngines
{
    public interface IRandom2DEngine
    {
        IEnumerable<Tuple<double, double>> GetDoubles();
    }
}