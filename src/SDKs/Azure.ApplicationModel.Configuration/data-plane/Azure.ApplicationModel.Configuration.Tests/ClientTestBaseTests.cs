// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public class ClientTestBaseTests : ClientTestBase<ClientTestBaseTests.TestClient>
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
    }
}
