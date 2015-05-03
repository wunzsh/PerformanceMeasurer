using System.Collections.Generic;

namespace PerformanceMeasurer.Core
{
    public class ExperimentResult<T>
    {
        public string Name { get; private set; }
        public IEnumerable<T> Results { get; private set; }

        public ExperimentResult(string name, IEnumerable<T> results)
        {
            Name = name;
            Results = results;
        }
    }
}