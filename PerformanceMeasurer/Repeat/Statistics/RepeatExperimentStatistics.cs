using System.Collections.Generic;
using System.Linq;

namespace PerformanceMeasurer.Core.Repeat.Statistics
{
    public class RepeatExperimentStatistics
    {
        private RepeatExperimentStatistics(string name, IEnumerable<ProbeStatistic> probeStatistics)
        {
            Name = name;
            ProbeStatistics = probeStatistics;
        }

        public string Name { get; private set; }

        public IEnumerable<ProbeStatistic> ProbeStatistics { get; private set; }

        public static RepeatExperimentStatistics Create(RepeatExperimentResult repeatExperimentResult)
        {
            var probeStatistics =
                repeatExperimentResult.Results.Select(
                    x => new ProbeStatistic(x.Name, x.Measurements.Select(y => y.TotalMilliseconds).Average(z => z)))
                  .ToArray();

            return new RepeatExperimentStatistics(repeatExperimentResult.Name, probeStatistics);
        }
    }
}