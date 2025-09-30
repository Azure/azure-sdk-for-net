// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Template.Models;

namespace Azure.Template.Tests
{
    // When necessary, use the [ClientTestFixture] to test multiple versions.
    // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#support-multi-service-version-testing.
    public class TemplateClientLiveTests: RecordedTestBase<TemplateClientTestEnvironment>
    {
        public TemplateClientLiveTests(bool isAsync)
            // Delete null and the opening comment to re-record, or change to debug live tests.
            // You can also change eng/nunit.runsettings to set the TestMode parameter.
            // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#test-settings.
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private TemplateClient CreateClient()
        {
            return InstrumentClient(new TemplateClient(
                TestEnvironment.KeyVaultUri,
                TestEnvironment.Credential,
                InstrumentClientOptions(new TemplateClientOptions())
            ));
        }

        [RecordedTest]
        public async Task CanGetSecret()
        {
            TemplateClient client = CreateClient();

            Response<SecretBundle> secret = await client.GetSecretValueAsync("TestSecret");

            Assert.AreEqual("Very secret value", secret.Value.Value);
        }
    }
}
