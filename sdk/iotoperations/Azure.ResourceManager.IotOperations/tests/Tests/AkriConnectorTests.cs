// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class AkriConnectorTests : IotOperationsManagementClientBase
    {
        public AkriConnectorTests(bool isAsync)
            : base(isAsync) { }

        [SetUp]
        public async Task SetUp()
        {
            // Ensure AkriConnectorTemplateName is set
            AkriConnectorTemplateName = "default";
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