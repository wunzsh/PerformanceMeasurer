using System;
using System.Collections.Generic;

namespace PerformanceMeasurer.Core.Repeat
{
    public interface IRepeatExperiment
    {
        RepeatSettings RepeatSettings { get; }

        IEnumerable<Action> GetProbes();

        void BeforeProbeRun();
    }
}