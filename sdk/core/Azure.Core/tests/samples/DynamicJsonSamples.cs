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

            #region Snippet:GetDynamicJson
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamic();
            #endregion
        }

        [Test]
        public async Task GetDynamicJsonProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:GetDynamicJsonProperty
            Response response = await client.GetWidgetAsync("123");
            dynamic widget = response.Content.ToDynamic();
            string name = widget.Name;
            #endregion
        }

        [Test]
        public async Task SetWidgetAnonymousType()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:RoundTripAnonymousType
            Response response = client.GetWidget("123");
            dynamic widget = response.Content.ToDynamic();

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

            #region Snippet:RoundTripDynamicJson
            Response response = client.GetWidget("123");
            dynamic widget = response.Content.ToDynamic();

            widget.Name = "New Name";

            // TODO: Add implicit cast to RequestContent?

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
