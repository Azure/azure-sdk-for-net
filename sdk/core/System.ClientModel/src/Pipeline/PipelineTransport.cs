// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an HTTP pipeline transport used to send and receive HTTP requests
/// and responses.
/// </summary>
public abstract class PipelineTransport : PipelinePolicy
{
    private readonly PipelineTransportLogger? _pipelineTransportLogger;

    /// <summary>
    /// Creates a new instance of the <see cref="PipelineTransport"/> class.
    /// </summary>
    protected PipelineTransport()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="PipelineTransport"/> class.
    /// </summary>
    /// <param name="enableLogging">If client-wide logging is enabled for this pipeline.</param>
    /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to use to create an <see cref="ILogger"/> instance for logging.
    /// If one is not provided, logs are written to Event Source by default.</param>
    protected PipelineTransport(bool enableLogging, ILoggerFactory? loggerFactory)
    {
        if (enableLogging)
        {
            _pipelineTransportLogger = new(loggerFactory);
        }
    }

    #region CreateMessage

    /// <summary>
    /// Create an instance of <see cref="PipelineMessage"/> that can be sent
    /// using this transport instance. This method will rarely be called directly;
    /// <see cref="ClientPipeline.CreateMessage()"/> should be called instead.
    /// </summary>
    /// <returns>A <see cref="PipelineMessage"/> that can be passed to
    /// <see cref="Process(PipelineMessage)"/>.</returns>
    public PipelineMessage CreateMessage()
    {
        PipelineMessage message = CreateMessageCore();
        message.NetworkTimeout ??= ClientPipeline.DefaultNetworkTimeout;

        if (message.Request is null)
        {
            throw new InvalidOperationException("Request was not set on message.");
        }

        if (message.Response is not null)
        {
            throw new InvalidOperationException("Response should not be set before transport is invoked.");
        }

        return message;
    }

    /// <summary>
    /// Creates a new transport-specific instance of <see cref="PipelineMessage"/>.
    /// Types that derive from <see cref="PipelineTransport"/> must implement this
    /// method to provide transport-specific functionality.
    /// </summary>
    /// <returns>A <see cref="PipelineMessage"/> that can be passed to
    /// <see cref="Process(PipelineMessage)"/>.</returns>
    protected abstract PipelineMessage CreateMessageCore();

    #endregion

    #region Process message

    /// <summary>
    /// Sends the HTTP request contained by <see cref="PipelineMessage.Request"/>
    /// and sets the value of <see cref="PipelineMessage.Response"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// request that was sent and response that was received by the transport.</param>
    public void Process(PipelineMessage message)
    {
        try
        {
            ProcessSyncOrAsync(message, async: false).EnsureCompleted();
        }
        catch (Exception ex)
        {
            _pipelineTransportLogger?.LogExceptionResponse(message.Request.ClientRequestId ?? string.Empty, ex);
            throw;
        }
    }

    /// <summary>
    /// Sends the HTTP request contained by <see cref="PipelineMessage.Request"/>
    /// and sets the value of <see cref="PipelineMessage.Response"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// request that was sent and response that was received by the transport.</param>
    public async ValueTask ProcessAsync(PipelineMessage message)
    {
        try
        {
            await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _pipelineTransportLogger?.LogExceptionResponse(message.Request.ClientRequestId ?? string.Empty, ex);
            throw;
        }
    }

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
    {
        Debug.Assert(message.NetworkTimeout is not null, "NetworkTimeout is not set on PipelineMessage.");

        // Implement network timeout behavior around call to ProcessCore.
        TimeSpan networkTimeout = (TimeSpan)message.NetworkTimeout!;
        CancellationToken messageToken = message.CancellationToken;
        using CancellationTokenSource timeoutTokenSource = CancellationTokenSource.CreateLinkedTokenSource(messageToken);
        timeoutTokenSource.CancelAfter(networkTimeout);

        var before = Stopwatch.GetTimestamp();

        try
        {
            message.CancellationToken = timeoutTokenSource.Token;

            if (async)
            {
                await ProcessCoreAsync(message).ConfigureAwait(false);
            }
            else
            {
                ProcessCore(message);
            }
        }
        catch (OperationCanceledException ex)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(messageToken, timeoutTokenSource.Token, ex, networkTimeout);
            throw;
        }
        finally
        {
            message.CancellationToken = messageToken;
            timeoutTokenSource.CancelAfter(Timeout.Infinite);
        }

        var after = Stopwatch.GetTimestamp();
        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        message.AssertResponse();
        message.Response!.IsErrorCore = ClassifyResponse(message);

