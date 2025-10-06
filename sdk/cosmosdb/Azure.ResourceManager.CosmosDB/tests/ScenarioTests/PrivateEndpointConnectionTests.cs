// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class PrivateEndpointConnectionTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        public PrivateEndpointConnectionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        protected CosmosDBPrivateEndpointConnectionCollection PrivateEndpointConnectionCollection => _databaseAccount.GetCosmosDBPrivateEndpointConnections();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_databaseAccountIdentifier != null)
                {
                    await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            // need to overwrite with the resource group fetched by ArmClient, otherwise it won't be recorded
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
                foreach (var connection in privateEndpointConnections)
                {
                    await connection.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [RecordedTest]
        public async Task PrivateEndpointConnectionCreateAndUpdate()
        {
            // ID and name of source private endpoint connection is different from the private connection returned by service
            var privateEndpoint = await CreatePrivateEndpoint();

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            var privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual("Pending", privateEndpointConnection.Data.ConnectionState.Status);

            _ = await PrivateEndpointConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, privateEndpointConnection.Data.Name, new CosmosDBPrivateEndpointConnectionData()
            {
                ConnectionState = new CosmosDBPrivateLinkServiceConnectionStateProperty()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            });
            privateEndpoint= await privateEndpoint.GetAsync();
            privateEndpointConnection = await PrivateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual("Approved", privateEndpointConnection.Data.ConnectionState.Status);
        }

        [RecordedTest]
        public async Task PrivateEndpointConnectionList()
        {
            var privateEndpoint = await CreatePrivateEndpoint();
            Assert.That(privateEndpoint.Data.ManualPrivateLinkServiceConnections, Has.Count.EqualTo(1));

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateEndpointConnections, Has.Count.EqualTo(1));
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }

        [RecordedTest]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            var name = privateEndpointConnections[0].Data.Name;
            Assert.IsTrue(await PrivateEndpointConnectionCollection.ExistsAsync(name));
            var id = PrivateEndpointConnectionCollection.Id;
            id = CosmosDBPrivateEndpointConnectionResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, name);
            var privateEndpointConnection = this.ArmClient.GetCosmosDBPrivateEndpointConnectionResource(id);

            await privateEndpointConnection.DeleteAsync(WaitUntil.Completed);
            bool exists = await PrivateEndpointConnectionCollection.ExistsAsync(name);
            Assert.IsFalse(exists);
        }

        protected async Task<PrivateEndpointResource> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var name = Recording.GenerateAssetName("pe-");
            var pecName = Recording.GenerateAssetName("pec");
            var vnet = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS,
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled
                }}
            };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.DhcpOptionsDnsServers.Add("10.1.1.1");
            vnet.DhcpOptionsDnsServers.Add("10.1.2.4");
            ResourceIdentifier subnetID = await GetSubnetId(vnetName, vnet);

            var privateEndpointData = new PrivateEndpointData
            {
                Location = AzureLocation.WestUS,
                Subnet = new SubnetData() { Id = subnetID },
                ManualPrivateLinkServiceConnections = {
                    new NetworkPrivateLinkServiceConnection
                    {
                        Name = pecName,
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _databaseAccountIdentifier,

                        RequestMessage = "SDK test",
                        GroupIds = { "MongoDB" }
                    }
                },
            };

            return (await _resourceGroup.GetPrivateEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, name, privateEndpointData)).Value;
        }

        private void VerifyPrivateEndpointConnections(NetworkPrivateLinkServiceConnection expectedValue, CosmosDBPrivateEndpointConnectionResource actualValue)
        {
            // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
            //Assert.AreEqual(expectedValue.Id, actualValue.Id);
            //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.ConnectionState.Status, actualValue.Data.ConnectionState.Status);
            Assert.AreEqual(expectedValue.ConnectionState.Description, actualValue.Data.ConnectionState.Description);
            Assert.AreEqual(expectedValue.ConnectionState.ActionsRequired, actualValue.Data.ConnectionState.ActionsRequired);
        }
    }
}
