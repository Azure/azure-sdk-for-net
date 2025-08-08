// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class AkriConnectorTemplateTests : IotOperationsManagementClientBase
    {
        public AkriConnectorTemplateTests(bool isAsync)
            : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAkriConnectorTemplates()
        {
            // Get AkriConnectorTemplate collection
            var templateCollection = await GetAkriConnectorTemplateResourceCollectionAsync(ResourceGroup);
            // Create AkriConnectorTemplate
            var templateData = CreateAkriConnectorTemplateResourceData();

            if (await templateCollection.ExistsAsync("sdk-test-akriconnector-template"))
            {
                 var existing = await templateCollection.GetAsync("sdk-test-akriconnector-template");
                 await existing.Value.DeleteAsync(WaitUntil.Completed);
            }
            var response = await templateCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "sdk-test-akriconnector-template",
                templateData
            );
            var createdTemplate = response.Value;

            // Assertions
            Assert.IsNotNull(createdTemplate);
            Assert.IsNotNull(createdTemplate.Data);
            Assert.IsNotNull(createdTemplate.Data.Properties);

            // Delete AkriConnectorTemplate
            await createdTemplate.DeleteAsync(WaitUntil.Completed);

            // Verify deletion
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdTemplate.GetAsync()
            );
        }

        private AkriConnectorTemplateResourceData CreateAkriConnectorTemplateResourceData()
        {
            // Step 1: Create Helm configuration settings
            var helmSettings = new AkriConnectorTemplateHelmConfigurationSettings(
                releaseName: "my-release",
                repositoryName: "my-repo",
                version: "1.0.0"
            );

            // Step 2: Add Helm chart values
            helmSettings.Values["image"] = "my-image";
            helmSettings.Values["replicaCount"] = "2";

            // Step 3: Create Helm runtime configuration
            var helmConfiguration = new AkriConnectorTemplateHelmConfiguration(helmSettings);

            // Step 4: Define device inbound endpoint types
            var inboundEndpoints = new[]
            {
                new AkriConnectorTemplateDeviceInboundEndpointType("Custom")
            };

            // Step 5: Build and return the resource data
            return new AkriConnectorTemplateResourceData
            {
                Properties = new AkriConnectorTemplateProperties(
                    runtimeConfiguration: helmConfiguration,
                    deviceInboundEndpointTypes: inboundEndpoints
                )
            };
        }
    }
}
