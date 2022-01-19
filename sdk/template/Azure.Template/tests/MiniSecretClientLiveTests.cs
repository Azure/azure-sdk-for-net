// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    [ClientTestFixture(
        // List all supported service versions below.
        MiniSecretClientOptions.ServiceVersion.V7_0
    )]
    public class MiniSecretClientLiveTests: RecordedTestBase<MiniSecretClientTestEnvironment>
    {
        private readonly MiniSecretClientOptions.ServiceVersion _serviceVersion;

        public MiniSecretClientLiveTests(bool isAsync, MiniSecretClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, null /* RecordedTestMode.Record /* delete "null /* " to re-record */)
        {
            _serviceVersion = serviceVersion;
        }

        private MiniSecretClient CreateClient()
        {
            return InstrumentClient(new MiniSecretClient(
                new Uri(TestEnvironment.KeyVaultUri),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MiniSecretClientOptions(_serviceVersion))
            ));
        }

        [RecordedTest]
        public async Task CanGetSecret()
        {
            var client = CreateClient();

            var secret = await client.GetSecretAsync("TestSecret");

            Assert.AreEqual(TestEnvironment.KeyVaultSecret, secret.Value.Value);
        }
    }
}
