using System.Collections.Generic;

namespace PerformanceMeasurer.Core.GrowingInput
{
    public class GrowingInputProbeResult : ProbeResult<Measurement>
    {
        public GrowingInputProbeResult(string name, IEnumerable<Measurement> measurements)
            : base(name, measurements)
        {
        }
    }
}