using System;
using System.Linq;

namespace PerformanceMeasurer.Samples
{
    public class LsdSort
    {
        private const int R = 256;

        public void Sort(string[] input)
        {

            var d = input.Max(x => x.Length);
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim('\"').PadRight(d, ' ');
            }

            var aux = new string[input.Length];

            for (var i = d - 1; i >= 0; i--)
            {
                var count = new int[R + 1];

                for (var j = 0; j < input.Length; j++)
                {
                    count[input[j][i] + 1]++;
                }

                for (var j = 0; j < R; j++)
                {
                    count[j + 1] = count[j + 1] + count[j];
                }

                for (var j = 0; j < input.Length; j++)
                {
                    aux[count[input[j][i]]++] = input[j];
                }

                Array.Copy(aux, input, aux.Length);
            }
        } 
    }
}