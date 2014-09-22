using System.Collections.Generic;

namespace PerformanceMeasurer
{
    public class ProbeResult
    {
        public string Name { get; set; }
        public IEnumerable<Measurement> Measurments { get; set; }

        public ProbeResult(string name, IEnumerable<Measurement> measurments)
        {
            Name = name;
            Measurments = measurments;
        }
    }
}