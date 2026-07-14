// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents an asynchronous sequence of values read from a streaming service
/// response.
/// </summary>
/// <typeparam name="T">The type of values in the response stream.</typeparam>
/// <remarks>
/// An <see cref="AsyncStreamingClientResult{T}"/> can be enumerated only once.
/// Disposing the enumerator or the result disposes the underlying response.
/// </remarks>
public abstract class AsyncStreamingClientResult<T> : ClientResult, IAsyncEnumerable<T>, IAsyncDisposable
{
    private readonly object _sync = new();
    private bool _enumerationStarted;
    private bool _disposed;
    private StreamingAsyncEnumerator? _activeEnumerator;

    /// <summary>
    /// Creates a new instance of <see cref="AsyncStreamingClientResult{T}"/>.
    /// </summary>
    /// <param name="response">The response containing the value stream.</param>
    protected internal AsyncStreamingClientResult(PipelineResponse response)
        : base(response)
    {
    }

    /// <inheritdoc/>
    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
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
                StreamingAsyncEnumerator enumerator = new(
                    this,
                    GetValuesAsync(cancellationToken).GetAsyncEnumerator(cancellationToken));
                _activeEnumerator = enumerator;
                return enumerator;
            }
            catch
            {
                DisposeResponse();
                throw;
            }
        }
    }

    /// <summary>
    /// Gets the values read from the response stream.
    /// </summary>
    /// <param name="cancellationToken">The token used to cancel reading from
    /// the response stream.</param>
    /// <returns>The values read from the response stream.</returns>
    protected abstract IAsyncEnumerable<T> GetValuesAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously disposes the active enumerator and underlying response.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        StreamingAsyncEnumerator? enumerator;
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
            if (enumerator is not null)
            {
                await enumerator.DisposeFromResultAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            GetRawResponse().Dispose();
        }

        GC.SuppressFinalize(this);
    }

    private async ValueTask CompleteEnumerationAsync(
        StreamingAsyncEnumerator enumerator)
    {
        lock (_sync)
        {
            if (ReferenceEquals(_activeEnumerator, enumerator))
            {
                _activeEnumerator = null;
            }
        }
        await DisposeAsync().ConfigureAwait(false);
    }

    private void DisposeResponse()
    {
        lock (_sync)
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _activeEnumerator = null;
        }

        GetRawResponse().Dispose();
        GC.SuppressFinalize(this);
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }
    }

    private sealed class StreamingAsyncEnumerator(
        AsyncStreamingClientResult<T> result,
        IAsyncEnumerator<T> inner) : IAsyncEnumerator<T>
    {
        private int _disposed;

        public T Current => inner.Current;

        public async ValueTask<bool> MoveNextAsync()
        {
            try
            {
                bool hasNext = await inner.MoveNextAsync().ConfigureAwait(false);
                if (!hasNext)
                {
                    await DisposeAsync().ConfigureAwait(false);
                }
                return hasNext;
            }
            catch
            {
                await DisposeAsync().ConfigureAwait(false);
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                try
                {
                    await inner.DisposeAsync().ConfigureAwait(false);
                }
                finally
                {
                    await result.CompleteEnumerationAsync(this)
                        .ConfigureAwait(false);
                }
            }
        }

        public async ValueTask DisposeFromResultAsync()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                await inner.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
