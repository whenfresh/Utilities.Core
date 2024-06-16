﻿namespace WhenFresh.Utilities.Core.Threading
{
    using System;
    using System.Threading;

    public interface IThreadedObject : IDisposable
    {
        CancellationToken CancellationToken { get; set; }
    }
}