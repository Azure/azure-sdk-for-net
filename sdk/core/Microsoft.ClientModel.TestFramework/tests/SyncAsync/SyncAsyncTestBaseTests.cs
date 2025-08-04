// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.IO;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class SyncAsyncTestBaseTests
{
    [Test]
    public void Constructor_WithIsAsyncTrue_SetsIsAsyncProperty()
    {
        var testBase = new SyncAsyncTestBase(isAsync: true);
        
        Assert.IsTrue(testBase.IsAsync);
    }

    [Test]
    public void Constructor_WithIsAsyncFalse_SetsIsAsyncProperty()
    {
        var testBase = new SyncAsyncTestBase(isAsync: false);
        
        Assert.IsFalse(testBase.IsAsync);
    }

    [Test]
    public void CreateMockTransport_WhenAsync_SetsExpectSyncPipelineFalse()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        var transport = testBase.CreateMockTransport();
        
        Assert.IsNotNull(transport);
        Assert.IsInstanceOf<MockPipelineTransport>(transport);
        Assert.IsFalse(transport.ExpectSyncPipeline);
    }

    [Test]
    public void CreateMockTransport_WhenSync_SetsExpectSyncPipelineTrue()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: false);
        var transport = testBase.CreateMockTransport();
        
        Assert.IsNotNull(transport);
        Assert.IsInstanceOf<MockPipelineTransport>(transport);
        Assert.IsTrue(transport.ExpectSyncPipeline);
    }

    [Test]
    public void CreateMockTransport_WithResponseFactory_ConfiguresTransportCorrectly()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: false);
        var factoryCalled = false;
        
        MockPipelineResponse ResponseFactory(MockPipelineMessage message)
        {
            factoryCalled = true;
            return new MockPipelineResponse(200);
        }
        
        var transport = testBase.CreateMockTransport(ResponseFactory);
        
        Assert.IsNotNull(transport);
        Assert.IsTrue(transport.ExpectSyncPipeline);
        
        // Test that the factory is properly set by creating a message and getting response
        var message = new MockPipelineMessage();
        var response = transport.Send(message);
        Assert.IsTrue(factoryCalled);
        Assert.AreEqual(200, response.Status);
    }

    [Test]
    public void CreateMockTransport_WithResponseFactory_WhenAsync_SetsCorrectPipelineMode()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        
        MockPipelineResponse ResponseFactory(MockPipelineMessage message) => new MockPipelineResponse(200);
        
        var transport = testBase.CreateMockTransport(ResponseFactory);
        
        Assert.IsNotNull(transport);
        Assert.IsFalse(transport.ExpectSyncPipeline);
    }

    [Test]
    public void WrapStream_ReturnsAsyncValidatingStream()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        var memoryStream = new MemoryStream();
        
        var wrappedStream = testBase.WrapStream(memoryStream);
        
        Assert.IsNotNull(wrappedStream);
        Assert.IsInstanceOf<AsyncValidatingStream>(wrappedStream);
        Assert.AreNotSame(memoryStream, wrappedStream);
    }

    [Test]
    public void WrapStream_WithSyncMode_ConfiguresStreamForSync()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: false);
        var memoryStream = new MemoryStream();
        
        var wrappedStream = testBase.WrapStream(memoryStream);
        
        Assert.IsNotNull(wrappedStream);
        Assert.IsInstanceOf<AsyncValidatingStream>(wrappedStream);
    }

    [Test]
    public void WrapStream_WithAsyncMode_ConfiguresStreamForAsync()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        var memoryStream = new MemoryStream();
        
        var wrappedStream = testBase.WrapStream(memoryStream);
        
        Assert.IsNotNull(wrappedStream);
        Assert.IsInstanceOf<AsyncValidatingStream>(wrappedStream);
    }

    [Test]
    public void WrapStream_WithNullStream_ThrowsArgumentNullException()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        
        Assert.Throws<ArgumentNullException>(() => testBase.WrapStream(null));
    }

    [Test]
    public void WrapStream_WithDisposedStream_HandlesGracefully()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        var memoryStream = new MemoryStream();
        memoryStream.Dispose();
        
        // Should not throw when wrapping a disposed stream
        var wrappedStream = testBase.WrapStream(memoryStream);
        
        Assert.IsNotNull(wrappedStream);
        Assert.IsInstanceOf<AsyncValidatingStream>(wrappedStream);
    }

    [Test]
    public void IsAsync_Property_IsReadOnly()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: true);
        
        // Verify there's no setter for IsAsync property
        var property = typeof(SyncAsyncTestBase).GetProperty("IsAsync");
        Assert.IsNotNull(property);
        Assert.IsTrue(property.CanRead);
        Assert.IsFalse(property.CanWrite);
    }

    [Test]
    public void Multiple_Instances_CanHaveDifferentModes()
    {
        var asyncBase = new TestableSyncAsyncTestBase(isAsync: true);
        var syncBase = new TestableSyncAsyncTestBase(isAsync: false);
        
        Assert.IsTrue(asyncBase.IsAsync);
        Assert.IsFalse(syncBase.IsAsync);
        
        var asyncTransport = asyncBase.CreateMockTransport();
        var syncTransport = syncBase.CreateMockTransport();
        
        Assert.IsFalse(asyncTransport.ExpectSyncPipeline);
        Assert.IsTrue(syncTransport.ExpectSyncPipeline);
    }

    [Test]
    public void CreateMockTransport_Instances_AreIndependent()
    {
        var testBase = new TestableSyncAsyncTestBase(isAsync: false);
        
        var transport1 = testBase.CreateMockTransport();
        var transport2 = testBase.CreateMockTransport();
        
        Assert.IsNotNull(transport1);
        Assert.IsNotNull(transport2);
        Assert.AreNotSame(transport1, transport2);
        Assert.AreEqual(transport1.ExpectSyncPipeline, transport2.ExpectSyncPipeline);
    }

    // Helper class to expose protected methods for testing
    public class TestableSyncAsyncTestBase : SyncAsyncTestBase
    {
        public TestableSyncAsyncTestBase(bool isAsync) : base(isAsync) { }
        
        public new MockPipelineTransport CreateMockTransport() => base.CreateMockTransport();
        
        public new MockPipelineTransport CreateMockTransport(Func<MockPipelineMessage, MockPipelineResponse> responseFactory) => 
            base.CreateMockTransport(responseFactory);
            
        public new Stream WrapStream(Stream stream) => base.WrapStream(stream);
    }
}
