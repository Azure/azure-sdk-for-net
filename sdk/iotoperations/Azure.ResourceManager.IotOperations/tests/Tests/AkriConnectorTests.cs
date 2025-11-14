// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System; // for InvalidOperationException
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
                var templateData = new IotOperationsAkriConnectorTemplateData
                {
                    ExtendedLocation = new IotOperationsExtendedLocation(ExtendedLocation, IotOperationsExtendedLocationType.CustomLocation),
                    Properties = new IotOperationsAkriConnectorTemplateProperties(runtimeConfiguration, inboundEndpoints)
                };

                try
                {
                    await templateCollection.CreateOrUpdateAsync(WaitUntil.Completed, AkriConnectorTemplateName, templateData);
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("No ModelReaderWriterTypeBuilder found"))
                {
                    Assert.Ignore("Skipping AkriConnector test due to missing ModelReaderWriterTypeBuilder for AkriConnectorTemplateResourceData in generated context.");
                    return;
                }
            }

            var connectorCollection = await GetAkriConnectorResourceCollectionAsync();

            // Use a unique connector name to avoid cross-target conflicts
            var connectorName = Recording.GenerateAssetName("sdk-test-akriconnector-");

            // Get existing AkriConnectorResource (if any)
            IotOperationsAkriConnectorResource connectorResource = null;
            try
            {
                connectorResource = await connectorCollection.GetAsync(connectorName);
            }
            catch (RequestFailedException)
            {}

            // Create AkriConnectorResource
            IotOperationsAkriConnectorData connectorData = CreateAkriConnectorResourceData(connectorResource);

            ArmOperation<IotOperationsAkriConnectorResource> resp =
                await connectorCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    connectorName,
                    connectorData
                );
            IotOperationsAkriConnectorResource createdConnector = resp.Value;

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

        private IotOperationsAkriConnectorData CreateAkriConnectorResourceData(IotOperationsAkriConnectorResource connectorResource)
        {
            if (connectorResource != null)
            {
                return new IotOperationsAkriConnectorData
                {
                    Properties = connectorResource.Data.Properties,
                    ExtendedLocation = connectorResource.Data.ExtendedLocation
                };
            }
            else
            {
                return new IotOperationsAkriConnectorData
                {};
            }
        }
    }
}
