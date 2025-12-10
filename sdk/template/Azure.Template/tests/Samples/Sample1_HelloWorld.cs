// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Template
using Azure.Identity;
#endregion
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class WidgetAnalyticsSamples : SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        [Ignore("Widget Analytics service not available for live testing")]
        public void GetWidgets()
        {
            #region Snippet:Azure_Template_GetWidgets
#if SNIPPET
            string endpoint = "https://your-service-endpoint";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new WidgetAnalyticsClient(new Uri(endpoint), credential);
            AzureWidgets widgetsClient = client.GetAzureWidgetsClient();

            // List all widgets
            foreach (WidgetSuite widget in widgetsClient.GetWidgets())
            {
                Console.WriteLine($"Widget: {widget.ManufacturerId}");
            }
            #endregion
        }
    }
}
