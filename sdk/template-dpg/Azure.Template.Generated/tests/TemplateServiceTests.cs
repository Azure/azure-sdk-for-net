// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Generated.Tests
{
    public class TemplateServiceTests
    {
        private readonly Uri _url = new Uri("https://example.azuretemplate.com");

        public TemplateServiceClient CreateClient(HttpPipelineTransport transport)
        {
            var options = new TemplateServiceClientOptions()
            {
                Transport = transport
            };

            return new TemplateServiceClient(_url, new MockCredential(), options);
        }

        // Add unit tests here

        [Test]
        public void GetResourceMethodTest()
        {
            var client = typeof(TemplateServiceClient);
            var method = client.GetMethod(nameof(TemplateServiceClient.GetResource));
            var parameters = method.GetParameters();

            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(string));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestContext));
            Assert.AreEqual(parameters[1].IsOptional, true);
        }

        [Test]
        public async Task GetResource()
        {
            var mockResponse = new MockResponse(200);

            Resource resource = new("TemplateResource", "123");
            mockResponse.SetContent(SerializationHelpers.Serialize(resource, SerializeResource));

            var mockTransport = new MockTransport(mockResponse);
            TemplateServiceClient client = CreateClient(mockTransport);

            Response response = await client.GetResourceAsync("123");
            using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
            string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
            string resourceId = resourceJson.RootElement.GetProperty("id").ToString();

            Assert.AreEqual("TemplateResource", resourceJson.RootElement.GetProperty("name").ToString());
            Assert.AreEqual("123", resourceJson.RootElement.GetProperty("id").ToString());
        }

        #region Helpers
        internal class Resource
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public Resource(string name, string id)
            {
                Name = name;
                Id = id;
            }
        }

        private void SerializeResource(ref Utf8JsonWriter writer, Resource resource)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("name");
            writer.WriteStringValue(resource.Name);

            writer.WritePropertyName("id");
            writer.WriteStringValue(resource.Id);

            writer.WriteEndObject();
        }
        #endregion
    }
}
