// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;
[TestFixture]
public class ClientTestBaseTests
{
    private TestableClientTestBase _testBase;
    [SetUp]
    public void Setup()
    {
        _testBase = new TestableClientTestBase(isAsync: false);
    }
    [TearDown]
    public void TearDown()
    {
        _testBase?.Dispose();
    }
    [Test]
    public void Constructor_WithIsAsyncTrue_SetsIsAsyncProperty()
    {
        var clientTest = new TestableClientTestBase(isAsync: true);
        Assert.IsTrue(clientTest.IsAsync);
        clientTest.Dispose();
    }
    [Test]
    public void Constructor_WithIsAsyncFalse_SetsIsAsyncProperty()
    {
        var clientTest = new TestableClientTestBase(isAsync: false);
        Assert.IsFalse(clientTest.IsAsync);
        clientTest.Dispose();
    }
    [Test]
    public void TestTimeoutInSeconds_DefaultValue_Is10()
    {
        Assert.AreEqual(10, _testBase.TestTimeoutInSeconds);
    }
    [Test]
    public void TestTimeoutInSeconds_CanBeSet()
    {
        _testBase.TestTimeoutInSeconds = 30;
        Assert.AreEqual(30, _testBase.TestTimeoutInSeconds);
    }
    [Test]
    public void IsAsync_Property_ReflectsConstructorValue()
    {
        var asyncTest = new TestableClientTestBase(isAsync: true);
        var syncTest = new TestableClientTestBase(isAsync: false);
        Assert.IsTrue(asyncTest.IsAsync);
        Assert.IsFalse(syncTest.IsAsync);
        asyncTest.Dispose();
        syncTest.Dispose();
    }
    [Test]
    public void CreateProxiedClient_WithValidType_ReturnsProxiedInstance()
    {
        var client = _testBase.CreateProxiedClientPublic<MockClient>();
        Assert.IsNotNull(client);
        Assert.IsInstanceOf<MockClient>(client);
        Assert.IsInstanceOf<IProxiedClient>(client);
    }
    [Test]
    public void CreateProxiedClient_WithConstructorArgs_PassesArgsToConstructor()
    {
        var expectedValue = "test-value";
        var client = _testBase.CreateProxiedClientPublic<MockClientWithArgs>(expectedValue);
        Assert.IsNotNull(client);
        Assert.AreEqual(expectedValue, client.Value);
    }
    [Test]
    public void CreateProxiedClient_WithInvalidConstructorArgs_ThrowsException()
    {
        Assert.Throws<MissingMethodException>(() =>
            _testBase.CreateProxiedClientPublic<MockClient>("unexpected-arg"));
    }
    [Test]
    public void CreateProxyFromClient_WithValidClient_ReturnsProxiedInstance()
    {
        var originalClient = new MockClient();
        var proxiedClient = _testBase.CreateProxyFromClient(originalClient);
        Assert.IsNotNull(proxiedClient);
        Assert.IsInstanceOf<MockClient>(proxiedClient);
        Assert.IsInstanceOf<IProxiedClient>(proxiedClient);
        Assert.AreNotSame(originalClient, proxiedClient);
    }
    [Test]
    public void CreateProxyFromClient_WithAlreadyProxiedClient_ReturnsSameInstance()
    {
        var originalClient = new MockClient();
        var proxiedClient = _testBase.CreateProxyFromClient(originalClient);
        var doubleProxiedClient = _testBase.CreateProxyFromClient(proxiedClient);
        Assert.AreSame(proxiedClient, doubleProxiedClient);
    }
    [Test]
    public void GetOriginal_WithProxiedClient_ReturnsOriginalInstance()
    {
        var originalClient = new MockClient();
        var proxiedClient = _testBase.CreateProxyFromClient(originalClient);
        var retrievedOriginal = _testBase.GetOriginalClient(proxiedClient);
        Assert.AreSame(originalClient, retrievedOriginal);
    }
    [Test]
    public void GetOriginal_WithNullClient_ThrowsArgumentNullException()
    {
        MockClient nullClient = null;
        Assert.Throws<ArgumentNullException>(() => _testBase.GetOriginalClient(nullClient));
    }
    [Test]
    public void GetOriginal_WithNonProxiedClient_ThrowsInvalidOperationException()
    {
        var nonProxiedClient = new MockClient();
        Assert.Throws<InvalidOperationException>(() => _testBase.GetOriginalClient(nonProxiedClient));
    }
    [Test]
    public void CreateProxyFromOperationResult_WithValidOperation_ReturnsProxiedInstance()
    {
        var operation = new MockOperationResult(new MockPipelineResponse());
        var proxiedOperation = _testBase.CreateProxyFromOperationResult(operation);
        Assert.IsNotNull(proxiedOperation);
        Assert.IsInstanceOf<MockOperationResult>(proxiedOperation);
        Assert.IsInstanceOf<IProxiedOperationResult>(proxiedOperation);
    }
    [Test]
    public void AdditionalInterceptors_Property_CanBeSetAndRetrieved()
    {
        var interceptors = new[] { new MockInterceptor() };
        _testBase.SetAdditionalInterceptors(interceptors);
        Assert.IsNotNull(_testBase.GetAdditionalInterceptors());
        Assert.AreEqual(1, _testBase.GetAdditionalInterceptors().Count);
    }
    [Test]
    public void ProxyGenerator_Property_IsNotNull()
    {
        Assert.IsNotNull(TestableClientTestBase.GetProxyGenerator());
    }
    [Test]
    public void GlobalTimeoutTearDown_WithinTimeLimit_DoesNotThrow()
    {
        _testBase.TestTimeoutInSeconds = 10;
        Assert.DoesNotThrow(() => _testBase.GlobalTimeoutTearDown());
    }
    [Test]
    public void CreateProxyFromClient_WithNonVirtualAsyncMethod_ThrowsInvalidOperationException()
    {
        var invalidClient = new ClientWithNonVirtualAsync();
        var ex = Assert.Throws<InvalidOperationException>(() =>
            _testBase.CreateProxyFromClient(invalidClient));
        Assert.That(ex.Message, Contains.Substring("non-virtual async method"));
    }
    // Helper classes for testing
    public class TestableClientTestBase : ClientTestBase
    {
        public TestableClientTestBase(bool isAsync) : base(isAsync) { }
        public void SetAdditionalInterceptors(System.Collections.Generic.IReadOnlyCollection<Castle.DynamicProxy.IInterceptor> interceptors)
        {
            AdditionalInterceptors = interceptors;
        }
        public System.Collections.Generic.IReadOnlyCollection<Castle.DynamicProxy.IInterceptor> GetAdditionalInterceptors()
        {
            return AdditionalInterceptors;
        }
        public static Castle.DynamicProxy.ProxyGenerator GetProxyGenerator()
        {
            return ProxyGenerator;
        }
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
            // Clean up test resources if needed
        }
    }
    public class MockClient
    {
        public virtual string GetValue() => "mock";
        public virtual Task<string> GetValueAsync() => Task.FromResult("mock");
    }
    public class MockClientWithArgs
    {
        public string Value { get; }
        public MockClientWithArgs(string value)
        {
            Value = value;
        }
        public virtual string GetValue() => Value;
    }
    public class MockOperationResult : OperationResult
    {
        public MockOperationResult(PipelineResponse response) : base(response)
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
    public class MockInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
    public class ClientWithNonVirtualAsync
    {
        public Task<string> GetValueAsync() => Task.FromResult("invalid"); // Non-virtual async method
    }
}
