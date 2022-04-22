// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Generated.Tests.Samples
{
    public class TemplateServiceSamples : SamplesBase<TemplateServiceTestEnvironment>
    {
        public TemplateServiceClient GetClient()
        {
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:TemplateServiceAuthenticate
            var serviceClient = new TemplateServiceClient(new Uri(endpoint), new DefaultAzureCredential());
            #endregion

            return serviceClient;
        }

        // [Test] -- Enable the tests when you're running the samples for the service
        public async Task CreateResource()
        {
            #region Snippet:CreateResource

            var client = GetClient();
            var resource = new
            {
                name = "TemplateResource",
                id = "123",
            };
            Response response = await client.CreateAsync(RequestContent.Create(resource));
            using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
            string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
            string resourceId = resourceJson.RootElement.GetProperty("id").ToString();
            Console.WriteLine($"Name: {resourceName} \n Id: {resourceId}.");

            #endregion
        }

        // [Test] -- Enable the tests when you're running the samples for the service
        public async Task GetResource()
        {
            #region Snippet:RetrieveResource

            var client = GetClient();
            var response = await client.GetResourceAsync("123");
            using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
            string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
            string resourceId = resourceJson.RootElement.GetProperty("id").ToString();
            Console.WriteLine($"Name: {resourceName} \n Id: {resourceId}.");

            #endregion
        }

        // [Test] -- Enable the tests when you're running the samples for the service
        public async Task ListResources()
        {
            #region Snippet:ListResources

            var client = GetClient();
            AsyncPageable<BinaryData> pageable = client.GetResourcesAsync();
            await foreach (var page in pageable.AsPages())
            {
                foreach (var resourceBinaryData in page.Values)
                {
                    using JsonDocument resourceJson = JsonDocument.Parse(resourceBinaryData.ToMemory());
                    Console.WriteLine(resourceJson.RootElement.GetProperty("name").ToString());
                    Console.WriteLine(resourceJson.RootElement.GetProperty("id").ToString());
                }
            }

            #endregion
        }

        // [Test] -- Enable the tests when you're running the samples for the service
        public async Task DeleteResource()
        {
            #region Snippet:DeleteResource

            var client = GetClient();
            await client.DeleteAsync("123");

            #endregion
        }
    }
}
