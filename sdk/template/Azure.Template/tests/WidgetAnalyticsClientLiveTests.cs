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
    public class WidgetAnalyticsClientLiveTests : RecordedTestBase<TemplateClientTestEnvironment>
    {
        public WidgetAnalyticsClientLiveTests(bool isAsync)
            // Delete null and the opening comment to re-record, or change to debug live tests.
            // You can also change eng/nunit.runsettings to set the TestMode parameter.
            // See https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core.TestFramework#test-settings.
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private WidgetAnalyticsClient CreateClient()
        {
            return InstrumentClient(new WidgetAnalyticsClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                InstrumentClientOptions(new WidgetAnalyticsClientOptions())
            ));
        }

        [RecordedTest]
        [Ignore("Widget Analytics service not available for live testing")]
        public async Task GetWidgetsTest()
        {
            WidgetAnalyticsClient client = CreateClient();
            AzureWidgets widgetsClient = client.GetAzureWidgetsClient();

            var widgets = widgetsClient.GetWidgetsAsync();
            await foreach (var widget in widgets)
            {
                Assert.IsNotNull(widget);
            }
        }
    }
}
