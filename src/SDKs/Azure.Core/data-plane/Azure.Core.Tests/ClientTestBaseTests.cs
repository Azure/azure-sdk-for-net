// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientTestBaseTests : ClientTestBase
    {
        public ClientTestBaseTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CallsCorrectMethodBasedOnCtorArgument()
        {
            var client = WrapClient(new TestClient());
            var result = await client.MethodAsync(123);

            Assert.AreEqual(IsAsync ? "Async 123 False" : "Sync 123 False", result);
        }

        [Test]
        public async Task WorksWithCancellationToken()
        {
            var client = WrapClient(new TestClient());
            var result = await client.MethodAsync(123, new CancellationTokenSource().Token );

            Assert.AreEqual(IsAsync ? "Async 123 True" : "Sync 123 True", result);
        }

        [Test]
        public void ThrowsForInvalidClientTypes()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => WrapClient(new InvalidTestClient()));
            Assert.AreEqual("Client type contains public non-virtual async method MethodAsync", exception.Message);
        }

        [Test]
        public void ThrowsForSyncCallsInAsyncContext()
        {
            if (IsAsync)
            {
                var client = WrapClient(new TestClient());
                var exception = Assert.Throws<InvalidOperationException>(() => client.Method(123));
                Assert.AreEqual("Async method call expected", exception.Message);
            }
        }

        public class TestClient
        {
            public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
            {
                return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
            }

            public virtual string Method(int i, CancellationToken cancellationToken = default)
            {
                return "Sync " + i + " " + cancellationToken.CanBeCanceled;
            }
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
