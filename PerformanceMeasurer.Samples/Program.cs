using PerformanceMeasurer.Core.GrowingInput;
using PerformanceMeasurer.Core.Repeat;
using PerformanceMeasurer.Core.Repeat.Statistics;
using PerformanceMeasurer.Output;

namespace PerformanceMeasurer.Samples
{
    static class Program
    {
        static void Main()
        {
            RunGrowingInputExperiment();

            RunRepeatExperiment();
        }

        private static void RunRepeatExperiment()
        {
            var experimentRunner = new RepeatExperimentRunner();
            var res = experimentRunner.Run(new StringSortExperiment("p022_names.txt"));
            var statistics = RepeatExperimentStatistics.Create(res);
            new CsvRepeatExperimentOutput("./").Output(statistics, "repeatResult");
        }

        private static void RunGrowingInputExperiment()
        {
            var experimentRunner = new GrowingInputExperimentRunner();
            var res = experimentRunner.Run(new StringBuilderVsConcat());
            new CsvGrowingInputExperimentResultOutput("./").Output(res, "growingResult");
        }
    }
}
