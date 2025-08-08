// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure; // for RequestFailedException, WaitUntil, ArmOperation
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models; // for AkriConnector* models
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class AkriConnectorTests : IotOperationsManagementClientBase
    {
        public AkriConnectorTests(bool isAsync)
            : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [RecordedTest]
        public async Task TestAkriConnectorCrud()
        {
            // Ensure AkriConnectorTemplateName is set and exists
            AkriConnectorTemplateName = "sdk-test-akriconnector-template";
            var templateCollection = await GetAkriConnectorTemplateResourceCollectionAsync(ResourceGroup);
            if (!await templateCollection.ExistsAsync(AkriConnectorTemplateName))
            {
                // Create a minimal template compatible with ManagedConfiguration used elsewhere
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
                var templateData = new AkriConnectorTemplateResourceData
                {
                    ExtendedLocation = new IotOperationsExtendedLocation(ExtendedLocation, IotOperationsExtendedLocationType.CustomLocation),
                    Properties = new AkriConnectorTemplateProperties(runtimeConfiguration, inboundEndpoints)
                };

                await templateCollection.CreateOrUpdateAsync(WaitUntil.Completed, AkriConnectorTemplateName, templateData);
            }

            var connectorCollection = await GetAkriConnectorResourceCollectionAsync();

            // Get existing AkriConnectorResource (if any)
            AkriConnectorResource connectorResource = null;
            try
            {
                connectorResource = await connectorCollection.GetAsync("sdk-test-akriconnector");
            }
            catch (RequestFailedException)
            {}

            // Create AkriConnectorResource
            AkriConnectorResourceData connectorData = CreateAkriConnectorResourceData(connectorResource);

            ArmOperation<AkriConnectorResource> resp =
                await connectorCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-akriconnector",
                    connectorData
                );
            AkriConnectorResource createdConnector = resp.Value;

            Assert.IsNotNull(createdConnector);
            Assert.IsNotNull(createdConnector.Data);
            Assert.IsNotNull(createdConnector.Data.Properties);

            // Delete AkriConnectorResource
            await createdConnector.DeleteAsync(WaitUntil.Completed);

            // Verify AkriConnectorResource is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdConnector.GetAsync()
            );
        }

        private AkriConnectorResourceData CreateAkriConnectorResourceData(AkriConnectorResource connectorResource)
        {
            if (connectorResource != null)
            {
                return new AkriConnectorResourceData
                {
                    Properties = connectorResource.Data.Properties,
                    ExtendedLocation = connectorResource.Data.ExtendedLocation
                };
            }
            else
            {
                return new AkriConnectorResourceData
                {};
            }
        }
    }
}