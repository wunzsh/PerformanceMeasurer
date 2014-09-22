using System;
using System.IO;
using System.Text;
using System.Linq;

namespace PerformanceMeasurer
{
    public class CsvExperimentResultOutput
    {
        private const string Separator = "\t";
        private readonly string _outputPath;

        public CsvExperimentResultOutput(string outputPath)
        {
            _outputPath = outputPath;
        }

        public void Output(ExperimentResult experimentResult)
        {
            if (!experimentResult.ProbeResults.Any())
            {
                throw new ArgumentException("No probes to output");
            }

            if (!Directory.Exists(_outputPath))
            {
                Directory.CreateDirectory(_outputPath);
            }

            var output = GetMergedOutput(experimentResult);

            var fileName = Path.Combine(_outputPath, experimentResult.Name+".txt");
            File.WriteAllText(fileName, output);
        }

        private string GetMergedOutput(ExperimentResult experimentResult)
        {
            var sb = new StringBuilder();
            
            if (System.Diagnostics.Debugger.IsAttached)
            {
                sb.AppendLine("Warning. Experiment was executed under debugger. Results may be unrelaiable.");
            }

            sb.AppendLine(experimentResult.Name);
            sb.AppendLine(" " + Separator + experimentResult.ProbeResults.Select(x => x.Name).Join(Separator));

            var sizesGroups = experimentResult.ProbeResults
                .SelectMany(x => x.Measurments)
                .GroupBy(x => x.Size);
            
            foreach( var group in sizesGroups)
            {
                sb.AppendLine(group.Key + Separator + group.Select(x => x.Duration.TotalMilliseconds.ToString()).Join(Separator));
            }

            return sb.ToString();
        }
    }
}