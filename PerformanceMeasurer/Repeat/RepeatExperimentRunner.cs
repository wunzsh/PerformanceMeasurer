using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceMeasurer.Core.Repeat
{
    public class RepeatExperimentRunner
    {
        public RepeatExperimentResult Run(IRepeatExperiment repeatExperiment)
        {
            DebugerNotAttached.Check();

            var probeResults = new List<RepeatProbeResult>();
            var repeatSettings = repeatExperiment.RepeatSettings;
            foreach (var probe in repeatExperiment.GetProbes())
            {
                //heatup
                repeatExperiment.BeforeProbeRun();
                probe();

                var durations = new List<TimeSpan>();
                for (var i = 0; i< repeatSettings.RepeatTimes; i++)
                {
                    repeatExperiment.BeforeProbeRun();

                    GC.Collect();
                    var sw = Stopwatch.StartNew();
                    probe();
                    sw.Stop();
                    durations.Add(sw.Elapsed);
                }

                probeResults.Add(new RepeatProbeResult(probe.Method.Name, durations));
            }

            return new RepeatExperimentResult(repeatExperiment.GetType().Name, probeResults);
        }
    }
}