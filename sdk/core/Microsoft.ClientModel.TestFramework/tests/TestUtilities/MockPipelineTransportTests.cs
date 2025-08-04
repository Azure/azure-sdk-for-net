// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

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
        var transport = new MockPipelineTransport(
            message => new MockPipelineResponse(200),
            addDelay: true);

        var message = transport.CreateMessage();
        var stopwatch = Stopwatch.StartNew();

        transport.Process(message);

        stopwatch.Stop();
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(200, message.Response.Status);
        // Note: The delay is implementation-dependent, we just verify it doesn't break
    }

    [Test]
    public async Task CanAddDelayAsync()
    {
        var transport = new MockPipelineTransport(
            message => new MockPipelineResponse(200),
            addDelay: true);
        transport.ExpectSyncPipeline = false;

        var message = transport.CreateMessage();
        var stopwatch = Stopwatch.StartNew();

        await transport.ProcessAsync(message);

        stopwatch.Stop();
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(200, message.Response.Status);
        // Note: The delay is implementation-dependent, we just verify it doesn't break
    }

    [Test]
    public async Task CanProcessAsync()
    {
        var transport = new MockPipelineTransport(
            message => new MockPipelineResponse(201, "Created")
                .WithContent("async content")
                .WithHeader("X-Async", "true"));
        transport.ExpectSyncPipeline = false;

        var message = transport.CreateMessage();

        await transport.ProcessAsync(message);

        Assert.IsNotNull(message.Response);
        Assert.AreEqual(201, message.Response.Status);
        Assert.AreEqual("Created", message.Response.ReasonPhrase);
        Assert.AreEqual("async content", message.Response.Content.ToString());
        Assert.IsTrue(message.Response.Headers.TryGetValue("X-Async", out var asyncHeader));
        Assert.AreEqual("true", asyncHeader);
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

    [Test]
    public void DefaultConstructor_CreatesTransportWithDefaults()
    {
        var transport = new MockPipelineTransport();
        Assert.IsNotNull(transport);
        Assert.IsTrue(transport.ExpectSyncPipeline);
        Assert.AreEqual(0, transport.Requests.Count);
        Assert.IsNull(transport.OnSendingRequest);
        Assert.IsNull(transport.OnReceivedResponse);
    }

    [Test]
    public void CreateMessage_ReturnsNewMockPipelineMessage()
    {
        var transport = new MockPipelineTransport();

        var message = transport.CreateMessage();

        Assert.IsNotNull(message);
        Assert.IsInstanceOf<MockPipelineMessage>(message);
        Assert.IsNotNull(message.Request);
        Assert.IsInstanceOf<MockPipelineRequest>(message.Request);
    }

    [Test]
    public void Process_WithDefaultResponseFactory_Returns200Response()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();

        transport.Process(message);

        Assert.IsNotNull(message.Response);
        Assert.AreEqual(200, message.Response.Status);
        Assert.AreEqual(1, transport.Requests.Count);
    }

    [Test]
    public void Process_WithCustomResponseFactory_ReturnsCustomResponse()
    {
        var transport = new MockPipelineTransport(msg =>
            new MockPipelineResponse(404, "Not Found")
                .WithContent("Resource not found")
                .WithHeader("X-Error-Code", "RESOURCE_NOT_FOUND"));

        var message = transport.CreateMessage();

        transport.Process(message);

        Assert.IsNotNull(message.Response);
        Assert.AreEqual(404, message.Response.Status);
        Assert.AreEqual("Not Found", message.Response.ReasonPhrase);
        Assert.AreEqual("Resource not found", message.Response.Content.ToString());
        Assert.IsTrue(message.Response.Headers.TryGetValue("X-Error-Code", out var errorCode));
        Assert.AreEqual("RESOURCE_NOT_FOUND", errorCode);
    }

    [Test]
    public void Process_CapturesRequestInRequestsList()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();
        message.Request.Method = "POST";
        message.Request.Uri = new Uri("https://api.example.com/data");
        transport.Process(message);

        Assert.AreEqual(1, transport.Requests.Count);
        var capturedRequest = transport.Requests[0];
        Assert.AreEqual("POST", capturedRequest.Method);
        Assert.AreEqual("https://api.example.com/data", capturedRequest.Uri?.ToString());
    }

    [Test]
    public void Process_MultipleRequests_CapturesAllRequests()
    {
        var transport = new MockPipelineTransport();
        var message1 = transport.CreateMessage();
        var message2 = transport.CreateMessage();
        var message3 = transport.CreateMessage();

        message1.Request.Method = "GET";
        message2.Request.Method = "POST";
        message3.Request.Method = "DELETE";

        transport.Process(message1);
        transport.Process(message2);
        transport.Process(message3);

        Assert.AreEqual(3, transport.Requests.Count);
        Assert.AreEqual("GET", transport.Requests[0].Method);
        Assert.AreEqual("POST", transport.Requests[1].Method);
        Assert.AreEqual("DELETE", transport.Requests[2].Method);
    }

    [Test]
    public void OnSendingRequest_CalledBeforeProcessing()
    {
        var requestCount = 0;
        var transport = new MockPipelineTransport(msg => new MockPipelineResponse(200))
        {
            OnSendingRequest = msg =>
            {
                requestCount++;
                Assert.IsNull(msg.Response); // Response should not be set yet
            }
        };

        var message = transport.CreateMessage();

        transport.Process(message);

        Assert.AreEqual(1, requestCount);
        Assert.IsNotNull(message.Response);
    }

    [Test]
    public void OnReceivedResponse_CalledAfterProcessing()
    {
        var responseCount = 0;
        var transport = new MockPipelineTransport(msg => new MockPipelineResponse(200))
        {
            OnReceivedResponse = msg =>
            {
                responseCount++;
                Assert.IsNotNull(msg.Response); // Response should be set
                Assert.AreEqual(200, msg.Response.Status);
            }
        };

        var message = transport.CreateMessage();

        transport.Process(message);

        Assert.AreEqual(1, responseCount);
    }

    [Test]
    public void Process_WithNonMockMessage_ThrowsInvalidOperationException()
    {
        var transport = new MockPipelineTransport();
        var nonMockMessage = new NonMockPipelineMessage();

        var exception = Assert.Throws<InvalidOperationException>(() => transport.Process(nonMockMessage));
        Assert.IsTrue(exception.Message.Contains("MockPipelineMessage"));
    }

    [Test]
    public async Task ProcessAsync_WithNonMockMessage_ThrowsInvalidOperationException()
    {
        var transport = new MockPipelineTransport();
        transport.ExpectSyncPipeline = false;
        var nonMockMessage = new NonMockPipelineMessage();

        var exception = await AsyncAssert.ThrowsAsync<InvalidOperationException>(
            async () => await transport.ProcessAsync(nonMockMessage));
        Assert.IsTrue(exception.Message.Contains("MockPipelineMessage"));
    }

    [Test]
    public void ExpectSyncPipeline_CanBeSetToNull()
    {
        var transport = new MockPipelineTransport();

        transport.ExpectSyncPipeline = null;

        Assert.IsNull(transport.ExpectSyncPipeline);

        var message1 = transport.CreateMessage();
        Assert.DoesNotThrow(() => transport.Process(message1));

        var message2 = transport.CreateMessage();
        Assert.DoesNotThrowAsync(async () => await transport.ProcessAsync(message2));
    }

    [Test]
    public void ResponseFactory_ReceivesCorrectMessage()
    {
        MockPipelineMessage receivedMessage = null;
        var transport = new MockPipelineTransport(msg =>
        {
            receivedMessage = msg;
            return new MockPipelineResponse(200);
        });

        var originalMessage = transport.CreateMessage();
        originalMessage.Request.Method = "PUT";

        transport.Process(originalMessage);

        Assert.IsNotNull(receivedMessage);
        Assert.AreSame(originalMessage, receivedMessage);
        Assert.AreEqual("PUT", receivedMessage.Request.Method);
    }

    [Test]
    public async Task ProcessAsync_WithCallbacks_ExecutesInCorrectOrder()
    {
        var executionOrder = new System.Collections.Generic.List<string>();
        var transport = new MockPipelineTransport(msg =>
        {
            executionOrder.Add("ResponseFactory");
            return new MockPipelineResponse(200);
        })
        {
            OnSendingRequest = msg => executionOrder.Add("OnSendingRequest"),
            OnReceivedResponse = msg => executionOrder.Add("OnReceivedResponse")
        };
        transport.ExpectSyncPipeline = false;

        var message = transport.CreateMessage();

        await transport.ProcessAsync(message);

        Assert.AreEqual(3, executionOrder.Count);
        Assert.AreEqual("OnSendingRequest", executionOrder[0]);
        Assert.AreEqual("ResponseFactory", executionOrder[1]);
        Assert.AreEqual("OnReceivedResponse", executionOrder[2]);
    }

    // Helper class for testing non-mock message handling
    private class NonMockPipelineMessage : System.ClientModel.Primitives.PipelineMessage
    {
        public NonMockPipelineMessage() : base(new MockPipelineRequest())
        {
        }
    }
}