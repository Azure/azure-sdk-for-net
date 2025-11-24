// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class WidgetAnalyticsSamples : SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        [Ignore("Widget Analytics service not available for live testing")]
        public async Task GetWidgetsAsync()
        {
            #region Snippet:Azure_Template_GetWidgetsAsync
#if SNIPPET
            string endpoint = "https://your-service-endpoint";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new WidgetAnalyticsClient(new Uri(endpoint), credential);
            AzureWidgets widgetsClient = client.GetAzureWidgetsClient();

            // List all widgets asynchronously
            await foreach (WidgetSuite widget in widgetsClient.GetWidgetsAsync())
            {
                Console.WriteLine($"Widget: {widget.ManufacturerId}");
            }
            #endregion
        }
    }
}
