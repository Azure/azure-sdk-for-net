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
            // TODO: Update this method to create your client with appropriate parameters
            // Example:
            // return InstrumentClient(new TemplateClient(
            //     TestEnvironment.Endpoint,
            //     TestEnvironment.Credential,
            //     InstrumentClientOptions(new TemplateClientOptions())
            // ));
            throw new NotImplementedException("Update CreateClient method for your generated client");
        }

        [RecordedTest]
        [Ignore("Template test - update with actual client methods")]
        public async Task ExampleTest()
        {
            // TODO: Replace this template test with actual tests for your generated client methods
            // Example:
            // TemplateClient client = CreateClient();
            // var response = await client.YourMethodAsync("parameter");
            // Assert.IsNotNull(response);
            await Task.CompletedTask;
            throw new NotImplementedException("Update this test with actual client methods");
        }
    }
}
