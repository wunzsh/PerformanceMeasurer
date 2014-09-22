using System.Collections.Generic;

namespace PerformanceMeasurer
{
    public class ExperimentResult
    {
        public string Name { get; set; }
        public IEnumerable<ProbeResult> ProbeResults { get; set; }

        public ExperimentResult(string name, IEnumerable<ProbeResult> probeResults)
        {
            Name = name;
            ProbeResults = probeResults;
        }
    }
}