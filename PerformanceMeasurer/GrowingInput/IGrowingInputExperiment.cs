using System;
using System.Collections.Generic;

namespace PerformanceMeasurer.Core.GrowingInput
{
    public interface IGrowingInputExperiment<TInput>
    {
        InputSettings InputSettings { get; }

        IEnumerable<Action<TInput>> GetProbes();

        TInput Generate(int size);
    }
}