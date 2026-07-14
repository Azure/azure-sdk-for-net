// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Represents a synchronous sequence of values read from a streaming service
/// response.
/// </summary>
/// <typeparam name="T">The type of values in the response stream.</typeparam>
/// <remarks>
/// A <see cref="StreamingClientResult{T}"/> can be enumerated only once.
/// Disposing the enumerator or the result disposes the underlying response.
/// </remarks>
public abstract class StreamingClientResult<T> : ClientResult, IEnumerable<T>, IDisposable
{
    private readonly object _sync = new();
    private bool _enumerationStarted;
    private bool _disposed;
    private StreamingEnumerator? _activeEnumerator;

    /// <summary>
    /// Creates a new instance of <see cref="StreamingClientResult{T}"/>.
    /// </summary>
    /// <param name="response">The response containing the value stream.</param>
    protected internal StreamingClientResult(PipelineResponse response)
        : base(response)
    {
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        lock (_sync)
        {
            if (_enumerationStarted)
            {
                throw new InvalidOperationException("A streaming result can be enumerated only once.");
            }

            ThrowIfDisposed();
            _enumerationStarted = true;

            try
            {
                StreamingEnumerator enumerator = new(this, GetValues().GetEnumerator());
                _activeEnumerator = enumerator;
                return enumerator;
            }
            catch
            {
                Dispose();
                throw;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Gets the values read from the response stream.
    /// </summary>
    /// <returns>The values read from the response stream.</returns>
    protected abstract IEnumerable<T> GetValues();

    /// <summary>
    /// Disposes the underlying response.
    /// </summary>
    public void Dispose()
    {
        StreamingEnumerator? enumerator;
        lock (_sync)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            enumerator = _activeEnumerator;
            _activeEnumerator = null;
        }

        try
        {
            enumerator?.DisposeFromResult();
        }
        finally
        {
            GetRawResponse().Dispose();
        }

        GC.SuppressFinalize(this);
    }

    private void CompleteEnumeration(StreamingEnumerator enumerator)
    {
        lock (_sync)
        {
            if (ReferenceEquals(_activeEnumerator, enumerator))
            {
                _activeEnumerator = null;
            }
        }
        Dispose();
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }

    private sealed class StreamingEnumerator(
        StreamingClientResult<T> result,
        IEnumerator<T> inner) : IEnumerator<T>
    {
        private int _disposed;

        public T Current => inner.Current;

        object? IEnumerator.Current => Current;

        public bool MoveNext()
        {
            try
            {
                bool hasNext = inner.MoveNext();
                if (!hasNext)
                {
                    Dispose();
                }
                return hasNext;
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        public void Reset()
            => throw new NotSupportedException("A streaming result cannot be reset.");

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                try
                {
                    inner.Dispose();
                }
                finally
                {
                    result.CompleteEnumeration(this);
                }
            }
        }

        public void DisposeFromResult()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                inner.Dispose();
            }
        }
    }
}
