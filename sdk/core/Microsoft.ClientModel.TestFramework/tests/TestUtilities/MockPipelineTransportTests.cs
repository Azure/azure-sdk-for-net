// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.Linq;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MockPipelineTransportTests
{
    [Test]
    public void EndToEndTest()
    {
        int callsToOnSendingRequest = 0;
        int callsToOnReceivedResponse = 0;
        MockPipelineResponse mockResponse = new MockPipelineResponse(200).WithHeader("Content-Type", "application/json");

        MockPipelineTransport transport = new(message
            => mockResponse)
        {
            OnSendingRequest = message =>
            {
                callsToOnSendingRequest++;
            },
            OnReceivedResponse = message =>
            {
                callsToOnReceivedResponse++;
            }
        };

        var message = transport.CreateMessage();
        transport.Process(message);

        Assert.AreEqual(1, transport.Requests.Count);
        Assert.AreEqual(1, callsToOnSendingRequest);
        Assert.AreEqual(1, callsToOnReceivedResponse);
        Assert.AreSame(mockResponse, message.Response);
    }

    [Test]
    public void CanAddDelay()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanAddDelayAsync()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanProcessAsync()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void ValidatesSyncPipeline()
    {
        MockPipelineTransport transport = new(message => new MockPipelineResponse(200));
        transport.ExpectSyncPipeline = false;
        Assert.Throws<InvalidOperationException>(() => transport.Process(transport.CreateMessage()));
    }

    [Test]
    public void ValidatesAsyncPipeline()
    {
        MockPipelineTransport transport = new(message => new MockPipelineResponse(200));
        transport.ExpectSyncPipeline = true;
        Assert.Throws<InvalidOperationException>(() => transport.ProcessAsync(transport.CreateMessage()).GetAwaiter().GetResult());
    }
}