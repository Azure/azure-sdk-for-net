// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
/// The operation cancellation token remains active for the lifetime of the
/// stream and is combined with the token supplied when enumeration begins.
/// Custom producers must observe cancellation or stream closure to terminate;
/// code that ignores both cannot be forcibly stopped by this abstraction.
/// Enumerating a disposed result throws <see cref="ObjectDisposedException"/>;
/// requesting a second enumerator throws <see cref="InvalidOperationException"/>.
/// </remarks>
public sealed class AsyncStreamingClientResult<T> : IAsyncEnumerable<T>, IAsyncDisposable
{
    private readonly PipelineResponse _response;
    private readonly Stream _contentStream;
    private readonly Func<Stream, CancellationToken, IAsyncEnumerable<T>> _producer;
    private readonly CancellationToken _operationCancellationToken;
    private readonly CancellationTokenSource _resultCancellationSource = new();
    private readonly object _sync = new();
    private readonly AsyncLocal<bool> _isEnumeratorDisposing = new();
    private bool _enumerationStarted;
    private bool _disposeStarted;
    private bool _consumptionCancellationRequested;
    private bool _contentStreamClosed;
    private bool _responseDisposed;
    private bool _disposeCoreRunning;
    private TaskCompletionSource<object?>? _resultDisposeCompletion;
    private StreamingAsyncEnumerator? _activeEnumerator;

    internal AsyncStreamingClientResult(
        PipelineResponse response,
        Func<Stream, CancellationToken, IAsyncEnumerable<T>> producer,
        CancellationToken operationCancellationToken)
    {
        _response = response;
        _contentStream = response.ContentStream ?? response.Content.ToStream();
        _producer = producer;
        _operationCancellationToken = operationCancellationToken;
    }

    /// <summary>Gets the status code of the service response.</summary>
    public int Status => _response.Status;

    /// <summary>Gets the reason phrase of the service response.</summary>
    public string ReasonPhrase => _response.ReasonPhrase;

    /// <summary>Gets the headers of the service response.</summary>
    public PipelineResponseHeaders Headers => _response.Headers;

