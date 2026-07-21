// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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
/// Enumerating a disposed result throws <see cref="ObjectDisposedException"/>;
/// requesting a second enumerator throws <see cref="InvalidOperationException"/>.
/// </remarks>
public abstract class StreamingClientResult<T> : StreamingClientResult, IEnumerable<T>
{
    private readonly object _enumerationSync = new();
    private bool _enumerationStarted;
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
        lock (_enumerationSync)
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

    internal override bool DisposeResult()
    {
        StreamingEnumerator? enumerator;
        lock (_enumerationSync)
        {
            enumerator = _activeEnumerator;
        }

        if (enumerator is null)
        {
            return true;
        }

        bool disposalCompleted = enumerator.DisposeFromResult();
        if (disposalCompleted)
        {
            lock (_enumerationSync)
            {
                if (ReferenceEquals(_activeEnumerator, enumerator))
                {
                    _activeEnumerator = null;
                }
            }
        }

        return disposalCompleted;
    }

    private void CompleteEnumeration(StreamingEnumerator enumerator)
    {
        lock (_enumerationSync)
        {
            if (ReferenceEquals(_activeEnumerator, enumerator))
            {
                _activeEnumerator = null;
            }
        }
        Dispose();
    }

    private sealed class StreamingEnumerator(
        StreamingClientResult<T> result,
        IEnumerator<T> inner) : IEnumerator<T>
    {
        private readonly object _disposeSync = new();
        private bool _disposeStarted;
        private bool _disposeCompleted;
        private int _disposeThreadId;
        private ExceptionDispatchInfo? _disposeException;

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
            try
            {
                DisposeInner();
            }
            finally
            {
                result.CompleteEnumeration(this);
            }
        }

        public bool DisposeFromResult() => DisposeInner();

        private bool DisposeInner()
        {
            bool disposeInner;
            lock (_disposeSync)
            {
                disposeInner = !_disposeStarted;
                _disposeStarted = true;
                if (disposeInner)
                {
                    _disposeThreadId = Environment.CurrentManagedThreadId;
                }

                while (!disposeInner && !_disposeCompleted)
                {
                    if (_disposeThreadId == Environment.CurrentManagedThreadId)
                    {
                        return false;
                    }

                    Monitor.Wait(_disposeSync);
                }

                if (!disposeInner)
                {
                    _disposeException?.Throw();
                    return true;
                }
            }

            ExceptionDispatchInfo? exception = null;
            try
            {
                inner.Dispose();
            }
            catch (Exception ex)
            {
                exception = ExceptionDispatchInfo.Capture(ex);
            }
            finally
            {
                lock (_disposeSync)
                {
                    _disposeException = exception;
                    _disposeCompleted = true;
                    _disposeThreadId = 0;
                    Monitor.PulseAll(_disposeSync);
                }
            }

            exception?.Throw();
            return true;
        }
    }
}
