namespace WhenFresh.Utilities.Threading;

using System.Threading;

public interface IThreadedObject : IDisposable
{
    CancellationToken CancellationToken { get; set; }
}