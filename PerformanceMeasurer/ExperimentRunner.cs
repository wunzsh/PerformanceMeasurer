using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceMeasurer
{
    public class ExperimentRunner
    {
        public ExperimentResult Run<T>(IExperiment<T>  experiment)
        {
            var probeResults = new List<ProbeResult>();
            var sizeSettings = experiment.InputSettings;
            foreach (var probe in experiment.GetProbes())
            {
                //heatup
                probe(experiment.Generate(sizeSettings.From));

                var measurements = new List<Measurement>();
                var size = sizeSettings.From;
                while (size <= sizeSettings.To)
                {
                    var input = experiment.Generate(size);

                    GC.Collect();
                    var sw = Stopwatch.StartNew();
                    probe(input);
                    sw.Stop();

                    measurements.Add(new Measurement(size, sw.Elapsed));

                    size = sizeSettings.NextSize(size);
                }

                probeResults.Add(new ProbeResult(probe.Method.Name, measurements));
            }

            return new ExperimentResult(experiment.GetType().Name, probeResults);
        }
    }
}