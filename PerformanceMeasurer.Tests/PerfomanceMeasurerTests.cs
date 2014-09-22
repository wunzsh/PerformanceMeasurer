using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerformanceMeasurer.Tests
{
    [TestClass]
    public class PerfomanceMeasurerTests
    {
        [TestMethod]
        public void IntegrationTest()
        {
            Console.WriteLine(System.Diagnostics.Debugger.IsAttached);
            var experimentRunner = new ExperimentRunner<int>();
            var res = experimentRunner.Run(new SomeExperiment());
            new CsvExperimentResultOutput("./").Output(res);
        }

        private class SomeExperiment : IExperiment<int>
        {
            public InputSettings InputSettings
            {
                get { return new InputSettings(2, 200000); }
            }

            public IEnumerable<Action<int>> GetProbes()
            {
                yield return TestSum;
                yield return TestMul;
            }

            private void TestSum(int input)
            {
                var res = 0;
                for (var i = 0; i < input; i++)
                {
                    res += i;
                }
            }

            private void TestMul(int input)
            {
                var res = 0;
                for (var i = 0; i < input; i++)
                {
                    res *= i;
                }
            }

            public int Generate(int size)
            {
                return size;
            }
        }
    }
}
