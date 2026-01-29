// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// A mock of <see cref="PipelineTransport"/> to use for testing.
/// </summary>
public class MockPipelineTransport : PipelineTransport
{
    private readonly bool _addDelay;
    private readonly object _syncObj = new object();

    private readonly Func<MockPipelineMessage, MockPipelineResponse>? _responseFactory;

    /// <summary>
    /// Whether this transport expects a synchronous pipeline.
    /// </summary>
    public bool? ExpectSyncPipeline { get; set; } = true;

    /// <summary>
    /// A list of mock pipeline requests that have been sent.
    /// </summary>
    public List<MockPipelineRequest> Requests { get; } = new();

    /// <summary>
    /// An action invoked when a request is being sent.
    /// </summary>
    public Action<MockPipelineMessage>? OnSendingRequest { get; set; }

    /// <summary>
    /// An action invoked when a response is received.
    /// </summary>
    public Action<MockPipelineMessage>? OnReceivedResponse { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="MockPipelineTransport"/>, which always returns a 200 response code.
    /// </summary>
    public MockPipelineTransport()
    {
        _responseFactory = _ => new MockPipelineResponse(200);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="MockPipelineTransport"/>.
    /// </summary>
    /// <param name="responseFactory">A function that returns a <see cref="MockPipelineResponse"/> based on the incoming <see cref="MockPipelineMessage"/>.</param>
    /// <param name="addDelay">Whether to add a delay when processing requests.</param>
    /// <param name="enableLogging">Whether to enable logging for the transport.</param>
    /// <param name="loggerFactory">The logger factory to use for creating loggers.</param>
    public MockPipelineTransport(Func<MockPipelineMessage, MockPipelineResponse> responseFactory,
                                 bool addDelay = false,
                                 bool enableLogging = false,
                                 ILoggerFactory? loggerFactory = null)
        : base(enableLogging, loggerFactory)
    {
        _responseFactory = responseFactory;
        _addDelay = addDelay;
    }

    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore() => new MockPipelineMessage();

    /// <inheritdoc/>
    protected override void ProcessCore(PipelineMessage message)
    {
        if (ExpectSyncPipeline == false)
        {
            throw new InvalidOperationException("MockPipelineTransport does not support synchronous processing when ExpectSyncPipeline is set to false.");
        }

        ProcessSyncOrAsync(message, async: false).EnsureCompleted();
    }

    /// <inheritdoc/>
    protected override async ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        if (ExpectSyncPipeline == true)
        {
            throw new InvalidOperationException("MockPipelineTransport does not support asynchronous processing when ExpectSyncPipeline is set to true.");
        }

        await ProcessSyncOrAsync(message, async: true).ConfigureAwait(false);
    }

    private ValueTask ProcessSyncOrAsync(PipelineMessage message, bool async)
    {
        OnSendingRequest?.Invoke((MockPipelineMessage)message);

        if (message is not MockPipelineMessage mockMessage)
        {
            throw new InvalidOperationException("MockPipelineTransport can only process MockPipelineMessage messages.");
        }

        if (message.Request is not MockPipelineRequest mockRequest)
        {
            throw new InvalidOperationException("MockPipelineTransport can only process MockPipelineRequest messages.");
        }

        lock (_syncObj)
        {
            Requests.Add(mockRequest);
        }

        if (_responseFactory is not null)
        {
            mockMessage.SetResponse(_responseFactory(mockMessage));
        }
        else
        {
            throw new InvalidOperationException("MockPipelineTransport must have a response factory set.");
        }

        if (mockMessage.Response?.ContentStream != null && ExpectSyncPipeline != null)
        {
            mockMessage.Response.ContentStream = new AsyncValidatingStream(!ExpectSyncPipeline.Value, mockMessage.Response.ContentStream);
        }

        if (_addDelay)
        {
            if (async)
            {
                return ProcessWithDelayAsync(mockMessage);
            }
            else
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(4));
            }
        }

        OnReceivedResponse?.Invoke((MockPipelineMessage)message);
        return default;
    }

    private async ValueTask ProcessWithDelayAsync(MockPipelineMessage mockMessage)
    {
        await Task.Delay(TimeSpan.FromSeconds(4)).ConfigureAwait(false);
        OnReceivedResponse?.Invoke(mockMessage);
    }
}
