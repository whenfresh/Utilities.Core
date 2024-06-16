namespace WhenFresh.Utilities.Core.Diagnostics
{
    using System.Diagnostics;

    internal static class Tracing
    {
        internal static TraceSwitch Is
        {
            get
            {
                return new TraceSwitch("Cavity.Core", string.Empty);
            }
        }
    }
}