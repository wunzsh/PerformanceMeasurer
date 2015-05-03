using System.IO;

namespace PerformanceMeasurer.Output
{
    public abstract class CsvOutput<T>
    {
        private const string DefaultSeparator = "\t";

        private readonly string _outputPath;
        protected readonly string Separator;

        public CsvOutput(string outputPath, string separator)
        {
            _outputPath = outputPath;
            Separator = separator;
        }

        public CsvOutput(string outputPath)
            : this(outputPath, DefaultSeparator)
        {
        }

        public void Output(T results, string name)
        {
            if (!Directory.Exists(_outputPath))
            {
                Directory.CreateDirectory(_outputPath);
            }

            var output = GetMergedOutput(results);

            var fileName = Path.Combine(_outputPath, name + ".txt");
            File.WriteAllText(fileName, output);
        }

        protected abstract string GetMergedOutput(T repeatExperimentStatistics);
    }
}