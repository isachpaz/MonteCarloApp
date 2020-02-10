using System.Collections.Generic;

namespace MCCoinLib.RandomEngines
{
    public class Random2DEngineService
    {
        private Dictionary<SamplingMethod, IRandom2DEngine> _dicEngines = new Dictionary<SamplingMethod, IRandom2DEngine>();

        public Random2DEngineService()
        {
            _dicEngines.Add(SamplingMethod.Halton, HaltonSequence2DEngine.Create());
            _dicEngines.Add(SamplingMethod.RandomUniform, new RandomSequence2DEngine());
        }

        public IRandom2DEngine GetEngine(SamplingMethod method)
        {
            return _dicEngines[method];
        }
    }
}