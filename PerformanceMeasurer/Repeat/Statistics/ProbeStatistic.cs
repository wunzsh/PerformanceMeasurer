namespace PerformanceMeasurer.Core.Repeat.Statistics
{
    public class ProbeStatistic
    {
        public string ProbeName { get; set; }

        public double Average { get; set; }

        public ProbeStatistic(string probeName, double average)
        {
            ProbeName = probeName;
            Average = average;
        }
    }
}