// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockPipelineTransport : PipelineTransport
{
    private int _retryCount;
    private readonly Func<PipelineMessage, MockPipelineResponse> _responseFactory;

    public string Id { get; }

    public Action<MockPipelineMessage>? OnSendingRequest { get; set; }
    public Action<MockPipelineMessage>? OnReceivedResponse { get; set; }

    public MockPipelineTransport(string id, params int[] codes)
    {
        Id = id;
        var requestIndex = 0;
        _responseFactory = _ => { return new MockPipelineResponse(codes[requestIndex++]); };
    }

    public MockPipelineTransport(string id, Func<PipelineMessage, MockPipelineResponse> responseFactory)
    {
        Id = id;
        _responseFactory = responseFactory;
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new MockPipelineMessage();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        Stamp(message, "Transport");

        OnSendingRequest?.Invoke((MockPipelineMessage)message);

        ((MockPipelineMessage)message).SetResponse(_responseFactory(message));

        OnReceivedResponse?.Invoke((MockPipelineMessage)message);
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        Stamp(message, "Transport");

        OnSendingRequest?.Invoke((MockPipelineMessage)message);

        ((MockPipelineMessage)message).SetResponse(_responseFactory(message));

        OnReceivedResponse?.Invoke((MockPipelineMessage)message);

        return new ValueTask();
    }

    private void Stamp(PipelineMessage message, string prefix)
    {
        List<string> values;

        if (message.TryGetProperty(typeof(ObservablePolicy), out object? prop) &&
            prop is List<string> list)
        {
            values = list;
        }
        else
        {
            values = new List<string>();
            message.SetProperty(typeof(ObservablePolicy), values);
        }

        values.Add($"{prefix}:{Id}");
    }
}
