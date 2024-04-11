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

public class MockPipelineResponseTransport : PipelineTransport
{
    private readonly Func<PipelineMessage, MockPipelineResponse> _responseFactory;

    public string Id { get; }

    public MockPipelineResponseTransport(string id, params MockPipelineResponse[] responses)
    {
        Id = id;
        var requestIndex = 0;
        _responseFactory = _ =>
        {
            return responses[requestIndex++];
        };
    }

    public MockPipelineResponseTransport(string id, Func<PipelineMessage, MockPipelineResponse> responseFactory)
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
        try
        {
            Stamp(message, "Transport");
        }
        finally
        {
        }
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        try
        {
            Stamp(message, "Transport");
        }
        finally
        {
        }

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
