
using System.Collections.Generic;

namespace PerformanceMeasurer.Core.Repeat
{
    public class RepeatExperimentResult:ExperimentResult<RepeatProbeResult>
    {
        public RepeatExperimentResult(string name, IEnumerable<RepeatProbeResult> results)
            : base(name, results)
        {
        }
    }
}