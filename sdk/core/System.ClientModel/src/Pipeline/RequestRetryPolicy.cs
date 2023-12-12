// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class RequestRetryPolicy : PipelinePolicy
{
    private const int DefaultMaxRetries = 3;

    private readonly int _maxRetries;
    private readonly MessageDelay _delay;

    public RequestRetryPolicy() : this(DefaultMaxRetries, MessageDelay.Default)
    {
    }

    public RequestRetryPolicy(int maxRetries, MessageDelay delay)
    {
        _maxRetries = maxRetries;
        _delay = delay;
    }

    public override void Process(PipelineMessage message, PipelineProcessor pipeline)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
        => ProcessSyncOrAsync(message, pipeline, async: false).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().

    public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        => await ProcessSyncOrAsync(message, pipeline, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, PipelineProcessor pipeline, bool async)
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
                    await pipeline.ProcessNextAsync().ConfigureAwait(false);
                }
                else
                {
                    pipeline.ProcessNext();
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
                if (async)
                {
                    await _delay.DelayAsync(message, message.CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _delay.Delay(message, message.CancellationToken);
                }

                // Dispose the content stream to free up a connection if the request has any
                message.Response?.ContentStream?.Dispose();

                message.RetryCount++;

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

                //throw new AggregateException(
                //    $"Retry failed after {message.RetryNumber + 1} tries. Retry settings can be adjusted in {nameof(ClientOptions)}.{nameof(ClientOptions.Retry)}" +
                //    $" or by configuring a custom retry policy in {nameof(ClientOptions)}.{nameof(ClientOptions.RetryPolicy)}.",
                //    exceptions);
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

    protected virtual bool ShouldRetry(PipelineMessage message, Exception? exception)
    {
        // If there was no exception and we got a success response, don't retry.
        if (exception is null && message.Response is not null && !message.Response.IsError)
        {
            return false;
        }

        if (message.RetryCount >= _maxRetries)
        {
            // We've exceeded the maximum number of retries, so don't retry.
            return false;
        }

        return exception is null ?
            IsRetriable(message) :
            IsRetriable(message, exception);
    }

    protected virtual ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetry(message, exception));

    #region Retry Classifier

    // TODO: replace these with classifiers.  Keeping internal for the initial
    // implementation.
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
            (exception is ClientRequestException ex && ex.Status == 0);

    #endregion
}