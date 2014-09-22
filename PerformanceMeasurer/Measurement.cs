using System;

namespace PerformanceMeasurer
{
    public class Measurement
    {
        public int Size { get; private set; }
        public TimeSpan Duration { get; private set; }

        public Measurement(int size, TimeSpan duration)
        {
            Size = size;
            Duration = duration;
        }
    }
}