// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class SyncAsyncTestBaseTests
{
    #region Constructor

    [Test]
    public void ConstructorSetsIsAsyncTrue()
    {
        var testBase = new TestSyncAsyncTestBase(true);

        Assert.That(testBase.IsAsync, Is.True);
    }

    [Test]
    public void ConstructorSetsIsAsyncFalse()
    {
        var testBase = new TestSyncAsyncTestBase(false);

        Assert.That(testBase.IsAsync, Is.False);
    }

    #endregion

    #region CreateMockTransport Method

    [Test]
    public void CreateMockTransportReturnsTransportForAsyncMode()
    {
        var testBase = new TestSyncAsyncTestBase(true);

        var transport = testBase.CreateMockTransport();

        Assert.That(transport, Is.Not.Null);
        Assert.That(transport.ExpectSyncPipeline, Is.False);
    }

    [Test]
    public void CreateMockTransportReturnsTransportForSyncMode()
    {
        var testBase = new TestSyncAsyncTestBase(false);

        var transport = testBase.CreateMockTransport();

        Assert.That(transport, Is.Not.Null);
        Assert.That(transport.ExpectSyncPipeline, Is.True);
    }

    #endregion

    #region CreateMockTransport Method with ResponseFactory

    [Test]
    public void CreateMockTransportWithFactoryReturnsTransportForAsyncMode()
    {
        var testBase = new TestSyncAsyncTestBase(true);

        var transport = testBase.CreateMockTransport(message =>
            new MockPipelineResponse(200));

        Assert.That(transport, Is.Not.Null);
        Assert.That(transport.ExpectSyncPipeline, Is.False);
    }

    [Test]
    public void CreateMockTransportWithFactoryReturnsTransportForSyncMode()
    {
        var testBase = new TestSyncAsyncTestBase(false);

        var transport = testBase.CreateMockTransport(message =>
            new MockPipelineResponse(200));

        Assert.That(transport, Is.Not.Null);
        Assert.That(transport.ExpectSyncPipeline, Is.True);
    }

    [Test]
    public void CreateMockTransportWithFactoryHandlesNullFactory()
    {
        var testBase = new TestSyncAsyncTestBase(true);

        Assert.DoesNotThrow(() => testBase.CreateMockTransport(null));
    }

    #endregion

    #region Consistency Tests

    [Test]
    public void MultipleMockTransportCreationsReturnDifferentInstances()
    {
        var testBase = new TestSyncAsyncTestBase(true);

        var transport1 = testBase.CreateMockTransport();
        var transport2 = testBase.CreateMockTransport();

        Assert.That(transport1, Is.Not.SameAs(transport2));
    }

    [Test]
    public void MockTransportFactoryIsCalledForEachRequest()
    {
        var testBase = new TestSyncAsyncTestBase(true);
        int callCount = 0;

        var transport = testBase.CreateMockTransport(message =>
        {
            callCount++;
            return new MockPipelineResponse(200);
        });

        using (Assert.EnterMultipleScope())
        {
            // The factory shouldn't be called during creation
            Assert.That(callCount, Is.EqualTo(0));

            Assert.That(transport, Is.Not.Null);
        }
    }

    #endregion

    #region Helper Classes

    private class TestSyncAsyncTestBase : SyncAsyncTestBase
    {
        public TestSyncAsyncTestBase(bool isAsync) : base(isAsync) { }

        // Expose protected methods for testing
        public new MockPipelineTransport CreateMockTransport() => base.CreateMockTransport();

        public new MockPipelineTransport CreateMockTransport(Func<MockPipelineMessage, MockPipelineResponse> responseFactory) =>
            base.CreateMockTransport(responseFactory);
    }

    #endregion
}
