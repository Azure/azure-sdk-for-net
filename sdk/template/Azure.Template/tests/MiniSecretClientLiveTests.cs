// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    // When necessary, use the [ClientTestFixture] to test multiple versions.
    // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#support-multi-service-version-testing.
    public class MiniSecretClientLiveTests: RecordedTestBase<MiniSecretClientTestEnvironment>
    {
        public MiniSecretClientLiveTests(bool isAsync)
            // Delete null and the opening comment to re-record, or change to debug live tests.
            // You can also change eng/nunit.runsettings to set the TestMode parameter.
            // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#test-settings.
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
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
