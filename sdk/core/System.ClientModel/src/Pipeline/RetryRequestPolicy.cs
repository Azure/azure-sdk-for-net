// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public class RetryRequestPolicy : PipelinePolicy
{
    private const int DefaultMaxRetries = 3;

    private readonly int _maxRetries;

    public RetryRequestPolicy() : this(DefaultMaxRetries)
    {
    }

    public RetryRequestPolicy(int maxRetries)
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
    {
        if (async)
        {
            await pipeline.ProcessNextAsync().ConfigureAwait(false);
        }
        else
        {
            pipeline.ProcessNext();
        }

        // If "Should Retry"
        //    GetNextDelay
        //    Wait(Delay, CancellationToken)
        //    If (message.HasRespose)
        //        Dispose the content stream if applicable
        //    Increment Retry Count
        // If "Last Exception"
        //    Throw single or Throw Aggregate

        // There is logic to swap out the delay length algo
        // There is logic to selectively retry based on the exception - ResponseClassifier
    }

    internal virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
    {
        await Task.Delay(time, cancellationToken).ConfigureAwait(false);
    }

    internal virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
    {
        cancellationToken.WaitHandle.WaitOne(time);
    }

    /// <summary>
    /// This method can be overriden to control whether a request should be retried. It will be called for any response where
    /// <see cref="PipelineResponse.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
    /// This method will only be called for sync methods.
    /// </summary>
    /// <param name="message">The message containing the request and response.</param>
    /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
    /// <returns>Whether or not to retry.</returns>
    protected internal virtual bool ShouldRetry(PipelineMessage message, Exception? exception)
        => ShouldRetrySyncOrAsync(message, exception);

    /// <summary>
    /// This method can be overriden to control whether a request should be retried.  It will be called for any response where
    /// <see cref="PipelineResponse.IsError"/> is true, or if an exception is thrown from any subsequent pipeline policies or the transport.
    /// This method will only be called for async methods.
    /// </summary>
    /// <param name="message">The message containing the request and response.</param>
    /// <param name="exception">The exception that occurred, if any, which can be used to determine if a retry should occur.</param>
    /// <returns>Whether or not to retry.</returns>
    protected internal virtual ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetrySyncOrAsync(message, exception));

    private bool ShouldRetrySyncOrAsync(PipelineMessage message, Exception? exception)
    {
        TryGetRetryCount(message, out int retryCount);

        if (retryCount >= _maxRetries)
        {
            // out of retries
            return false;
        }

        if (message.MessageClassifier is MessageClassifier classifier)
        {
            return exception is null ?
                classifier.IsRetriable(message) :
                classifier.IsRetriable(message, exception);
        }

        return false;
    }

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
}
