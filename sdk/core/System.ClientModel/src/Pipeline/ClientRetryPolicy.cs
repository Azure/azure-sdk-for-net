﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class ClientRetryPolicy : PipelinePolicy
{
    public static ClientRetryPolicy Default { get; } = new ClientRetryPolicy();

    private const int DefaultMaxRetries = 3;
    private static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);

    private readonly int _maxRetries;
    private readonly TimeSpan _initialDelay;

    public ClientRetryPolicy(int maxRetries = DefaultMaxRetries)
    {
        _maxRetries = maxRetries;
        _initialDelay = DefaultInitialDelay;
    }

    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        List<Exception>? allTryExceptions = null;

        while (true)
        {
            Exception? thisTryException = null;

            if (async)
            {
                await OnSendingRequestAsync(message).ConfigureAwait(false);
            }
            else
            {
                OnSendingRequest(message);
            }

            try
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline, currentIndex);
                }
            }
            catch (Exception ex)
            {
                allTryExceptions ??= new List<Exception>();
                allTryExceptions.Add(ex);

                thisTryException = ex;
            }

            if (async)
            {
                await OnRequestSentAsync(message).ConfigureAwait(false);
            }
            else
            {
                OnRequestSent(message);
            }

            bool shouldRetry = async ?
                await ShouldRetryInternalAsync(message, thisTryException).ConfigureAwait(false) :
                ShouldRetryInternal(message, thisTryException);

            if (shouldRetry)
            {
                TimeSpan delay = GetNextDelay(message, message.RetryCount);
                if (delay > TimeSpan.Zero)
                {
                    if (async)
                    {
                        await WaitAsync(delay, message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        Wait(delay, message.CancellationToken);
                    }
                }

                // Dispose the content stream to free up a connection if the request has any
                message.Response?.ContentStream?.Dispose();

                message.RetryCount++;
                OnTryComplete(message);

                continue;
            }

            if (thisTryException != null)
            {
                // Rethrow if there's only one exception.
                if (allTryExceptions!.Count == 1)
                {
                    ExceptionDispatchInfo.Capture(thisTryException).Throw();
                }

                throw new AggregateException($"Retry failed after {message.RetryCount + 1} tries.", allTryExceptions);
            }

            // ShouldRetry returned false this iteration and the last request
            // we sent didn't cause an exception to be thrown.
            // So, we're done.  Exit the while loop.
            break;
        }
    }

    protected virtual void OnSendingRequest(PipelineMessage message) { }

    protected virtual ValueTask OnSendingRequestAsync(PipelineMessage message) => default;

    protected virtual void OnRequestSent(PipelineMessage message) { }

    protected virtual ValueTask OnRequestSentAsync(PipelineMessage message) => default;

    protected virtual void OnTryComplete(PipelineMessage message) { }

    internal bool ShouldRetryInternal(PipelineMessage message, Exception? exception)
        => ShouldRetryInternalSyncOrAsync(message, exception, async: false).EnsureCompleted();

    internal async ValueTask<bool> ShouldRetryInternalAsync(PipelineMessage message, Exception? exception)
        => await ShouldRetryInternalSyncOrAsync(message, exception, async: true).ConfigureAwait(false);

    private async ValueTask<bool> ShouldRetryInternalSyncOrAsync(PipelineMessage message, Exception? exception, bool async)
    {
        // If there was no exception and we got a success response, don't retry.
        if (exception is null && message.Response is not null && !message.Response.IsError)
        {
            return false;
        }

        if (async)
        {
            return await ShouldRetryAsync(message, exception).ConfigureAwait(false);
        }
        else
        {
            return ShouldRetry(message, exception);
        }
    }

    protected virtual bool ShouldRetry(PipelineMessage message, Exception? exception)
    {
        if (message.RetryCount >= _maxRetries)
        {
            // We've exceeded the maximum number of retries, so don't retry.
            return false;
        }

        if (!message.ResponseClassifier.TryClassify(message, exception, out bool isRetriable))
        {
            bool classified = PipelineMessageClassifier.Default.TryClassify(message, exception, out isRetriable);

            Debug.Assert(classified);
        }

        return isRetriable;
    }

    protected virtual ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetry(message, exception));

    protected virtual TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        // Default implementation is exponential backoff
        return TimeSpan.FromMilliseconds((1 << (tryCount - 1)) * _initialDelay.TotalMilliseconds);
    }

    protected virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
    {
        await Task.Delay(time, cancellationToken).ConfigureAwait(false);
    }

    protected virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
    {
        if (cancellationToken.WaitHandle.WaitOne(time))
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        }
    }
}
