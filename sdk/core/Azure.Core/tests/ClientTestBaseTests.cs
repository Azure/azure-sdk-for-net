// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientTestBaseTests : ClientTestBase
    {
        public ClientTestBaseTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [Test]
        public void AllowsUsingSyncMethodsWithoutAsyncAlternative()
        {
            TestClient client = InstrumentClient(new TestClient());
            var result = client.Method2();

            Assert.AreEqual("Hello", result);
        }

        [Test]
        public async Task CallsCorrectMethodBasedOnCtorArgument()
        {
            TestClient client = InstrumentClient(new TestClient());
            var result = await client.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public async Task WorksWithCancellationToken()
        {
            TestClient client = InstrumentClient(new TestClient());
            var result = await client.MethodAsync(123, new CancellationTokenSource().Token);

            Assert.AreEqual(IsAsync ? "Async 123 True" : "Sync 123 True", result);
        }

        [Test]
        public void ThrowsForInvalidClientTypes()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => InstrumentClient(new InvalidTestClient()));
            Assert.AreEqual("Client type contains public non-virtual async method MethodAsync", exception.Message);
        }

        [Test]
        public void ThrowsForSyncCallsInAsyncContext()
        {
            if (IsAsync)
            {
                TestClient client = InstrumentClient(new TestClient());
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => client.Method(123));
                Assert.AreEqual("Async method call expected for Method", exception.Message);
            }
        }

        [Test]
        public void ThrowsWhenSyncMethodIsNotAvailable()
        {
            if (!IsAsync)
            {
                TestClient client = InstrumentClient(new TestClient());
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => client.NoAlternativeAsync(123));
                Assert.AreEqual("Unable to find a method with name NoAlternative and System.Int32,System.Threading.CancellationToken parameters." +
                                " Make sure both methods have the same signature including the cancellationToken parameter", exception.Message);
            }
        }

        /// <summary>
        /// Ensure we can resolve sync/async variants of a method that only
        /// varies based on generic type parameters.
        /// </summary>
        [Test]
        public async Task ResolvesCustomUserSchemaPattern()
        {
            TestClient client = InstrumentClient(new TestClient());
            Response<string> staticData = await client.GetDataAsync<string>();
            Response<object> dynamicData = await client.GetDataAsync();
            if (IsAsync)
            {
                StringAssert.StartsWith("async", staticData.GetRawResponse().ReasonPhrase);
                StringAssert.StartsWith("async", dynamicData.GetRawResponse().ReasonPhrase);
            }
            else
            {
                StringAssert.StartsWith("sync", staticData.GetRawResponse().ReasonPhrase);
                StringAssert.StartsWith("sync", dynamicData.GetRawResponse().ReasonPhrase);
            }
        }

        public class TestClient
        {
            public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
            {
                return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
            }

            public virtual Task<string> NoAlternativeAsync(int i, CancellationToken cancellationToken = default)
            {
                return Task.FromResult("I don't have sync alternative");
            }

            public virtual string Method(int i, CancellationToken cancellationToken = default)
            {
                return "Sync " + i + " " + cancellationToken.CanBeCanceled;
            }

            public virtual string Method2()
            {
                return "Hello";
            }

            // These four follow the new pattern for custom users schemas
            public virtual Task<Response<T>> GetDataAsync<T>() =>
                Task.FromResult(Response.FromValue(default(T), new MockResponse(200, "async - static")));
            public virtual Response<T> GetData<T>() =>
                Response.FromValue(default(T), new MockResponse(200, "sync - static"));
            public virtual Task<Response<object>> GetDataAsync() =>
                Task.FromResult(Response.FromValue((object)null, new MockResponse(200, "async - dynamic")));
            public virtual Response<object> GetData() =>
                Response.FromValue((object)null, new MockResponse(200, "sync - dynamic"));
        }

        public class InvalidTestClient
        {
            public Task<string> MethodAsync(int i)
            {
                return Task.FromResult("Async " + i);
            }

            public virtual string Method(int i)
            {
                return "Sync " + i;
            }
        }
    }
}
