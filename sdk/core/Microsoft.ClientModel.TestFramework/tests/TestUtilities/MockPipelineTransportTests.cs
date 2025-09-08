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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
            Assert.That(callsToOnSendingRequest, Is.EqualTo(1));
            Assert.That(callsToOnReceivedResponse, Is.EqualTo(1));
            Assert.That(message.Response, Is.SameAs(mockResponse));
        }
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

        Assert.That(message.Response, Is.Not.Null);
        Assert.That(message.Response.Status, Is.EqualTo(200));
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

        Assert.That(message.Response, Is.Not.Null);
        Assert.That(message.Response.Status, Is.EqualTo(200));
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

        Assert.That(message.Response, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.Status, Is.EqualTo(201));
            Assert.That(message.Response.ReasonPhrase, Is.EqualTo("Created"));
            Assert.That(message.Response.Content.ToString(), Is.EqualTo("async content"));
            Assert.That(message.Response.Headers.TryGetValue("X-Async", out var asyncHeader), Is.True);
            Assert.That(asyncHeader, Is.EqualTo("true"));
        }
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
    public void DefaultConstructorCreatesTransportWithDefaults()
    {
        var transport = new MockPipelineTransport();

        Assert.That(transport, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(transport.ExpectSyncPipeline, Is.True);
            Assert.That(transport.Requests.Count, Is.EqualTo(0));
            Assert.That(transport.OnSendingRequest, Is.Null);
            Assert.That(transport.OnReceivedResponse, Is.Null);
        }
    }

    [Test]
    public void CreateMessageReturnsNewMockPipelineMessage()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();

        Assert.That(message, Is.Not.Null);
        Assert.That(message, Is.InstanceOf<MockPipelineMessage>());
        Assert.That(message.Request, Is.Not.Null);
        Assert.That(message.Request, Is.InstanceOf<MockPipelineRequest>());
    }

    [Test]
    public void ProcessWithDefaultResponseFactoryReturns200Response()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();
        transport.Process(message);

        Assert.That(message.Response, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.Status, Is.EqualTo(200));
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
        }
    }

    [Test]
    public void ProcessWithCustomResponseFactoryReturnsCustomResponse()
    {
        var transport = new MockPipelineTransport(msg =>
            new MockPipelineResponse(404, "Not Found")
                .WithContent("Resource not found")
                .WithHeader("X-Error-Code", "RESOURCE_NOT_FOUND"));
        var message = transport.CreateMessage();
        transport.Process(message);

        Assert.That(message.Response, Is.Not.Null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(message.Response.Status, Is.EqualTo(404));
            Assert.That(message.Response.ReasonPhrase, Is.EqualTo("Not Found"));
            Assert.That(message.Response.Content.ToString(), Is.EqualTo("Resource not found"));
            Assert.That(message.Response.Headers.TryGetValue("X-Error-Code", out var errorCode), Is.True);
            Assert.That(errorCode, Is.EqualTo("RESOURCE_NOT_FOUND"));
        }
    }

    [Test]
    public void ProcessCapturesRequestInRequestsList()
    {
        var transport = new MockPipelineTransport();
        var message = transport.CreateMessage();

        message.Request.Method = "POST";
        message.Request.Uri = new Uri("https://api.example.com/data");
        transport.Process(message);

        Assert.That(transport.Requests.Count, Is.EqualTo(1));
        var capturedRequest = transport.Requests[0];
        using (Assert.EnterMultipleScope())
        {
            Assert.That(capturedRequest.Method, Is.EqualTo("POST"));
            Assert.That(capturedRequest.Uri?.ToString(), Is.EqualTo("https://api.example.com/data"));
        }
    }

    [Test]
    public void ProcessMultipleRequestsCapturesAllRequests()
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

        Assert.That(transport.Requests.Count, Is.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(transport.Requests[0].Method, Is.EqualTo("GET"));
            Assert.That(transport.Requests[1].Method, Is.EqualTo("POST"));
            Assert.That(transport.Requests[2].Method, Is.EqualTo("DELETE"));
        }
    }

    [Test]
    public void OnSendingRequestCalledBeforeProcessing()
    {
        var requestCount = 0;
        var transport = new MockPipelineTransport(msg => new MockPipelineResponse(200))
        {
            OnSendingRequest = msg =>
            {
                requestCount++;
                Assert.That(msg.Response, Is.Null); // Response should not be set yet
            }
        };

        var message = transport.CreateMessage();
        transport.Process(message);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(requestCount, Is.EqualTo(1));
            Assert.That(message.Response, Is.Not.Null);
        }
    }

    [Test]
    public void OnReceivedResponseCalledAfterProcessing()
    {
        var responseCount = 0;
        var transport = new MockPipelineTransport(msg => new MockPipelineResponse(200))
        {
            OnReceivedResponse = msg =>
            {
                responseCount++;
                Assert.That(msg.Response, Is.Not.Null); // Response should be set
                Assert.That(msg.Response.Status, Is.EqualTo(200));
            }
        };

        var message = transport.CreateMessage();
        transport.Process(message);

        Assert.That(responseCount, Is.EqualTo(1));
    }

    [Test]
    public void ProcessWithNonMockMessageThrowsInvalidOperationException()
    {
        var transport = new MockPipelineTransport();
        var nonMockMessage = new NonMockPipelineMessage();

        var exception = Assert.Throws<InvalidOperationException>(() => transport.Process(nonMockMessage));
    }

    [Test]
    public void ProcessAsyncWithNonMockMessageThrowsInvalidOperationException()
    {
        var transport = new MockPipelineTransport();
        transport.ExpectSyncPipeline = false;
        var nonMockMessage = new NonMockPipelineMessage();

        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await transport.ProcessAsync(nonMockMessage));
    }

    [Test]
    public void ResponseFactoryReceivesCorrectMessage()
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

        Assert.That(receivedMessage, Is.Not.Null);
        Assert.That(receivedMessage, Is.SameAs(originalMessage));
        Assert.That(receivedMessage.Request.Method, Is.EqualTo("PUT"));
    }

    [Test]
    public async Task ProcessAsyncWithCallbacksExecutesInCorrectOrder()
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

        Assert.That(executionOrder.Count, Is.EqualTo(3));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(executionOrder[0], Is.EqualTo("OnSendingRequest"));
            Assert.That(executionOrder[1], Is.EqualTo("ResponseFactory"));
            Assert.That(executionOrder[2], Is.EqualTo("OnReceivedResponse"));
        }
    }

    // Helper class for testing non-mock message handling
    private class NonMockPipelineMessage : System.ClientModel.Primitives.PipelineMessage
    {
        public NonMockPipelineMessage() : base(new MockPipelineRequest())
        {
        }
    }
}
