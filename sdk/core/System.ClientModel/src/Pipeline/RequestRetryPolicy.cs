// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class RequestRetryPolicy : PipelinePolicy
{
    private const int DefaultMaxRetries = 3;

    private readonly int _maxRetries;

    public RequestRetryPolicy() : this(DefaultMaxRetries)
    {
    }

    public RequestRetryPolicy(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    public override void Process(PipelineMessage message, PipelineProcessor pipeline)

#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, pipeline, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, PipelineProcessor pipeline, bool async)
    //{
    //    if (async)
    //    {
    //        await pipeline.ProcessNextAsync().ConfigureAwait(false);
    //    }
    //    else
    //    {
    //        pipeline.ProcessNext();
    //    }

    //    // If "Should Retry"
    //    //    GetNextDelay
    //    //    Wait(Delay, CancellationToken)
    //    //    If (message.HasRespose)
    //    //        Dispose the content stream if applicable
    //    //    Increment Retry Count
    //    // If "Last Exception"
    //    //    Throw single or Throw Aggregate

    //    // There is logic to swap out the delay length algo
    //    // There is logic to selectively retry based on the exception - ResponseClassifier
    //}
    {
        List<Exception>? exceptions = null;
        TryGetRetryCount(message, out int retryCount);

        while (true)
        {
            Exception? lastException = null;
            long before = Stopwatch.GetTimestamp();

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
                    await pipeline.ProcessNextAsync().ConfigureAwait(false);
                }
                else
                {
                    pipeline.ProcessNext();
                }
            }
            catch (Exception ex)
            {
                exceptions ??= new List<Exception>();
                exceptions.Add(ex);

                lastException = ex;
            }

            if (async)
            {
                await OnRequestSentAsync(message).ConfigureAwait(false);
            }
            else
            {
                OnRequestSent(message);
            }

            long after = Stopwatch.GetTimestamp();
            double elapsed = (after - before) / (double)Stopwatch.Frequency;

            bool shouldRetry = false;

            // We only invoke ShouldRetry for errors. If a user needs full control they can either override HttpPipelinePolicy directly
            // or modify the ResponseClassifier.

            if (lastException is not null ||
                (message.TryGetResponse(out PipelineResponse response) && response.IsError))
            {
                shouldRetry = async ?
                    await ShouldRetryAsync(message, lastException).ConfigureAwait(false) :
                    ShouldRetry(message, lastException);
            }

            if (shouldRetry)
            {
                TimeSpan delay = GetDelay(message);

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

                if (message.TryGetResponse(out response))
                {
                    // Dispose the content stream to free up a connection if the request has any
                    response.ContentStream?.Dispose();
                }

                SetRetryCount(message, retryCount++);

                // TODO: extend
                //AzureCoreEventSource.Singleton.RequestRetrying(message.Request.ClientRequestId, message.RetryNumber, elapsed);

                continue;
            }

            if (lastException != null)
            {
                // Rethrow if there's only one exception.
                if (exceptions!.Count == 1)
                {
                    ExceptionDispatchInfo.Capture(lastException).Throw();
                }

                throw new AggregateException($"Retry failed after {retryCount} tries.", exceptions);

                //throw new AggregateException(
                //    $"Retry failed after {message.RetryNumber + 1} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}" +
                //    $" or by configuring a custom retry policy in {nameof(ClientOptions)}.{nameof(ClientOptions.RetryPolicy)}.",
                //    exceptions);
            }

            // ShouldRetry returned false this iteration and
            // the last request sent didn't cause an exception.
            break;
        }
    }

    internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
    {
        await Task.Delay(time, cancellationToken).ConfigureAwait(false);
    }

    internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
    {
        cancellationToken.WaitHandle.WaitOne(time);
    }

    protected virtual void OnSendingRequest(PipelineMessage message) { }

    protected virtual ValueTask OnSendingRequestAsync(PipelineMessage message) => default;

    protected virtual void OnRequestSent(PipelineMessage message) { }

    protected virtual ValueTask OnRequestSentAsync(PipelineMessage message) => default;

    protected virtual bool ShouldRetry(PipelineMessage message, Exception? exception)
    {
        if (TryGetRetryCount(message, out int retryCount) && retryCount >= _maxRetries)
        {
            // out of retries
            return false;
        }

        return exception is null ?
            IsRetriable(message) :
            IsRetriable(message, exception);
    }

    protected virtual ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetry(message, exception));

    protected virtual TimeSpan GetDelay(PipelineMessage message) {
        // TODO: implement
        return TimeSpan.FromSeconds(1);
    }

    #region Retry Classifier

    // TODO: replace these with classifiers.  Keeping internal for the initial
    // implementation.
    private static bool IsRetriable(PipelineMessage message)
        => message.Response.Status switch
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

    private static bool IsRetriable(PipelineMessage message, Exception exception)
        => IsRetriable(exception) ||
            // Retry non-user initiated cancellations
            (exception is OperationCanceledException &&
            !message.CancellationToken.IsCancellationRequested);

    private static bool IsRetriable(Exception exception)
        => (exception is IOException) ||
            (exception is ClientRequestException ex && ex.Status == 0);

    #endregion

    #region RetryCount Property
    private static void SetRetryCount(PipelineMessage message, int retryCount)
        => message.SetProperty(typeof(RetryCountPropertyKey), retryCount);

    private static bool TryGetRetryCount(PipelineMessage message, out int retryCount)
    {
        if (message.TryGetProperty(typeof(RetryCountPropertyKey), out object? value) && value is int count)
        {
            retryCount = count;
            return true;
        }

        retryCount = default;
        return false;
    }

    private struct RetryCountPropertyKey { }
    #endregion
}