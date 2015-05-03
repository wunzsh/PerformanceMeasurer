using System.Collections.Generic;

namespace PerformanceMeasurer.Core.GrowingInput
{
    public class GrowingInputExperimentResult : ExperimentResult<GrowingInputProbeResult>
    {
        public GrowingInputExperimentResult(string name, IEnumerable<GrowingInputProbeResult> results)
            : base(name, results)
        {
        }
    }
}