// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> used by a <see cref="ClientPipeline"/> to
/// decide whether or not to retry a <see cref="PipelineRequest"/>.
/// </summary>
public class ClientRetryPolicy : PipelinePolicy
{
    /// <summary>
    /// The <see cref="ClientRetryPolicy"/> instance used by a default
    /// <see cref="ClientPipeline"/>.
    /// </summary>
    public static ClientRetryPolicy Default { get; } = new ClientRetryPolicy();

    private static readonly TimeSpan DefaultInitialDelay = TimeSpan.FromSeconds(0.8);

    private readonly int _maxRetries;
    private readonly TimeSpan _initialDelay;
    private readonly PipelineRetryLogger? _retryLogger;

    internal const int DefaultMaxRetries = 3;

    /// <summary>
    /// Creates a new instance of the <see cref="ClientRetryPolicy"/> class.
    /// </summary>
    /// <param name="maxRetries">The maximum number of retries to attempt.</param>
    public ClientRetryPolicy(int maxRetries = DefaultMaxRetries) : this(maxRetries, ClientLoggingOptions.DefaultEnableLogging, default)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ClientRetryPolicy"/> class.
    /// </summary>
    /// <param name="maxRetries">The maximum number of retries to attempt.</param>
    /// <param name="enableLogging">If client-wide logging is enabled for this pipeline.</param>
    /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to use to create an <see cref="ILogger"/> instance for logging.
    /// If one is not provided, logs are written to Event Source by default.</param>
    public ClientRetryPolicy(int maxRetries, bool enableLogging, ILoggerFactory? loggerFactory)
    {
        _maxRetries = maxRetries;
        _initialDelay = DefaultInitialDelay;
        _retryLogger = enableLogging ? new PipelineRetryLogger(loggerFactory) : null;
    }

    /// <inheritdoc/>
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        List<Exception>? allTryExceptions = null;

        while (true)
        {
            Exception? thisTryException = null;
            var before = Stopwatch.GetTimestamp();

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

            var after = Stopwatch.GetTimestamp();
            double elapsed = (after-before) / (double)Stopwatch.Frequency;

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

                _retryLogger?.LogRequestRetrying(message.Request.ClientRequestId ?? string.Empty, message.RetryCount, elapsed);

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

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientRetryPolicy"/> logic.  It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// prior to passing control to the next policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineRequest"/> to be sent to the service.</param>
    protected virtual void OnSendingRequest(PipelineMessage message) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientRetryPolicy"/> logic.  It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// prior to passing control to the next policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineRequest"/> to be sent to the service.</param>
    protected virtual ValueTask OnSendingRequestAsync(PipelineMessage message) => default;

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientRetryPolicy"/> logic.  It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// just after control has been returned from the policy at the position
    /// after the retry policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    protected virtual void OnRequestSent(PipelineMessage message) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientRetryPolicy"/> logic.  It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// just after control has been returned from the policy at the position
    /// after the retry policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    protected virtual ValueTask OnRequestSentAsync(PipelineMessage message) => default;

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientRetryPolicy"/> logic.  It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after the time interval for the current retry attempt has passed.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> for this
    /// pipeline invocation.</param>
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

    /// <summary>
    /// A method that can be overridden by derived types to customize the default
    /// <see cref="ClientRetryPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has been returned from the policy at the position
    /// after the retry policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> for this
    /// pipeline invocation.</param>
    /// <param name="exception">The exception, if any, that was thrown from
    /// a policy after the retry policy in the pipeline.</param>
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

    /// <summary>
    /// A method that can be overridden by derived types to customize the default
    /// <see cref="ClientRetryPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has been returned from the policy at the position
    /// after the retry policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> for this
    /// pipeline invocation.</param>
    /// <param name="exception">The exception, if any, that was thrown from
    /// a policy after the retry policy in the pipeline.</param>
    protected virtual ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new(ShouldRetry(message, exception));

    /// <summary>
    /// A method that can be overridden by derived types to customize the default
    /// <see cref="ClientRetryPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// to determine how long the policy should wait before re-sending the request.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> for this
    /// pipeline invocation.</param>
    /// <param name="tryCount">A number indicating how many times the policy has
    /// tried to send the request.</param>
    /// <returns>The amount of time to wait before the next retry attempt.
    /// </returns>
    protected virtual TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        // Default implementation is exponential backoff, unless the response
        // has a retry-after header.
        double nextDelayMilliseconds = (1 << (tryCount - 1)) * _initialDelay.TotalMilliseconds;

        if (message.Response is not null &&
            PipelineResponseHeaders.TryGetRetryAfter(message.Response, out TimeSpan retryAfter) &&
            retryAfter.TotalMilliseconds > nextDelayMilliseconds)
        {
            return retryAfter;
        }

        return TimeSpan.FromMilliseconds(nextDelayMilliseconds);
    }

    /// <summary>
    /// A method that can be overridden by derived types to customize the default
    /// <see cref="ClientRetryPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// to wait the time interval returned by <see cref="GetNextDelay(PipelineMessage, int)"/>.
    /// </summary>
    /// <param name="time">The amount of time to wait before trying to send the
    /// request again.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used
    /// to cancel the wait if needed.</param>
    /// <returns>A task that can be awaited to asynchronously delay before the
    /// next retry attempt.</returns>
    protected virtual async Task WaitAsync(TimeSpan time, CancellationToken cancellationToken)
    {
        await Task.Delay(time, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// A method that can be overridden by derived types to customize the default
    /// <see cref="ClientRetryPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// to wait the time interval returned by <see cref="GetNextDelay(PipelineMessage, int)"/>.
    /// </summary>
    /// <param name="time">The amount of time to wait before trying to send the
    /// request again.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used
    /// to cancel the wait if needed.</param>
    protected virtual void Wait(TimeSpan time, CancellationToken cancellationToken)
    {
        if (cancellationToken.WaitHandle.WaitOne(time))
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        }
    }
}