    /// <inheritdoc/>
    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        lock (_sync)
        {
            if (_enumerationStarted)
            {
                throw new InvalidOperationException("A streaming result can be enumerated only once.");
            }

            if (_disposeStarted)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            _enumerationStarted = true;

            CancellationTokenSource? linkedCancellationSource = null;
            try
            {
                linkedCancellationSource =
                    CreateLinkedCancellationSource(cancellationToken);
                CancellationToken combinedCancellationToken =
                    linkedCancellationSource?.Token ??
                    _resultCancellationSource.Token;
                StreamingAsyncEnumerator enumerator = new(
                    this,
                    _producer(_contentStream, combinedCancellationToken)
                        .GetAsyncEnumerator(combinedCancellationToken),
                    linkedCancellationSource);
                _activeEnumerator = enumerator;
                return enumerator;
            }
            catch
            {
                linkedCancellationSource?.Dispose();
                DisposeAfterEnumeratorConstructionFailure();
                throw;
            }
        }
    }

    /// <summary>Asynchronously disposes the result and its response.</summary>
    public ValueTask DisposeAsync()
    {
        bool startDisposeCore = false;
        Task disposeTask;
        bool isReentrant;
        lock (_sync)
        {
            _disposeStarted = true;
            _activeEnumerator?.BeginDisposal();
            _resultDisposeCompletion ??= new(
                TaskCreationOptions.RunContinuationsAsynchronously);

            if (!_resultDisposeCompletion.Task.IsCompleted &&
                !_disposeCoreRunning)
            {
                _disposeCoreRunning = true;
                startDisposeCore = true;
            }

            disposeTask = _resultDisposeCompletion.Task;
            isReentrant = _isEnumeratorDisposing.Value;
        }

        if (startDisposeCore)
        {
            _ = DisposeCoreAsync();
        }

        return isReentrant ? default : new ValueTask(disposeTask);
    }

    private async Task DisposeCoreAsync()
    {
        bool deferred = false;
        try
        {
            CancelConsumption();
            CloseContentStream();

            if (!(await DisposeResultAsync().ConfigureAwait(false)))
            {
                deferred = true;
                return;
            }

            DisposeResponse();
            _resultDisposeCompletion!.TrySetResult(null);
        }
        catch (Exception ex)
        {
            try
            {
                DisposeResponse();
            }
            catch
            {
                // Preserve the exception that initiated disposal failure.
            }
            _resultDisposeCompletion!.TrySetException(ex);
        }
        finally
        {
            lock (_sync)
            {
                _disposeCoreRunning = false;
            }

            if (!deferred && !_resultDisposeCompletion!.Task.IsCompleted)
            {
                _resultDisposeCompletion.TrySetResult(null);
            }
        }
    }

    private async ValueTask<bool> DisposeResultAsync()
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

    private CancellationTokenSource? CreateLinkedCancellationSource(
        CancellationToken enumerationCancellationToken)
    {
        if (_operationCancellationToken.CanBeCanceled &&
            enumerationCancellationToken.CanBeCanceled)
        {
            return CancellationTokenSource.CreateLinkedTokenSource(
                _resultCancellationSource.Token,
                _operationCancellationToken,
                enumerationCancellationToken);
        }

        if (_operationCancellationToken.CanBeCanceled)
        {
            return CancellationTokenSource.CreateLinkedTokenSource(
                _resultCancellationSource.Token,
                _operationCancellationToken);
        }

        if (enumerationCancellationToken.CanBeCanceled)
        {
            return CancellationTokenSource.CreateLinkedTokenSource(
                _resultCancellationSource.Token,
                enumerationCancellationToken);
        }

        return null;
    }

    private Task<bool> StartMoveNext(StreamingAsyncEnumerator enumerator)
    {
        lock (_sync)
        {
            if (_disposeStarted)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }

            return enumerator.StartMoveNext();
        }
    }

    private void CloseContentStream()
    {
        lock (_sync)
        {
            if (_contentStreamClosed)
            {
                return;
            }

            _contentStreamClosed = true;
        }

        _contentStream.Dispose();
    }

    private void CancelConsumption()
    {
        lock (_sync)
        {
            if (_consumptionCancellationRequested)
            {
                return;
            }

            _consumptionCancellationRequested = true;
        }

        _resultCancellationSource.Cancel();
    }

    private void DisposeResponse()
    {
        lock (_sync)
        {
            if (_responseDisposed)
            {
                return;
            }

            _responseDisposed = true;
        }

        try
        {
            CloseContentStream();
            _response.Dispose();
        }
        finally
        {
            _resultCancellationSource.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    private void DisposeAfterEnumeratorConstructionFailure()
    {
        lock (_sync)
        {
            _disposeStarted = true;
            _resultDisposeCompletion ??= new(
                TaskCreationOptions.RunContinuationsAsynchronously);
        }

        try
        {
            DisposeResponse();
            _resultDisposeCompletion.TrySetResult(null);
        }
        catch (Exception ex)
        {
            _resultDisposeCompletion.TrySetException(ex);
        }
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
        IAsyncEnumerator<T> inner,
        CancellationTokenSource? linkedCancellationSource) : IAsyncEnumerator<T>
    {
        private readonly object _moveNextSync = new();
        private readonly TaskCompletionSource<object?> _disposeCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly AsyncLocal<bool> _isDisposing = new();
        private bool _moveNextBlocked;
        private bool _disposeClaimed;
        private Task<bool>? _activeMoveNext;

        public T Current => inner.Current;

        public async ValueTask<bool> MoveNextAsync()
        {
            Task<bool> moveNext;
            try
            {
                moveNext = result.StartMoveNext(this);
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
            catch
            {
                await DisposeAsync().ConfigureAwait(false);
                throw;
            }

            try
            {
                bool hasNext;
                try
                {
                    hasNext = await moveNext.ConfigureAwait(false);
                }
                finally
                {
                    lock (_moveNextSync)
                    {
                        if (ReferenceEquals(_activeMoveNext, moveNext))
                        {
                            _activeMoveNext = null;
                        }
                    }
                }

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

        public void BeginDisposal()
        {
            lock (_moveNextSync)
            {
                _moveNextBlocked = true;
            }
        }

        public Task<bool> StartMoveNext()
        {
            lock (_moveNextSync)
            {
                if (_moveNextBlocked)
                {
                    throw new ObjectDisposedException(GetType().FullName);
                }

                if (_activeMoveNext is { IsCompleted: false })
                {
                    throw new InvalidOperationException(
                        "Concurrent MoveNextAsync calls are not supported.");
                }

                Task<bool> moveNext = inner.MoveNextAsync().AsTask();
                _activeMoveNext = moveNext;
                return moveNext;
            }
        }

        private async ValueTask<bool> DisposeInnerAsync()
        {
            bool disposeInner;
            Task<bool>? activeMoveNext;
            lock (_moveNextSync)
            {
                _moveNextBlocked = true;
                disposeInner = !_disposeClaimed;
                _disposeClaimed = true;
                activeMoveNext = _activeMoveNext;
            }

            if (!disposeInner && _isDisposing.Value)
            {
                return false;
            }

            if (disposeInner)
            {
                _isDisposing.Value = true;
                result._isEnumeratorDisposing.Value = true;
                try
                {
                    if (activeMoveNext is not null)
                    {
                        try
                        {
                            await activeMoveNext.ConfigureAwait(false);
                        }
                        catch
                        {
                            // The MoveNextAsync caller observes consumption failures.
                        }
                    }

                    await inner.DisposeAsync().ConfigureAwait(false);
                    _disposeCompletion.TrySetResult(null);
                }
                catch (Exception ex)
                {
                    _disposeCompletion.TrySetException(ex);
                }
                finally
                {
                    linkedCancellationSource?.Dispose();
                    result._isEnumeratorDisposing.Value = false;
                    _isDisposing.Value = false;
                }
            }

            await _disposeCompletion.Task.ConfigureAwait(false);
            return true;
        }
    }
}
