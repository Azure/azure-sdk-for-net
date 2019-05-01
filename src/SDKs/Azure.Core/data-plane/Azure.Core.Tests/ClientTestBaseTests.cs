// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            Assert.AreEqual(IsAsync ? "Async 123" : "Sync 123", result);
        }

        [Test]
        public void ThrowsForInvalidClientTypes()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => WrapClient(new InvalidTestClient()));
            Assert.AreEqual("Client type contains public non-virtual async method MethodAsync", exception.Message);
        }

        public class TestClient
        {
            public virtual Task<string> MethodAsync(int i)
            {
                return Task.FromResult("Async " + i);
            }

            public virtual string Method(int i)
            {
                return "Sync " + i;
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
