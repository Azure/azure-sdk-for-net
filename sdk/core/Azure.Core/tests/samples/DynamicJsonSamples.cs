// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            client.SetWidget(RequestContent.Create(widget));
            #endregion

            Assert.IsTrue(widget.name == "New Name");
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

            // JSON is `{ "values" : [1, 2, 3] }`
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
            dynamic widget = response.Content.ToDynamicFromJson();

            // JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`

            // Check whether optional property is present
            if (widget.details != null)
            {
                string color = widget.details.color;
            }
            #endregion

            Assert.IsTrue(widget.details.color == "blue");
        }

        [Test]
        public void EnumerateDynamicJsonObject()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreEnumerateDynamicJsonObject
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();

            // JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`
            foreach (dynamic property in widget.details)
            {
                PrintWidget(property.Name, property.Value);
            }

            void PrintWidget(string name, string value)
            {
                Console.WriteLine($"Widget has property {name}='{value}'.");
            }
            #endregion

            Assert.IsTrue(widget.details.color == "blue");
        }

        [Test]
        public void CastDynamicJsonToPOCO()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreCastDynamicJsonToPOCO
            Response response = client.GetWidget();
            dynamic content = response.Content.ToDynamicFromJson();

            // JSON is `{ "id" : "123", "name" : "Widget" }`
            Widget widget = (Widget)content;
            #endregion

            Assert.IsTrue(widget.Id == "123");
            Assert.IsTrue(widget.Name == "Widget");
        }

        #region Snippet:AzureCoreDynamicJsonPOCO
        public class Widget
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        #endregion

        [Test]
        public void GetPropertyWithInvalidCharacters()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicPropertyInvalidCharacters
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();
#if !SNIPPET
            widget["$id"] = "123";
#endif

            /// JSON is `{ "$id" = "123" }`
            string id = widget["$id"];
            #endregion

            Assert.IsTrue(id == "123");
        }

        [Test]
        public void SetWidgetAnonymousType()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripAnonymousType
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson();

            RequestContent update = RequestContent.Create(
                new
                {
                    id = (string)widget.id,
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
        public void SetWidgetDynamicJson()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreRoundTripDynamicJson
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
            widget.Name = "New Name";
            client.SetWidget(RequestContent.Create(widget));
            #endregion
        }

        [Test]
        public void UseDynamicDataDefaults()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreUseDynamicDataDefaults
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(DynamicDataOptions.Default);
            string id = widget.Id;
            widget.Name = "New Name";
            client.SetWidget(RequestContent.Create(widget));
            #endregion

            Assert.IsTrue(id == "123");
            Assert.IsTrue(widget.Name == "New Names");
        }

        private WidgetsClient GetMockClient()
        {
            string initial = """
                {
                    "id" : "123",
                    "name" : "Widget",
                    "details" : {
                        "color" : "blue",
                        "size" : "small"
                    }
                }
                """;
            string updated = """
                {
                    "id" : "123",
                    "name" : "New Name",
                    "details" : {
                        "color" : "blue",
                        "size" : "small"
                    }
                }
                """;

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
