using System;
using System.Collections.Generic;
using System.Diagnostics;

using PerformanceMeasurer.Core.GrowingInput;

namespace PerformanceMeasurer.Core
{
    public class GrowingInputExperimentRunner
    {
        public GrowingInputExperimentResult Run<T>(IGrowingInputExperiment<T> growingInputExperiment)
        {
            var probeResults = new List<GrowingInputProbeResult>();
            var sizeSettings = growingInputExperiment.InputSettings;
            foreach (var probe in growingInputExperiment.GetProbes())
            {
                //heatup
                probe(growingInputExperiment.Generate(sizeSettings.From));

                var measurements = new List<SizeMeasurement>();
                var size = sizeSettings.From;
                while (size <= sizeSettings.To)
                {
                    var input = growingInputExperiment.Generate(size);

                    GC.Collect();
                    var sw = Stopwatch.StartNew();
                    probe(input);
                    sw.Stop();

                    measurements.Add(new SizeMeasurement(size, sw.Elapsed));

                    size = sizeSettings.NextSize(size);
                }

                probeResults.Add(new GrowingInputProbeResult(probe.Method.Name, measurements));
            }

            return new GrowingInputExperimentResult(growingInputExperiment.GetType().Name, probeResults);
        }
    }
}