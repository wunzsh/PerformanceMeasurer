using System;
using System.Collections.Generic;
using System.IO;

using PerformanceMeasurer.Core.Repeat;

namespace PerformanceMeasurer.Samples
{
    public class StringSortExperiment : IRepeatExperiment
    {
        private readonly string _file;

        private string[] _values;
        private readonly LsdSort _lsdSort = new LsdSort();

        public StringSortExperiment(string file)
        {
            _file = file;
        }

        public RepeatSettings RepeatSettings
        {
            get
            {
                return new RepeatSettings(10);
            }
        }

        public IEnumerable<Action> GetProbes()
        {
            yield return BuildInSort;
            yield return CustomLsdSort;

        }

        private void BuildInSort()
        {
            Array.Sort(_values);
        }

        private void CustomLsdSort()
        {
            _lsdSort.Sort(_values);
        }

        public void BeforeProbeRun()
        {
            _values = File.ReadAllText(_file).Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}