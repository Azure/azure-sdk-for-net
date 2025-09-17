// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Castle.DynamicProxy;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class ClientTestBaseTests
{
    #region Constructor

    [Test]
    public void ConstructorSetsIsAsyncTrue()
    {
        var testBase = new TestClientTestBase(true);

        Assert.That(testBase.IsAsync, Is.True);
    }

    [Test]
    public void ConstructorSetsIsAsyncFalse()
    {
        var testBase = new TestClientTestBase(false);

        Assert.That(testBase.IsAsync, Is.False);
    }

    #endregion

    #region Properties

    [Test]
    public void TestTimeoutInSecondsDefaultsToTen()
    {
        var testBase = new TestClientTestBase(true);

        Assert.That(testBase.TestTimeoutInSeconds, Is.EqualTo(10));
    }

    [Test]
    public void TestTimeoutInSecondsCanBeSet()
    {
        var testBase = new TestClientTestBase(true)
        {
            TestTimeoutInSeconds = 30
        };

        Assert.That(testBase.TestTimeoutInSeconds, Is.EqualTo(30));
    }

    #endregion

    #region GlobalTimeoutTearDown

    [Test]
    public void GlobalTimeoutTearDownSkipsWhenDebuggerAttached()
    {
        var testBase = new TestClientTestBase(true)
        {
            TestTimeoutInSeconds = 0, // Should timeout immediately if not skipped
            IsDebuggerAttachedOverride = true
        };

        Assert.DoesNotThrow(() => testBase.GlobalTimeoutTearDown());
    }

    [Test]
    public void GlobalTimeoutTearDownThrowsOnTimeout()
    {
        var testBase = new TestClientTestBase(true)
        {
            TestTimeoutInSeconds = 0,
            IsDebuggerAttachedOverride = false,
            TestStartTimeOverride = DateTime.UtcNow.AddSeconds(-1)
        };

        var ex = Assert.Throws<TestTimeoutException>(() => testBase.GlobalTimeoutTearDown());
        Assert.That(ex.Message, Contains.Substring("exceeded global time limit"));
    }

    [Test]
    public void GlobalTimeoutTearDownDoesNotThrowWithinTimeLimit()
    {
        var testBase = new TestClientTestBase(true)
        {
            TestTimeoutInSeconds = 10,
            IsDebuggerAttachedOverride = false,
            TestStartTimeOverride = DateTime.UtcNow
        };

        Assert.DoesNotThrow(() => testBase.GlobalTimeoutTearDown());
    }

    #endregion

    #region CreateProxyFromClient

    [Test]
    public void CreateProxyFromClientReturnsProxy()
    {
        var testBase = new TestClientTestBase(true);
        var client = new TestClient("test");
        var proxy = testBase.CreateProxyFromClient(client);

        Assert.That(proxy, Is.Not.Null);
        Assert.That(proxy, Is.InstanceOf<IProxiedClient>());
    }

    [Test]
    public void CreateProxyFromClientReturnsExistingProxy()
    {
        var testBase = new TestClientTestBase(true);
        var client = new TestClient("test");

        var proxy1 = testBase.CreateProxyFromClient(client);
        var proxy2 = testBase.CreateProxyFromClient(proxy1);

        Assert.That(proxy1, Is.SameAs(proxy2));
    }

    [Test]
    public void CreateProxyFromClientWithPreInterceptors()
    {
        var testBase = new TestClientTestBase(true);
        var client = new TestClient("test");
        var interceptors = new[] { new TestInterceptor() };

        var proxy = testBase.CreateProxyFromClient(typeof(TestClient), client, interceptors);

        Assert.That(proxy, Is.Not.Null);
        Assert.That(proxy, Is.InstanceOf<IProxiedClient>());
    }

    [Test]
    public void CreateProxyFromClientThrowsOnInvalidClient()
    {
        var testBase = new TestClientTestBase(true);
        var client = new InvalidTestClient();

        var ex = Assert.Throws<InvalidOperationException>(() =>
            testBase.CallCreateProxyFromClientInternal(client.GetType(), client, null));

        Assert.That(ex.Message, Contains.Substring("public non-virtual async method"));
    }

    #endregion

    #region GetOriginal

    [Test]
    public void GetOriginalReturnsOriginalFromProxy()
    {
        var testBase = new TestClientTestBase(true);
        var client = new TestClient("test");
        var proxy = testBase.CreateProxyFromClient(client);

        var original = testBase.CallGetOriginal(proxy);

        Assert.That(original, Is.SameAs(client));
    }

    [Test]
    public void GetOriginalThrowsOnNull()
    {
        var testBase = new TestClientTestBase(true);

        Assert.Throws<ArgumentNullException>(() => testBase.CallGetOriginal<TestClient>(null));
    }

    [Test]
    public void GetOriginalThrowsOnNonProxy()
    {
        var testBase = new TestClientTestBase(true);
        var client = new TestClient("test");

        var ex = Assert.Throws<InvalidOperationException>(() => testBase.CallGetOriginal(client));
        Assert.That(ex.Message, Contains.Substring("is not an instrumented type"));
    }

    #endregion

    #region Helper Classes

    public class TestClient
    {
        public string Value { get; }

        public TestClient() : this("default") { }

        public TestClient(string value)
        {
            Value = value;
        }

        public virtual string GetData() => Value;
        public virtual Task<string> GetDataAsync() => Task.FromResult(Value);
    }

    private class TestClientWithPrivateConstructor
    {
        private TestClientWithPrivateConstructor() { }
    }

    public class InvalidTestClient
    {
        // Non-virtual async method should cause validation error
        public Task<string> GetDataAsync() => Task.FromResult("data");
    }

    public class TestOperationResult : OperationResult
    {
        public TestOperationResult() : this(new MockPipelineResponse(200)) { }

        public TestOperationResult(PipelineResponse response) : base(response)
        {
        }

        public override ContinuationToken RehydrationToken { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override ClientResult UpdateStatus(RequestOptions options = null)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ClientResult> UpdateStatusAsync(System.ClientModel.Primitives.RequestOptions options)
        {
            return new ValueTask<ClientResult>(ClientResult.FromOptionalValue<object>(null, new MockPipelineResponse(200)));
        }
    }

    private class TestInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }

    private class TestClientTestBase : ClientTestBase
    {
        public bool IsDebuggerAttachedOverride { get; set; }
        public DateTime? TestStartTimeOverride { get; set; }

        public TestClientTestBase(bool isAsync) : base(isAsync) { }

        public override void GlobalTimeoutTearDown()
        {
            if (IsDebuggerAttachedOverride)
            {
                return;
            }

            var duration = DateTime.UtcNow - (TestStartTimeOverride ?? TestStartTime);
            if (duration > TimeSpan.FromSeconds(TestTimeoutInSeconds))
            {
                throw new TestTimeoutException($"Test exceeded global time limit of {TestTimeoutInSeconds} seconds. Duration: {duration}");
            }
        }

        public DateTime GetTestStartTime() => TestStartTime;

        public object CallCreateProxyFromClientInternal(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
        {
            return CreateProxyFromClient(clientType, client, preInterceptors);
        }

        public T CallGetOriginal<T>(T proxied)
        {
            return GetOriginal(proxied);
        }
    }

    private class TestTimeoutException : Exception
    {
        public TestTimeoutException(string message) : base(message) { }
    }

    #endregion
}
