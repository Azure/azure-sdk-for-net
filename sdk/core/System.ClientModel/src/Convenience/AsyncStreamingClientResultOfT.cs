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
/// Enumerating a disposed result throws <see cref="ObjectDisposedException"/>;
/// requesting a second enumerator throws <see cref="InvalidOperationException"/>.
/// </remarks>
public abstract class AsyncStreamingClientResult<T> : AsyncStreamingClientResult, IAsyncEnumerable<T>
{
    private readonly object _sync = new();
    private bool _enumerationStarted;
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

    internal override async ValueTask<bool> DisposeResultAsync()
    {
        StreamingAsyncEnumerator? enumerator;
        lock (_sync)
        {
            enumerator = _activeEnumerator;
        }

        if (enumerator is null)
        {
            return true;
        }

        bool disposalCompleted =
            await enumerator.DisposeFromResultAsync().ConfigureAwait(false);
        if (disposalCompleted)
        {
            lock (_sync)
            {
                if (ReferenceEquals(_activeEnumerator, enumerator))
                {
                    _activeEnumerator = null;
                }
            }
        }

        return disposalCompleted;
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

    private sealed class StreamingAsyncEnumerator(
        AsyncStreamingClientResult<T> result,
        IAsyncEnumerator<T> inner) : IAsyncEnumerator<T>
    {
        private readonly object _disposeSync = new();
        private readonly TaskCompletionSource<object?> _disposeCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly AsyncLocal<bool> _isDisposing = new();
        private bool _disposeStarted;

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
            try
            {
                await DisposeInnerAsync().ConfigureAwait(false);
            }
            finally
            {
                await result.CompleteEnumerationAsync(this)
                    .ConfigureAwait(false);
            }
        }

        public ValueTask<bool> DisposeFromResultAsync() => DisposeInnerAsync();

        private async ValueTask<bool> DisposeInnerAsync()
        {
            bool disposeInner;
            lock (_disposeSync)
            {
                disposeInner = !_disposeStarted;
                _disposeStarted = true;
            }

            if (!disposeInner && _isDisposing.Value)
            {
                return false;
            }

            if (disposeInner)
            {
                _isDisposing.Value = true;
                try
                {
                    await inner.DisposeAsync().ConfigureAwait(false);
                    _disposeCompletion.TrySetResult(null);
                }
                catch (Exception ex)
                {
                    _disposeCompletion.TrySetException(ex);
                }
                finally
                {
                    _isDisposing.Value = false;
                }
            }

            await _disposeCompletion.Task.ConfigureAwait(false);
            return true;
        }
    }
}
