namespace PerformanceMeasurer.Core.Repeat
{
    public class RepeatSettings
    {
        public int RepeatTimes { get; private set; }

        public RepeatSettings(int repeatTimes)
        {
            RepeatTimes = repeatTimes;
        }
    }
}