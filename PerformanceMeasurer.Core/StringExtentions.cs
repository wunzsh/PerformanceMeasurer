using System.Collections.Generic;
using System.Text;

namespace PerformanceMeasurer
{
    public static class StringExtentions
    {
        public static string Join(this IEnumerable<string> input, string separator)
        {
            var sb = new StringBuilder();
            foreach (var str in input)
            {
                sb.Append(str + separator);
            }

            return sb.ToString();
        }
    }
}