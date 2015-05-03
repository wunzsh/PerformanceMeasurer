using System;

namespace PerformanceMeasurer.Core.GrowingInput
{
    public class InputSettings
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public Func<int, int> NextSize { get; private set; }

        public InputSettings(int from, int to)
            : this(from, to, x => x * 2)
        {
        }

        public InputSettings(int from, int to, Func<int, int> nextSize)
        {
            if (to < from)
            {
                throw new ArgumentException("'to' must be >= 'from'");
            }

            if (from <= 0)
            {
                throw new ArgumentException("'from' must be > 0");
            }

            From = from;
            To = to;
            NextSize = nextSize;
        }
    }
}