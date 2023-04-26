// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Dynamic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class DynamicJsonSamples
    {
        [Test]
        public async Task GetDynamicJson()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJson
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);
            #endregion
        }

        [Test]
        public async Task GetDynamicJsonProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonProperty
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);
            string name = widget.Name;
            #endregion
        }

        [Test]
        public async Task GetDynamicJsonOptionalProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonOptionalProperty
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);

            // Check whether optional property is present
            if (widget.Properties != null)
            {
                string color = widget.Properties.Color;
            }
            #endregion
        }

        [Test]
        public async Task EnumerateDynamicJsonObject()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreEnumerateDynamicJsonObject
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);

#if !SNIPPET
            widget.Properties = new
            {
                color = "blue",
                size = "small"
            };
#endif
            foreach (dynamic property in widget.Properties)
            {
                UpdateWidget(property.Name, property.Value);
            }

            void UpdateWidget(string name, string value)
            {
                Console.WriteLine($"Widget has property {name}='{value}'.");
            }
            #endregion
        }

        [Test]
        public async Task SetWidgetAnonymousType()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripAnonymousType
            Response response = client.GetWidget("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);

            RequestContent update = RequestContent.Create(
                new
                {
                    Id = (string)widget.Id,
                    Name = "New Name"

                    // A forgotten field may be deleted!
                }
            );
            await client.SetWidgetAsync((string)widget.Id, update);
            #endregion
        }

        [Test]
        public async Task SetWidgetDynamicJson()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripDynamicJson
            Response response = client.GetWidget("123");
            dynamic widget = response.Content.ToDynamicFromJson(DynamicJsonOptions.AzureDefault);

            widget.Name = "New Name";

            await client.SetWidgetAsync((string)widget.Id, RequestContent.Create(widget));
            #endregion
        }

        private WidgetsClient GetMockClient()
        {
            string initial = @"{ ""Id"" : ""123"", ""Name"" : ""Widget"" }";
            string updated = @"{ ""Id"" : ""123"", ""Name"" : ""New Name"" }";

            WidgetsClientOptions options = new WidgetsClientOptions()
            {
                Transport = new MockTransport(
                    new MockResponse(200).SetContent(initial),
                    new MockResponse(200).SetContent(updated))
            };
            return new WidgetsClient(new Uri("https://example.azure.com"), new MockCredential(), options);
        }
    }
}
