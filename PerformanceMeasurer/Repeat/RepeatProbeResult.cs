using System;
using System.Collections.Generic;

namespace PerformanceMeasurer.Core.Repeat
{
    public class RepeatProbeResult : ProbeResult<TimeSpan>
    {
        public RepeatProbeResult(string name, IEnumerable<TimeSpan> measurements)
            : base(name, measurements)
        {
        }
    }
}