using System;
using System.Diagnostics;

namespace PerformanceMeasurer.Core
{
    public static class DebugerNotAttached
    {
        public static void Check()
        {
            if (Debugger.IsAttached)
            {
                //throw new Exception("Debugger attached. Results might be unreliable.");
            }
        }

    }
}