        if (elapsed > ClientLoggingOptions.RequestTooLongSeconds)
        {
            _pipelineTransportLogger?.LogResponseDelay(message.Request.ClientRequestId ?? string.Empty, elapsed);
        }

        // The remainder of the method handles response content according to
        // buffering logic specified by value of message.BufferResponse.

        Stream? contentStream = message.Response!.ContentStream;
        if (contentStream is null)
        {
            // There is no response content.
            return;
        }

        if (!message.BufferResponse)
        {
            // Client has requested not to buffer the message response content.
            // If applicable, wrap it in a read-timeout stream.
            if (networkTimeout != Timeout.InfiniteTimeSpan)
            {
                message.Response.ContentStream = new ReadTimeoutStream(contentStream, networkTimeout);
            }

            return;
        }

        try
        {
            // If cancellation is possible (whether due to network timeout or a user
            // cancellation token being passed), then register callback to dispose the
            // stream on cancellation.
            if (networkTimeout != Timeout.InfiniteTimeSpan || messageToken.CanBeCanceled)
            {
                timeoutTokenSource.Token.Register(state => ((Stream?)state)?.Dispose(), contentStream);
                timeoutTokenSource.CancelAfter(networkTimeout);
            }

            if (async)
            {
                await message.Response.BufferContentAsync(timeoutTokenSource.Token).ConfigureAwait(false);
            }
            else
            {
                message.Response.BufferContent(timeoutTokenSource.Token);
            }
        }
        // We dispose stream on timeout or user cancellation so catch and check if
        // cancellation token was cancelled
        catch (Exception ex) when (ex is ObjectDisposedException
                                      or IOException
                                      or OperationCanceledException
                                      or NotSupportedException)
        {
            CancellationHelper.ThrowIfCancellationRequestedOrTimeout(messageToken, timeoutTokenSource.Token, ex, networkTimeout);
            throw;
        }
    }

    /// <summary>
    /// Transport-specific implementation used to sends the HTTP request
    /// contained by <see cref="PipelineMessage.Request"/> and set the
    /// value of <see cref="PipelineMessage.Response"/>. Types that derive
    /// from <see cref="PipelineTransport"/> must implement this method to
    /// provide transport-specific functionality.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// request that was sent and response that was received by the transport.</param>
    protected abstract void ProcessCore(PipelineMessage message);

    /// <summary>
    /// Transport-specific implementation used to sends the HTTP request
    /// contained by <see cref="PipelineMessage.Request"/> and set the
    /// value of <see cref="PipelineMessage.Response"/>. Types that derive
    /// from <see cref="PipelineTransport"/> must implement this method to
    /// provide transport-specific functionality.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// request that was sent and response that was received by the transport.</param>
    protected abstract ValueTask ProcessCoreAsync(PipelineMessage message);

    private static bool ClassifyResponse(PipelineMessage message)
    {
        if (!message.ResponseClassifier.TryClassify(message, out bool isError))
        {
            bool classified = PipelineMessageClassifier.Default.TryClassify(message, out isError);

            Debug.Assert(classified, "Error classifier did not classify message.");
        }

        return isError;
    }

    #endregion

    #region PipelinePolicy.Process overrides

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.

    /// <summary>
    /// Implementation of <see cref="PipelinePolicy.Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>.
    /// Since the transport is the last policy in the <see cref="ClientPipeline"/> policy
    /// chain, this method does not call <see cref="PipelinePolicy.ProcessNext(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// as other policy implementations do.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to pass to <see cref="Process(PipelineMessage)"/>.</param>
    /// <param name="pipeline">The collection of policies in the pipeline.</param>
    /// <param name="currentIndex">The index of the current policy being processed
    /// in the pipeline invocation.</param>
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        Process(message);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    /// <summary>
    /// Implementation of <see cref="PipelinePolicy.Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>.
    /// Since the transport is the last policy in the <see cref="ClientPipeline"/> policy
    /// chain, this method does not call <see cref="PipelinePolicy.ProcessNext(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// as other policy implementations do.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> to pass to <see cref="Process(PipelineMessage)"/>.</param>
    /// <param name="pipeline">The collection of policies in the pipeline.</param>
    /// <param name="currentIndex">The index of the current policy being processed
    /// in the pipeline invocation.</param>
    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        await ProcessAsync(message).ConfigureAwait(false);

        Debug.Assert(++currentIndex == pipeline.Count, "Transport is not at last position in pipeline.");
    }

    #endregion
}
