using System;
using System.Collections.Generic;

namespace PerformanceMeasurer.Samples
{
    public class MulVersusSumExperiment : IExperiment<int>
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

