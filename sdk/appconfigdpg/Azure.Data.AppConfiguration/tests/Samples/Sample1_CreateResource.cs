// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests.Samples
{
    public partial class AppConfigurationSamples : SamplesBase<AppConfigurationClientTestEnvironment>
    {
        // Get service Client.
        // public AppConfigurationServiceClient GetClient()
        // {
        //     var endpoint = TestEnvironment.Endpoint;

        //     #region Snippet:AppConfigurationServiceAuthenticate
        //     var serviceClient = new AppConfigurationServiceClient(new Uri(endpoint), new DefaultAzureCredential());
        //     #endregion

        //     return serviceClient;
        // }

        // [Test] -- Enable the tests when you're running the samples for the service
        // [Test]
        // public async Task CreateResource()
        // {
        //     #region Snippet:CreateResource

        //     var client = GetClient();
        //     var resource = new
        //     {
        //         name = "AppConfigurationResource",
        //         id = "123",
        //     };
        //     Response response = await client.CreateAsync(RequestContent.Create(resource));
        //     using JsonDocument resourceJson = JsonDocument.Parse(response.Content.ToMemory());
        //     string resourceName = resourceJson.RootElement.GetProperty("name").ToString();
        //     string resourceId = resourceJson.RootElement.GetProperty("id").ToString();
        //     Console.WriteLine($"Name: {resourceName} \n Id: {resourceId}.");

        //     #endregion
        // }
    }
}
