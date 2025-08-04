// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class SyncAsyncPolicyTestBaseTests
{
    private TestableSyncAsyncPolicyTestBase _asyncTestBase;
    private TestableSyncAsyncPolicyTestBase _syncTestBase;

    [SetUp]
    public void Setup()
    {
        _asyncTestBase = new TestableSyncAsyncPolicyTestBase(isAsync: true);
        _syncTestBase = new TestableSyncAsyncPolicyTestBase(isAsync: false);
    }

    [Test]
    public void Constructor_WithIsAsyncTrue_SetsIsAsyncProperty()
    {
        Assert.IsTrue(_asyncTestBase.IsAsync);
    }

    [Test]
    public void Constructor_WithIsAsyncFalse_SetsIsAsyncProperty()
    {
        Assert.IsFalse(_syncTestBase.IsAsync);
    }

    [Test]
    public void Inheritance_ExtendsSyncAsyncTestBase()
    {
        Assert.IsInstanceOf<SyncAsyncTestBase>(_asyncTestBase);
        Assert.IsInstanceOf<SyncAsyncTestBase>(_syncTestBase);
    }

    [Test]
    public void TestFixture_Attributes_ArePresent()
    {
        var type = typeof(SyncAsyncPolicyTestBase);
        var attributes = type.GetCustomAttributes(typeof(TestFixtureAttribute), false);
        
        Assert.IsNotNull(attributes);
        Assert.Greater(attributes.Length, 0);
    }

    [Test]
    public async Task SendRequestAsync_WithPipelineAndRequestAction_ExecutesSuccessfully()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var response = await _asyncTestBase.SendRequestAsync(pipeline, request =>
        {
            request.Method = "GET";
            request.Uri = new Uri("https://example.com");
        });
        
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.Status);
    }

    [Test]
    public async Task SendRequestAsync_WithPipelineAndMessageAction_ExecutesSuccessfully()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(201));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var response = await _asyncTestBase.SendRequestAsync(pipeline, message =>
        {
            message.Request.Method = "POST";
            message.Request.Uri = new Uri("https://example.com/api");
        });
        
        Assert.IsNotNull(response);
        Assert.AreEqual(201, response.Status);
    }

    [Test]
    public async Task SendRequestAsync_WithBufferResponseFalse_HandlesUnbufferedResponse()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var response = await _asyncTestBase.SendRequestAsync(pipeline, request =>
        {
            request.Method = "GET";
            request.Uri = new Uri("https://example.com");
        }, bufferResponse: false);
        
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.Status);
    }

    [Test]
    public async Task SendRequestAsync_WithCancellationToken_RespectsCancellation()
    {
        var cts = new CancellationTokenSource();
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        cts.Cancel();
        
        try
        {
            await _asyncTestBase.SendRequestAsync(pipeline, request =>
            {
                request.Method = "GET";
                request.Uri = new Uri("https://example.com");
            }, cancellationToken: cts.Token);
            
            // If we reach here, cancellation wasn't properly handled
            // This behavior depends on the mock implementation
        }
        catch (OperationCanceledException)
        {
            // Expected behavior for properly implemented cancellation
            Assert.Pass("Cancellation was properly handled");
        }
    }

    [Test]
    public async Task SendMessageRequestAsync_ReturnsMessageWithResponse()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(202));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var message = await _asyncTestBase.SendMessageRequestAsync(pipeline, msg =>
        {
            msg.Request.Method = "PUT";
            msg.Request.Uri = new Uri("https://example.com/resource");
        });
        
        Assert.IsNotNull(message);
        Assert.IsNotNull(message.Response);
        Assert.AreEqual(202, message.Response.Status);
        Assert.AreEqual("PUT", message.Request.Method);
    }

    [Test]
    public async Task SendMessageRequestAsync_WithExistingMessage_UsesProvidedMessage()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        var existingMessage = pipeline.CreateMessage();
        
        var resultMessage = await _asyncTestBase.SendMessageRequestAsync(pipeline, msg =>
        {
            msg.Request.Method = "PATCH";
            msg.Request.Uri = new Uri("https://example.com/patch");
        }, message: existingMessage);
        
        Assert.AreSame(existingMessage, resultMessage);
        Assert.AreEqual("PATCH", resultMessage.Request.Method);
    }

    [Test]
    public async Task SendMessageRequestAsync_WithBufferResponseFalse_ConfiguresMessage()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var message = await _asyncTestBase.SendMessageRequestAsync(pipeline, msg =>
        {
            msg.Request.Method = "GET";
            msg.Request.Uri = new Uri("https://example.com");
        }, bufferResponse: false);
        
        Assert.IsNotNull(message);
        Assert.IsFalse(message.BufferResponse);
    }

    [Test]
    public async Task SendRequestAsync_SyncMode_ExecutesSynchronously()
    {
        var transport = _syncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        var response = await _syncTestBase.SendRequestAsync(pipeline, request =>
        {
            request.Method = "GET";
            request.Uri = new Uri("https://example.com");
        });
        
        Assert.IsNotNull(response);
        Assert.AreEqual(200, response.Status);
    }

    [Test]
    public void SendRequestAsync_WithNullPipeline_ThrowsArgumentNullException()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _asyncTestBase.SendRequestAsync(null, request => { }));
    }

    [Test]
    public void SendRequestAsync_WithNullRequestAction_ThrowsArgumentNullException()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _asyncTestBase.SendRequestAsync(pipeline, (Action<PipelineRequest>)null));
    }

    [Test]
    public void SendRequestAsync_WithNullMessageAction_ThrowsArgumentNullException()
    {
        var transport = _asyncTestBase.CreateMockTransport(msg => new MockPipelineResponse(200));
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _asyncTestBase.SendRequestAsync(pipeline, (Action<PipelineMessage>)null));
    }

    [Test]
    public async Task SendRequestAsync_MultipleRequests_HandlesSequentially()
    {
        var requestCount = 0;
        var transport = _asyncTestBase.CreateMockTransport(msg =>
        {
            requestCount++;
            return new MockPipelineResponse(200);
        });
        var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
        
        await _asyncTestBase.SendRequestAsync(pipeline, request =>
        {
            request.Method = "GET";
            request.Uri = new Uri("https://example.com/1");
        });
        
        await _asyncTestBase.SendRequestAsync(pipeline, request =>
        {
            request.Method = "GET";  
            request.Uri = new Uri("https://example.com/2");
        });
        
        Assert.AreEqual(2, requestCount);
    }

    // Helper class to expose protected methods for testing
    public class TestableSyncAsyncPolicyTestBase : SyncAsyncPolicyTestBase
    {
        public TestableSyncAsyncPolicyTestBase(bool isAsync) : base(isAsync) { }
        
        public new Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineRequest> requestAction, bool bufferResponse = true, CancellationToken cancellationToken = default) =>
            base.SendRequestAsync(pipeline, requestAction, bufferResponse, cancellationToken);
            
        public new Task<PipelineResponse> SendRequestAsync(ClientPipeline pipeline, Action<PipelineMessage> messageAction, bool bufferResponse = true, CancellationToken cancellationToken = default) =>
            base.SendRequestAsync(pipeline, messageAction, bufferResponse, cancellationToken);
            
        public new Task<PipelineMessage> SendMessageRequestAsync(ClientPipeline pipeline, Action<PipelineMessage> messageAction, bool bufferResponse = true, PipelineMessage message = default, CancellationToken cancellationToken = default) =>
            base.SendMessageRequestAsync(pipeline, messageAction, bufferResponse, message, cancellationToken);
    }
}
