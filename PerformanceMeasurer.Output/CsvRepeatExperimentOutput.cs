using System.Linq;
using System.Text;

using PerformanceMeasurer.Core.Repeat.Statistics;

namespace PerformanceMeasurer.Output
{
    public class CsvRepeatExperimentOutput : CsvOutput<RepeatExperimentStatistics>
    {
        public CsvRepeatExperimentOutput(string outputPath, string separator)
            : base(outputPath, separator)
        {
        }

        public CsvRepeatExperimentOutput(string outputPath)
            : base(outputPath)
        {
        }

        protected override string GetMergedOutput(RepeatExperimentStatistics repeatExperimentStatistics)
        {
            var sb = new StringBuilder();

            sb.AppendLine(repeatExperimentStatistics.Name);
            foreach (var probeStatistic in repeatExperimentStatistics.ProbeStatistics.OrderBy(x => x.Average))
            {
                sb.AppendLine(probeStatistic.ProbeName + Separator + probeStatistic.Average);
            }

            return sb.ToString();
        }
    }
}