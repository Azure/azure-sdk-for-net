// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotOperations.Models;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class AkriConnectorTemplateTests : IotOperationsManagementClientBase
    {
        public AkriConnectorTemplateTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
                await InitializeClients();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAkriConnectorTemplates()
        {
            // List AkriConnectorTemplates by InstanceResource
            var templateCollection = await GetAkriConnectorTemplateResourceCollectionAsync(ResourceGroup);
            var templates = await templateCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(templates);

            // Generate a unique name for the template
            string akriConnectorTemplateName = Recording.GenerateAssetName("akri-template-");

            var newTemplateData = new AkriConnectorTemplateResourceData
            {
                ExtendedLocation = new IotOperationsExtendedLocation
                {
                    Name = $"/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/{ResourceGroup}/providers/Microsoft.ExtendedLocation/customLocations/{CustomLocationName}",
                    Type = "CustomLocation"
                },
                Properties = new AkriConnectorTemplateProperties(
                    new AkriConnectorTemplateHelmConfiguration(
                        new AkriConnectorTemplateHelmConfigurationSettings(
                            "my-install",
                            "my-repo",
                            "1.0.0"
                        )
                    ),
                    new AkriConnectorTemplateDeviceInboundEndpointType[]
                    {
                        new AkriConnectorTemplateDeviceInboundEndpointType("Microsoft.Rest")
                        {
                            Version = "0.0.1"
                        }
                    })
                {
                    AioMetadata = new AkriConnectorTemplateAioMetadata
                    {
                        AioMinVersion = "1.2.0",
                        AioMaxVersion = "1.4.0"
                    },
                    MqttConnectionConfiguration = new AkriConnectorsMqttConnectionConfiguration
                    {
                        Authentication = new AkriConnectorsServiceAccountAuthentication(
                            new AkriConnectorsServiceAccountTokenSettings("MQ-SAT")
                        ),
                        Host = "aio-broker:18883",
                        Protocol = AkriConnectorsMqttProtocolType.Mqtt,
                        KeepAliveSeconds = 10,
                        MaxInflightMessages = 10,
                        SessionExpirySeconds = 60,
                        Tls = new IotOperationsTlsProperties
                        {
                            Mode = IotOperationsOperationalMode.Enabled,
                            TrustedCaCertificateConfigMapRef = "azure-iot-operations-aio-ca-trust-bundle"
                        }
                    }
                    // No Diagnostics or LogsLevel set
                }
            };

            // Create or Update AkriConnectorTemplate
            var resp = await templateCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                akriConnectorTemplateName,
                newTemplateData
            );

            // Get the created template
            var templateResource = await templateCollection.GetAsync(akriConnectorTemplateName);
            Assert.IsNotNull(templateResource);
            Assert.IsNotNull(templateResource.Value.Data);
            Assert.AreEqual(templateResource.Value.Data.Name, akriConnectorTemplateName);

            // Delete AkriConnectorTemplate
            await resp.Value.DeleteAsync(WaitUntil.Completed);

            // Verify AkriConnectorTemplate is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await resp.Value.GetAsync()
            );
        }

        private AkriConnectorTemplateResourceData CreateAkriConnectorTemplateResourceData(
            AkriConnectorTemplateResource templateResource
        )
        {
            return new AkriConnectorTemplateResourceData
            {
                ExtendedLocation = templateResource.Data.ExtendedLocation,
                Properties = templateResource.Data.Properties
            };
        }
    }
}
