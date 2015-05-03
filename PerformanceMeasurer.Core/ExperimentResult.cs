using System.Collections.Generic;

namespace PerformanceMeasurer
{
    public class ExperimentResult
    {
        public string Name { get; private set; }
        public IEnumerable<ProbeResult> ProbeResults { get; private set; }

        public ExperimentResult(string name, IEnumerable<ProbeResult> probeResults)
        {
            Name = name;
            ProbeResults = probeResults;
        }
    }
}