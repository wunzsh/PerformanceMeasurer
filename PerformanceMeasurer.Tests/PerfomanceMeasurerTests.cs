using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PerformanceMeasurer.Core.GrowingInput;
using PerformanceMeasurer.Output;

namespace PerformanceMeasurer.Tests
{
    [TestClass]
    public class PerfomanceMeasurerTests
    {
        [TestMethod]
        public void IntegrationTest()
        {
            Console.WriteLine(Debugger.IsAttached);
            var experimentRunner = new GrowingInputExperimentRunner();
            var res = experimentRunner.Run(new SomeGrowingInputExperiment());
            new CsvGrowingInputExperimentResultOutput("./").Output(res, "result");
        }

        private class SomeGrowingInputExperiment : IGrowingInputExperiment<int>
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
