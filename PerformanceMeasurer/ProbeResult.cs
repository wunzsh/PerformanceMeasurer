using System.Collections.Generic;

namespace PerformanceMeasurer.Core
{
    public class ProbeResult<T>
    {
        public string Name { get; private set; }
        public IEnumerable<T> Measurements { get; set; }

        public ProbeResult(string name, IEnumerable<T> measurements)
        {
            Name = name;
            Measurements = measurements;
        }
    }
}