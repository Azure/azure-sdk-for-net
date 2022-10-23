// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoPrivateEndpointConnectionTests : KustoManagementTestBase
    {
        public KustoPrivateEndpointConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task PrivateEndpointConnectionTests()
        {
            var privateEndpointCollection = ResourceGroup.GetPrivateEndpoints();
            var privateEndpointName = Recording.GenerateAssetName("sdkTestPrivateEndpoint");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = KustoTestUtils.Location,
                Subnet = new SubnetData
                {
                    Id = new ResourceIdentifier(
                        $"/subscriptions/{SubscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.Network/virtualNetworks/test-clients-vnet/subnets/default")
                },
                PrivateLinkServiceConnections =
                {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("sdkTestPrivateEndpoint"),
                        GroupIds = { "cluster" },
                        PrivateLinkServiceId = Cluster.Id,
                        RequestMessage = "SDK test"
                    }
                },
            };
            await privateEndpointCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointName,
                privateEndpointData);
            var privateEndpointConnectionCollection = Cluster.GetKustoPrivateEndpointConnections();

            await CollectionTests(
                privateEndpointName, privateEndpointData, privateEndpointData,
                null,
                privateEndpointConnectionCollection.GetAsync,
                privateEndpointConnectionCollection.GetAllAsync,
                privateEndpointConnectionCollection.ExistsAsync,
                ValidatePrivateEndpoint,
                clusterChild: true
            );
        }

        private void ValidatePrivateEndpoint(
            KustoPrivateEndpointConnectionResource privateEndpointConnection,
            string privateEndpointConnectionName,
            PrivateEndpointData privateEndpointData
        )
        {
            Assert.AreEqual(privateEndpointConnectionName, privateEndpointConnection.Data.Name);
            Assert.AreEqual(privateEndpointData.Id, privateEndpointConnection.Data.PrivateEndpointId);
        }
    }
}
