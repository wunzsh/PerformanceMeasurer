using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PerformanceMeasurer.Core.GrowingInput;

namespace PerformanceMeasurer.Samples
{
    public class StringBuilderVsConcat : IGrowingInputExperiment<string[]>
    {
        public InputSettings InputSettings
        {
            get { return new InputSettings(2, 256); }
        }

        public IEnumerable<Action<string[]>> GetProbes()
        {
            yield return StringBuilder;
            yield return Concat;
        }

        private void Concat(string[] input )
        {
            var res = string.Empty;
            for(var i = 0; i < input.Length; i++)
            {
                res += input[i];
            }
        }

        private void StringBuilder(string[] input)
        {
            var sb = new StringBuilder(input.Count());
            for (var i = 0; i < input.Length; i++)
            {
              
                sb.Append(input[i]);
            }

            var res = sb.ToString();
        }

        public string[] Generate(int size)
        {
            const int length = 20;
            var sample = "".PadRight(length, 'a');

            var res = new string[size];
            for (var i = 0; i < size; i++)
            {
                res[i] = sample;
            }

            return res;
        }
    }
}