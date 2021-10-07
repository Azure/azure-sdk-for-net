// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class MiniSecretClientLiveTests: RecordedTestBase<MiniSecretClientTestEnvironment>
    {
        public MiniSecretClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private MiniSecretClient CreateClient()
        {
            return InstrumentClient(new MiniSecretClient(
                new Uri(TestEnvironment.KeyVaultUri),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MiniSecretClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanGetSecret()
        {
            var client = CreateClient();

            var secret = await client.GetSecretAsync("TestSecret");

            Assert.AreEqual("Very secret value", secret.Value.Value);
        }
    }
}
