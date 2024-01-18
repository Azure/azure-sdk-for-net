// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class ClientRetryPolicy : PipelinePolicy
{
    public static readonly ClientRetryPolicy Default = new();

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
                await ShouldRetryAsync(message, thisTryException).ConfigureAwait(false) :
                ShouldRetry(message, thisTryException);

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

    public bool ShouldRetry(PipelineMessage message, Exception? exception)
        => ShouldRetrySyncOrAsync(message, exception, async: false).EnsureCompleted();

    public async ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => await ShouldRetrySyncOrAsync(message, exception, async: true).ConfigureAwait(false);

    private async ValueTask<bool> ShouldRetrySyncOrAsync(PipelineMessage message, Exception? exception, bool async)
    {
        // If there was no exception and we got a success response, don't retry.
        if (exception is null && message.Response is not null && !message.Response.IsError)
        {
            return false;
        }

        if (async)
        {
            return await ShouldRetryCoreAsync(message, exception).ConfigureAwait(false);
        }
        else
        {
            return ShouldRetryCore(message, exception);
        }
    }

    protected virtual bool ShouldRetryCore(PipelineMessage message, Exception? exception)
    {
        if (message.RetryCount >= _maxRetries)
        {
            // We've exceeded the maximum number of retries, so don't retry.
            return false;
        }

        return exception is null ?
            IsRetriable(message) :
            IsRetriable(message, exception);
    }

    protected virtual ValueTask<bool> ShouldRetryCoreAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetryCore(message, exception));

    public TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
        => GetNextDelayCore(message, tryCount);

    protected virtual TimeSpan GetNextDelayCore(PipelineMessage message, int tryCount)
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

    #region Retry Classifier

    // Overriding response-retriable classification will be added in a later ClientModel release.
    private static bool IsRetriable(PipelineMessage message)
    {
        message.AssertResponse();

        return message.Response!.Status switch
        {
            // Request Timeout
            408 => true,

            // Too Many Requests
            429 => true,

            // Internal Server Error
            500 => true,

            // Bad Gateway
            502 => true,

            // Service Unavailable
            503 => true,

            // Gateway Timeout
            504 => true,

            // Default case
            _ => false
        };
    }

    private static bool IsRetriable(PipelineMessage message, Exception exception)
        => IsRetriable(exception) ||
            // Retry non-user initiated cancellations
            (exception is OperationCanceledException &&
            !message.CancellationToken.IsCancellationRequested);

    private static bool IsRetriable(Exception exception)
        => (exception is IOException) ||
            (exception is ClientResultException ex && ex.Status == 0);

    #endregion
}