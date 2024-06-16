namespace WhenFresh.Utilities.Core
{
    using System;
    using System.Diagnostics;
    using WhenFresh.Utilities.Core.Diagnostics;

    public abstract class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            Dispose(false);
        }

        private bool Disposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void OnDispose();

        private void Dispose(bool disposing)
        {
            Trace.WriteIf(Tracing.Is.TraceVerbose, string.Empty);
            if (!Disposed && disposing)
            {
                OnDispose();
            }

            Disposed = true;
        }
    }
}