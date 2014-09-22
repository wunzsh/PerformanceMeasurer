namespace PerformanceMeasurer.Samples
{
    static class Program
    {
        static void Main()
        {
            var experimentRunner = new ExperimentRunner();
            var res = experimentRunner.Run(new StringBuilderVsConcat());
            new CsvExperimentResultOutput("./").Output(res);
        }
    }
}
