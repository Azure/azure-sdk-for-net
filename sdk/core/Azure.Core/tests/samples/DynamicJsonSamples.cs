// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class DynamicJsonSamples
    {
        [Test]
        public void GetDynamicJson()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJson
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();
            #endregion
        }

        [Test]
        public void GetDynamicJsonProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();
            string name = widget.name;
            #endregion

            Assert.IsTrue(name == "Widget");
        }

        [Test]
        public void SetDynamicJsonProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreSetDynamicJsonProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();
            widget.name = "New Name";
            #endregion

            Assert.IsTrue(widget.Name == "New Name");
        }

        [Test]
        public void GetDynamicJsonArrayValue()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonArrayValue
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();
#if !SNIPPET
            widget.values = new int[] { 1, 2, 3 };
#endif

            // JSON is "{ values = [1, 2, 3] }"
            int value = widget.values[0];
            #endregion

            Assert.IsTrue(value == 1);
        }

        [Test]
        public void GetDynamicJsonOptionalProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonOptionalProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

            // Check whether optional property is present
            if (widget.Properties != null)
            {
                string color = widget.Properties.Color;
            }
            #endregion

            Assert.IsTrue(widget.Properties == null);
        }

        [Test]
        public void EnumerateDynamicJsonObject()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreEnumerateDynamicJsonObject
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

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

            Assert.IsTrue(widget.Properties.Color == "blue");
        }

        [Test]
        public void CastDynamicJsonToPOCO()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreCastDynamicJsonToPOCO
            Response response = client.GetWidget();
            dynamic content = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
            Widget widget = (Widget)content;
            #endregion

            Assert.IsTrue(widget.Name == "Widget");
        }

        #region Snippet:AzureCoreDynamicJsonPOCO
        public class Widget
        {
            public string Name { get; set; }
        }
        #endregion

        [Test]
        public void GetPropertyWithInvalidCharacters()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicPropertyInvalidCharacters
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
#if !SNIPPET
            widget["$id"] = "foo";
#endif

            /// JSON is """{ $id = "foo" }"""
            string id = widget["$id"];
            #endregion

            Assert.IsTrue(id == "foo");
        }

        [Test]
        public void SetWidgetAnonymousType()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripAnonymousType
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

            RequestContent update = RequestContent.Create(
                new
                {
                    id = (string)widget.Id,
                    name = "New Name",
                    properties = new object[]
                    {
                        new { color = "blue" }
                    }

                    // A forgotten field may be deleted!
                }
            );
            client.SetWidget(update);
            #endregion
        }

        [Test]
        public async Task SetWidgetDynamicJson()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripDynamicJson
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);

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
