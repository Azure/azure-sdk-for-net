// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryPrivateEndpointConnectionTests : DataFactoryManagementTestBase
    {
        public DataFactoryPrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("Must be manually operate.Error: Private Endpoint connection is requesting a status change for 'Approved', while current status is: 'Approved'.")]
        public async Task CreateOrUpdate()
        {
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var resourceGroup = await CreateResourceGroup(subscription, "DataFactory-RG-", AzureLocation.WestUS2);
            var dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);

            string connectionName = "DataFactory-5673.860b8eaf-a2d6-4870-96c3-784cfff79b42";
            DataFactoryPrivateEndpointConnectionCreateOrUpdateContent data = new DataFactoryPrivateEndpointConnectionCreateOrUpdateContent()
            {
                Properties = new PrivateLinkConnectionApprovalRequest()
                {
                    PrivateEndpointId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/DataFactory-RG-7129/providers/Microsoft.Network/privateEndpoints/dafasfsdf"),
                    PrivateEndpoint = new Resources.Models.WritableSubResource()
                    {
                        Id = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/DataFactory-RG-7129/providers/Microsoft.Network/privateEndpoints/dafasfsdf"),
                    },
                    PrivateLinkServiceConnectionState = new PrivateLinkConnectionState("Approved", "Auto-Approved", "None", null),
                },
            };
            var connection = await dataFactory.GetDataFactoryPrivateEndpointConnections().CreateOrUpdateAsync(WaitUntil.Completed, connectionName, data);
            Assert.IsNotNull(connection);
        }

        [Test]
        [RecordedTest]
        [PlaybackOnly("need to create a PrivateEndpointConnection manually")]
        public async Task PrivateEndpointConnectionApiTests()
        {
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var resourceGroup = await CreateResourceGroup(subscription, "DataFactory-RG-", AzureLocation.WestUS2);
            var dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);

            // GetAll
            var list = await dataFactory.GetDataFactoryPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // Get
            string connectionName = list.FirstOrDefault().Data.Name;
            var connection = await dataFactory.GetDataFactoryPrivateEndpointConnections().GetAsync(connectionName);
            Assert.IsNotNull(connection);
            Assert.AreEqual(connectionName, connection.Value.Data.Name);

            // Exist
            bool flag = await dataFactory.GetDataFactoryPrivateEndpointConnections().ExistsAsync(connectionName);
            Assert.IsTrue(flag);

            // Delete
            await connection.Value.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryPrivateEndpointConnections().ExistsAsync(connectionName);
            Assert.IsFalse(flag);
        }
    }
}
