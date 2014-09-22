namespace PerformanceMeasurer.Samples
{
    static class Program
    {
        static void Main()
        {
            var experimentRunner = new ExperimentRunner<int>();
            var res = experimentRunner.Run(new MulVersusSumExperiment());
            new CsvExperimentResultOutput("./").Output(res);
        }
    }
}
