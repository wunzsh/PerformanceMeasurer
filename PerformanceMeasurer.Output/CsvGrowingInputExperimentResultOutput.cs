using System.Linq;
using System.Text;

using PerformanceMeasurer.Core.GrowingInput;

namespace PerformanceMeasurer.Output
{
    public class CsvGrowingInputExperimentResultOutput : CsvOutput<GrowingInputExperimentResult>
    {
        public CsvGrowingInputExperimentResultOutput(string outputPath, string separator)
            : base(outputPath, separator)
        {
        }

        public CsvGrowingInputExperimentResultOutput(string outputPath)
            : base(outputPath)
        {
        }

        protected override string GetMergedOutput(GrowingInputExperimentResult experimentResult)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(experimentResult.Name);
            sb.AppendLine(" " + Separator + experimentResult.Results
                                                             .Select(x => x.Name)
                                                             .Join(Separator));

            var sizesGroups = experimentResult.Results
                                              .SelectMany(x => x.Measurements)
                                              .GroupBy(x => x.Size);
            
            foreach( var group in sizesGroups)
            {
                sb.AppendLine(group.Key + Separator + group.Select(x => x.Duration.TotalMilliseconds.ToString())
                                                            .Join(Separator));
            }

            return sb.ToString();
        }

    }
}