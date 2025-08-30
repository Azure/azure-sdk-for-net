// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync.Interceptors;

[TestFixture]
public class AsyncCollectionResultInterceptorTests
{
    #region Constructor

    [Test]
    public void ConstructorSetsProperties()
    {
        var testBase = new TestClientTestBase(false);
        var inner = new MockAsyncEnumerator<TestItem>();

        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        Assert.That(interceptor, Is.Not.Null);
    }

    #endregion

    #region Current Property

    [Test]
    public void CurrentReturnsProxiedValue()
    {
        var testBase = new TestClientTestBase(false);
        var testItem = new TestItem { Value = "test" };
        var inner = new MockAsyncEnumerator<TestItem> { CurrentValue = testItem };

        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        var result = interceptor.Current;

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<TestItem>());
        // The result should be a proxy created by the test base
    }

    [Test]
    public void CurrentThrowsWhenProxyCreationReturnsNull()
    {
        var testBase = new TestClientTestBase(false) { ShouldReturnNullProxy = true };
        var testItem = new TestItem { Value = "test" };
        var inner = new MockAsyncEnumerator<TestItem> { CurrentValue = testItem };

        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        Assert.Throws<InvalidOperationException>(() => _ = interceptor.Current);
    }

    #endregion

    #region MoveNextAsync

    [Test]
    public async Task MoveNextAsyncDelegatesToInner()
    {
        var testBase = new TestClientTestBase(false);
        var inner = new MockAsyncEnumerator<TestItem> { MoveNextResult = true };
        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        var result = await interceptor.MoveNextAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(inner.MoveNextCalled, Is.True);
        }
    }

    [Test]
    public async Task MoveNextAsyncReturnsFalseWhenInnerReturnsFalse()
    {
        var testBase = new TestClientTestBase(false);
        var inner = new MockAsyncEnumerator<TestItem> { MoveNextResult = false };
        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        var result = await interceptor.MoveNextAsync();

        Assert.That(result, Is.False);
    }

    #endregion

    #region DisposeAsync

    [Test]
    public async Task DisposeAsyncDelegatesToInner()
    {
        var testBase = new TestClientTestBase(false);
        var inner = new MockAsyncEnumerator<TestItem>();
        var interceptor = new AsyncCollectionResultInterceptor<TestItem>(testBase, inner);

        await interceptor.DisposeAsync();

        Assert.That(inner.DisposeCalled, Is.True);
    }

    #endregion

    #region Helper Classes

    public class TestItem
    {
        public string Value { get; set; } = string.Empty;
    }

    private class TestClientTestBase : ClientTestBase
    {
        public bool ShouldReturnNullProxy { get; set; }

        public TestClientTestBase(bool isAsync) : base(isAsync) { }

        protected internal override object CreateProxyFromClient(Type clientType, object client, IEnumerable<Castle.DynamicProxy.IInterceptor> preInterceptors)
        {
            if (ShouldReturnNullProxy)
                return null;

            // For testing purposes, just return the original client
            return client;
        }
    }

    private class MockAsyncEnumerator<T> : IAsyncEnumerator<T> where T : class
    {
        public T CurrentValue { get; set; } = default!;
        public bool MoveNextResult { get; set; }
        public bool MoveNextCalled { get; private set; }
        public bool DisposeCalled { get; private set; }

        public T Current => CurrentValue;

        public ValueTask<bool> MoveNextAsync()
        {
            MoveNextCalled = true;
            return new ValueTask<bool>(MoveNextResult);
        }

        public ValueTask DisposeAsync()
        {
            DisposeCalled = true;
            return new ValueTask();
        }
    }

    #endregion
}
