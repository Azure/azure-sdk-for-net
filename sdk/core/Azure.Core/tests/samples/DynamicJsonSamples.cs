// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Identity;
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

            Assert.IsTrue(widget.name == "Widget");
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
        public void GetDynamicJsonPropertyPascalCase()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonPropertyPascalCase
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            // Retrieves `name` value from JSON `{ "name" : "Widget" }`
            string name = widget.Name;
            #endregion

            Assert.IsTrue(name == "Widget");
        }

        [Test]
        public void SetDynamicJsonProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreSetDynamicJsonProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            widget.Name = "New Name";
            client.SetWidget(RequestContent.Create(widget));
            #endregion

            Assert.IsTrue(widget.Name == "New Name");
        }

        [Test]
        public void GetDynamicJsonArrayValue()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonArrayValue
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
#if !SNIPPET
            widget.Values = new int[] { 1, 2, 3 };
#endif

            // JSON is `{ "values" : [1, 2, 3] }`
            if (widget.Values.Length > 0)
            {
                int value = widget.Values[0];
            }
            #endregion

            Assert.IsTrue(widget.Values.Length > 0);
            Assert.IsTrue(widget.Values[0] == 1);
        }

        [Test]
        public void GetDynamicJsonOptionalProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreGetDynamicJsonOptionalProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`

            // Check whether optional property is present
            if (widget.Details != null)
            {
                string color = widget.Details.Color;
            }
            #endregion

            Assert.IsTrue(widget.Details.Color == "blue");
        }

        [Test]
        public void CheckPropertyNullOrAbsent()
        {
            WidgetsClient client = GetMockClient();

            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

            bool threw = false;

            #region Snippet:AzureCoreCheckPropertyNullOrAbsent
            try
            {
                double price = widget.Details["price"];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Widget details do not contain 'price'.");
#if !SNIPPET
                threw = true;
#endif
            }

            #endregion

            Assert.IsTrue(threw);
        }

        [Test]
        public void EnumerateDynamicJsonObject()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreEnumerateDynamicJsonObject
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

            // JSON is `{ "details" : { "color" : "blue", "size" : "small" } }`
            foreach (dynamic property in widget.Details)
            {
                Console.WriteLine($"Widget has property {property.Name}='{property.Value}'.");
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
            dynamic content = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

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
        public void SetPropertyWithoutCaseMappingPerProperty()
        {
            WidgetsClient client = GetMockClient();

            #region Snippet:AzureCoreSetPropertyWithoutCaseMappingPerProperty
            Response response = client.GetWidget();
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

            widget.details["IPAddress"] = "127.0.0.1";
            // JSON is `{ "details" : { "IPAddress" : "127.0.0.1" } }`
            #endregion

            Assert.IsTrue(widget.details.IPAddress == "127.0.0.1");
            Assert.IsTrue(widget.details["IPAddress"] == "127.0.0.1");
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
            dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            widget.Name = "New Name";
            client.SetWidget(RequestContent.Create(widget));
            #endregion
        }

        [Test]
        public void DisposeDynamicJson()
        {
            WidgetsClient client = GetMockClient();
            dynamic details = null;

            #region Snippet:AzureCoreDisposeDynamicJson
            Response response = client.GetLargeWidget();
            using (dynamic widget = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase))
            {
#if !SNIPPET
                details = widget.Details;
#endif
                widget.Name = "New Name";
                client.SetWidget(RequestContent.Create(widget));
            }
            #endregion

            Assert.Throws<ObjectDisposedException>(() => { _ = details.Color; });
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
