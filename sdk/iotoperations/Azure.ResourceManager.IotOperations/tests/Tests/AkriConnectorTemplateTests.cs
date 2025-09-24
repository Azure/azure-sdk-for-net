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
            var templateData = CreateAkriConnectorTemplateData();

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

        private IotOperationsAkriConnectorTemplateData CreateAkriConnectorTemplateData()
        {
            // ManagedConfiguration with ImageConfiguration (registry, tag) and bucketized allocation
            var imageSettings = new AkriConnectorTemplateRuntimeImageConfigurationSettings("aio-connectors/media-connector")
            {
                RegistrySettings = new AkriConnectorsContainerRegistry(
                    new AkriConnectorsContainerRegistrySettings("mcr.microsoft.com")
                ),
                TagDigestSettings = new AkriConnectorsTag("1.2.13"),
            };

            var managedImageConfig = new AkriConnectorTemplateRuntimeImageConfiguration(imageSettings)
            {
                Allocation = new AkriConnectorTemplateBucketizedAllocation(5),
            };

            var runtimeConfiguration = new AkriConnectorTemplateManagedConfiguration(managedImageConfig);

            // Device inbound endpoint type: Microsoft.Media with default streams config schema ref
            var mediaSchemaRefs = new AkriConnectorTemplateDeviceInboundEndpointConfigurationSchemaRefs
            {
                DefaultStreamsConfigSchemaRef = "aio-sr://${schemaRegistry.properties.namespace}/media-stream-config-schema:1",
            };

            var inboundEndpoints = new[]
            {
                new AkriConnectorTemplateDeviceInboundEndpointType("Microsoft.Media")
                {
                    ConfigurationSchemaRefs = mediaSchemaRefs
                }
            };

            // Build and return the resource data, including extended location (CustomLocation)
            return new IotOperationsAkriConnectorTemplateData
            {
                ExtendedLocation = new IotOperationsExtendedLocation(ExtendedLocation, IotOperationsExtendedLocationType.CustomLocation),
                Properties = new IotOperationsAkriConnectorTemplateProperties(
                    runtimeConfiguration: runtimeConfiguration,
                    deviceInboundEndpointTypes: inboundEndpoints
                )
            };
        }
    }
}
