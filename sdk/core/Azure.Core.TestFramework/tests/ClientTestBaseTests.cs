// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
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
        public async Task CallsCorrectGenericParameterMethodBasedOnCtorArgument()
        {
            TestClient client = InstrumentClient(new TestClient());
            var result = await client.MethodGenericAsync(123);

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
        /// Validate the interceptor is ignored when we're using SyncOnly.
        /// </summary>
        [Test]
        [SyncOnly]
        public void SyncOnlyDoesNotIntercept()
        {
            TestClient client = InstrumentClient(new TestClient());
            client.Method(42);
        }

        /// <summary>
        /// Ensure we can resolve sync/async methods that only vary based on
        /// generic type parameters.
        /// </summary>
        [Test]
        public async Task CustomUserSchemaPatternResolves()
        {
            TestClient client = InstrumentClient(new TestClient());
            string responseDataPrefix = IsAsync ? "async" : "sync";
            const string arg = "genericArg";

            // Static schema
            Response<string> staticData = await client.GetDataAsync<string>();
            Assert.AreEqual($"{responseDataPrefix} - static", staticData.GetRawResponse().ReasonPhrase);

            // Static schema with generic arg
            Response<string> staticGenericData = await client.GetDataAsync<string>(arg);
            Assert.AreEqual($"{responseDataPrefix} - static {arg}", staticGenericData.GetRawResponse().ReasonPhrase);

            // Dynamic schema
            Response<object> dynamicData = await client.GetDataAsync();
            Assert.AreEqual($"{responseDataPrefix} - dynamic", dynamicData.GetRawResponse().ReasonPhrase);
        }

        /// <summary>
        /// Ensure failures in sync/async methods that only vary based on
        /// generic type parameters are thrown correctly.
        /// </summary>
        [Test]
        public async Task CustomUserSchemaPatternThrows()
        {
            TestClient client = InstrumentClient(new TestClient());
            string exceptionPrefix = IsAsync ? "async" : "sync";

            // Static schema
            try { await client.GetFailureAsync<string>(); }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual($"{exceptionPrefix} - static", ex.Message);
            }

            // Dynamic schema
            try { await client.GetFailureAsync(); }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual($"{exceptionPrefix} - dynamic", ex.Message);
            }
        }

        [Test]
        public async Task GetClientCallsAreAutoInstrumented()
        {
            TestClient client = InstrumentClient(new TestClient());

            TestClient subClient = client.GetAnotherTestClient();
            var result = await subClient.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public async Task SubClientPropertyWithoutClientSuffixIsAutoInstrumented()
        {
            TestClient client = InstrumentClient(new TestClient());

            AnotherType subClient = client.SubClientProperty;
            var result = await subClient.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public async Task SubClientWithoutClientSuffixIsAutoInstrumented()
        {
            TestClient client = InstrumentClient(new TestClient());

            AnotherType subClient = client.GetAnotherType();
            var result = await subClient.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public async Task SubClientPropertyCallsAreAutoInstrumented()
        {
            TestClient client = InstrumentClient(new TestClient());

            TestClientOperations subClient = client.SubProperty;
            var result = await subClient.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public void NonPublicSubClientPropertyCallsAreNotAutoInstrumented()
        {
            TestClient client = InstrumentClient(new TestClient());

            InternalType subClient = client.GetInternalType();
            // should not throw
            var result = subClient.Method(123);
            Assert.AreEqual("Sync 123 False", result);
        }

        [Test]
        public void CanGetUninstrumentedClient()
        {
            var testClient = new TestClient();
            TestClient client = InstrumentClient(testClient);

            Assert.AreSame(GetOriginal(client), testClient);
        }

        [Test]
        [NonParallelizable]
        public async Task TasksValidateOwnScopes()
        {
            TestDiagnostics = true;

            TestClient client = InstrumentClient(new TestClient());

            var t1 = Task.Run(async () =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    await client.MethodAAsync();
                }
            });

            var t2 = Task.Run(async () =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    await client.MethodBAsync();
                }
            });
            await Task.WhenAll(t1, t2);
        }
    }
}
