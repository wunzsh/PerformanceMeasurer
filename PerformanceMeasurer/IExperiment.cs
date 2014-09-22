using System;
using System.Collections.Generic;

namespace PerformanceMeasurer
{
    public interface IExperiment<TInput>
    {
        InputSettings InputSettings { get; }

        IEnumerable<Action<TInput>> GetProbes();

        TInput Generate(int size);
    }
}