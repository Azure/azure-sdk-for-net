// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Integration;
[TestFixture]
public class SyncAsyncIntegrationTests
{
    [Test]
    public void AsyncOnlyAttribute_WithSyncOnlyAttribute_AreCompatible()
    {
        // Verify both attributes can coexist
        var asyncAttr = new AsyncOnlyAttribute();
        var syncAttr = new SyncOnlyAttribute();
        Assert.IsNotNull(asyncAttr);
        Assert.IsNotNull(syncAttr);
        Assert.IsInstanceOf<NUnitAttribute>(asyncAttr);
        Assert.IsInstanceOf<NUnitAttribute>(syncAttr);
    }
    [Test]
    public void ClientTestBase_WithProxiedClient_WorksEndToEnd()
    {
        var testBase = new TestableClientTestBase(isAsync: false);
        var client = testBase.CreateProxiedClientPublic<MockClientForIntegration>();
        Assert.IsNotNull(client);
        Assert.IsInstanceOf<IProxiedClient>(client);
        var original = testBase.GetOriginalClient(client);
        Assert.IsInstanceOf<MockClientForIntegration>(original);
        testBase.Dispose();
    }
    //[Test]
    //public void ClientTestBase_WithOperationResult_WorksEndToEnd()
    //{
    //    var testBase = new TestableClientTestBase(isAsync: true);
    //    var operation = new MockOperationResultForIntegration();
    //    var proxiedOperation = testBase.CreateProxyFromOperationResult(operation);
    //    Assert.IsNotNull(proxiedOperation);
    //    Assert.IsInstanceOf<IProxiedOperationResult>(proxiedOperation);
    //    testBase.Dispose();
    //}
    //[Test]
    //public void SyncAsyncTestBase_WithMockTransport_CreatesCompatiblePipeline()
    //{
    //    var syncTestBase = new SyncAsyncTestBase(isAsync: false);
    //    var asyncTestBase = new SyncAsyncTestBase(isAsync: true);
    //    var syncTransport = syncTestBase.CreateMockTransport();
    //    var asyncTransport = asyncTestBase.CreateMockTransport();
    //    Assert.IsTrue(syncTransport.ExpectSyncPipeline);
    //    Assert.IsFalse(asyncTransport.ExpectSyncPipeline);
    //}
    //[Test]
    //public async Task SyncAsyncPolicyTestBase_EndToEndPipelineTest()
    //{
    //    var testBase = new SyncAsyncPolicyTestBase(isAsync: true);
    //    var transport = testBase.CreateMockTransport(msg => new MockPipelineResponse(200));
    //    var pipeline = ClientPipeline.Create(new ClientPipelineOptions { Transport = transport });
    //    var response = await testBase.SendRequestAsync(pipeline, request =>
    //    {
    //        request.Method = "GET";
    //        request.Uri = new Uri("https://example.com/integration");
    //    });
    //    Assert.IsNotNull(response);
    //    Assert.AreEqual(200, response.Status);
    //}
    [Test]
    public void ClientTestFixture_WithMultipleTestClasses_WorksTogether()
    {
        var fixture1 = new ClientTestFixtureAttribute();
        var fixture2 = new ClientTestFixtureAttribute("param1", "param2");
        Assert.IsNotNull(fixture1);
        Assert.IsNotNull(fixture2);
        // Both should implement the same interfaces
        Assert.IsInstanceOf<NUnitAttribute>(fixture1);
        Assert.IsInstanceOf<NUnitAttribute>(fixture2);
    }
    [Test]
    public void ProxiedInterfaces_WorkWithClientTestBase()
    {
        var testBase = new TestableClientTestBase(isAsync: false);
        var client = testBase.CreateProxiedClientPublic<MockClientForIntegration>();
        // Verify the proxy implements both the original type and IProxiedClient
        Assert.IsInstanceOf<MockClientForIntegration>(client);
        Assert.IsInstanceOf<IProxiedClient>(client);
        // Verify we can get the original back
        var proxied = (IProxiedClient)client;
        var original = testBase.GetOriginalClient(client);
        Assert.IsNotNull(proxied.Original);
        Assert.AreSame(proxied.Original, original);
        testBase.Dispose();
    }
    //[Test]
    //public void AsyncMethodWrapper_Integration_WithClientTestBase()
    //{
    //    // Test that AsyncMethodWrapper works in integration with ClientTestBase
    //    var testBase = new TestableClientTestBase(isAsync: false); // Force sync
    //    var client = testBase.CreateProxiedClient<MockClientWithAsyncMethods>();
    //    Assert.IsNotNull(client);
    //    // Should be able to call async methods that get intercepted to sync
    //    Assert.DoesNotThrow(() =>
    //    {
    //        var result = client.GetValueAsync();
    //        Assert.IsNotNull(result);
    //    });
    //    testBase.Dispose();
    //}
    [Test]
    public void SyncAsync_AttributesWorkWithClientTestFixture()
    {
        // Test that AsyncOnly and SyncOnly attributes work with ClientTestFixture
        var asyncMethod = typeof(TestClassWithAttributes).GetMethod(nameof(TestClassWithAttributes.AsyncOnlyMethod));
        var syncMethod = typeof(TestClassWithAttributes).GetMethod(nameof(TestClassWithAttributes.SyncOnlyMethod));
        var asyncAttr = asyncMethod.GetCustomAttributes(typeof(AsyncOnlyAttribute), false);
        var syncAttr = syncMethod.GetCustomAttributes(typeof(SyncOnlyAttribute), false);
        Assert.Greater(asyncAttr.Length, 0);
        Assert.Greater(syncAttr.Length, 0);
    }
    [Test]
    public void GlobalTimeout_Integration_WithTestExecution()
    {
        var testBase = new TestableClientTestBase(isAsync: false);
        testBase.TestTimeoutInSeconds = 5;
        // Should not throw for quick operations
        Assert.DoesNotThrow(() => testBase.GlobalTimeoutTearDown());
        testBase.Dispose();
    }
    //[Test]
    //public void StreamValidation_Integration_WithSyncAsyncTestBase()
    //{
    //    var syncTestBase = new SyncAsyncTestBase(isAsync: false);
    //    var asyncTestBase = new SyncAsyncTestBase(isAsync: true);
    //    using var stream1 = new System.IO.MemoryStream();
    //    using var stream2 = new System.IO.MemoryStream();
    //    var syncWrapped = syncTestBase.WrapStream(stream1);
    //    var asyncWrapped = asyncTestBase.WrapStream(stream2);
    //    Assert.IsNotNull(syncWrapped);
    //    Assert.IsNotNull(asyncWrapped);
    //    Assert.AreNotSame(stream1, syncWrapped);
    //    Assert.AreNotSame(stream2, asyncWrapped);
    //}
    // Helper classes for integration testing
    public class TestableClientTestBase : ClientTestBase
    {
        public TestableClientTestBase(bool isAsync) : base(isAsync) { }
        public T GetOriginalClient<T>(T proxiedClient) where T : class
        {
            return GetOriginal(proxiedClient);
        }
        public TClient CreateProxiedClientPublic<TClient>(params object[] args) where TClient : class
        {
            return CreateProxiedClient<TClient>(args);
        }
        public void Dispose()
        {
            // Clean up test resources
        }
    }
    public class MockClientForIntegration
    {
        public virtual string GetValue() => "integration-test";
        public virtual Task<string> GetValueAsync() => Task.FromResult("integration-test-async");
    }
    public class MockClientWithAsyncMethods
    {
        public virtual string GetValue() => "sync";
        public virtual Task<string> GetValueAsync() => Task.FromResult("async");
        public virtual void DoWork() { }
        public virtual Task DoWorkAsync() => Task.CompletedTask;
    }
    public class MockOperationResultForIntegration : OperationResult
    {
        public MockOperationResultForIntegration(PipelineResponse response) : base(response)
        {
        }
        public override ValueTask<ClientResult> UpdateStatusAsync(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public override ClientResult UpdateStatus(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }
        public override ContinuationToken RehydrationToken { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }
    }
    [ClientTestFixture]
    public class TestClassWithAttributes : ClientTestBase
    {
        public TestClassWithAttributes(bool isAsync) : base(isAsync) { }
        [AsyncOnly]
        public void AsyncOnlyMethod()
        {
            // This method should only run in async mode
        }
        [SyncOnly]
        public void SyncOnlyMethod()
        {
            // This method should only run in sync mode
        }
        public void RegularMethod()
        {
            // This method runs in both modes
        }
    }
}
