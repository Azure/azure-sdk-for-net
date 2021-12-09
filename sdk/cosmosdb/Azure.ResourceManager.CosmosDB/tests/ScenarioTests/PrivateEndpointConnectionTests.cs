// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
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
        private DatabaseAccount _databaseAccount;

        public PrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        protected PrivateEndpointConnectionCollection PrivateEndpointConnectionCollection { get => _databaseAccount.GetPrivateEndpointConnections(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            if (_databaseAccountIdentifier != null)
            {
                ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).Delete();
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            // need to overwrite with the resource group fetched by ArmClient, otherwise it won't be recorded
            _resourceGroup = await ArmClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var connection in privateEndpointConnections)
            {
                await connection.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task PrivateEndpointConnectionCreateAndUpdate()
        {
            // ID and name of source private endpoint connection is different from the private connection returned by service
            var privateEndpoint = await CreatePrivateEndpoint();

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            var privateEndpointConnection = privateEndpointConnections[0];
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual("Pending", privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Status);

            _ = await PrivateEndpointConnectionCollection.CreateOrUpdate(privateEndpointConnection.Data.Name, new PrivateEndpointConnectionData() {
                PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionStateProperty()
                {
                    Status = "Approved",
                    Description = "Approved by test",
                }
            }).WaitForCompletionAsync();
            privateEndpoint= await privateEndpoint.GetAsync();
            privateEndpointConnection = await PrivateEndpointConnectionCollection.GetAsync(privateEndpointConnection.Data.Name);
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnection);
            Assert.AreEqual("Approved", privateEndpointConnection.Data.PrivateLinkServiceConnectionState.Status);
        }

        [Test]
        [RecordedTest]
        public async Task PrivateEndpointConnectionList()
        {
            var privateEndpoint = await CreatePrivateEndpoint();
            Assert.That(privateEndpoint.Data.ManualPrivateLinkServiceConnections, Has.Count.EqualTo(1));

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(privateEndpointConnections, Has.Count.EqualTo(1));
            VerifyPrivateEndpointConnections(privateEndpoint.Data.ManualPrivateLinkServiceConnections[0], privateEndpointConnections[0]);
        }

        [Test]
        [RecordedTest]
        public async Task PrivateEndpointConnectionDelete()
        {
            await CreatePrivateEndpoint();

            var privateEndpointConnections = await PrivateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            PrivateEndpointConnection privateEndpointConnection = await PrivateEndpointConnectionCollection.GetIfExistsAsync(privateEndpointConnections[0].Data.Name);
            Assert.IsNotNull(privateEndpointConnection);

            await privateEndpointConnection.DeleteAsync();
            privateEndpointConnection = await PrivateEndpointConnectionCollection.GetIfExistsAsync(privateEndpointConnection.Data.Name);
            Assert.Null(privateEndpointConnection);
        }

        protected async Task<PrivateEndpoint> CreatePrivateEndpoint()
        {
            var vnetName = Recording.GenerateAssetName("vnet-");
            var vnet = new VirtualNetworkData()
            {
                Location = Resources.Models.Location.WestUS,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() {
                    Name = "default",
                    AddressPrefix = "10.0.1.0/24",
                    PrivateEndpointNetworkPolicies = VirtualNetworkPrivateEndpointNetworkPolicies.Disabled
                }}
            };
            VirtualNetwork virtualNetwork =  await _resourceGroup.GetVirtualNetworks().CreateOrUpdate(vnetName, vnet).WaitForCompletionAsync();

            var name = Recording.GenerateAssetName("pe-");
            var privateEndpointData = new PrivateEndpointData
            {
                Location = Resources.Models.Location.WestUS,
                Subnet = virtualNetwork.Data.Subnets[0],
                ManualPrivateLinkServiceConnections = {
                    new PrivateLinkServiceConnection
                    {
                        Name = Recording.GenerateAssetName("pec"),
                        // TODO: externalize or create the service on-demand, like virtual network
                        //PrivateLinkServiceId = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{resourceGroup.Data.Name}/providers/Microsoft.Storage/storageAccounts/{storageAccount.Name}",
                        PrivateLinkServiceId = _databaseAccountIdentifier,

                        RequestMessage = "SDK test",
                        GroupIds = { "MongoDB" }
                    }
                },
            };

            return await _resourceGroup.GetPrivateEndpoints().CreateOrUpdate(name, privateEndpointData).WaitForCompletionAsync();
        }

        private void VerifyPrivateEndpointConnections(PrivateLinkServiceConnection expectedValue, PrivateEndpointConnection actualValue)
        {
            // Services will give diffferent ids and names for the incoming private endpoint connections, so comparing them is meaningless
            //Assert.AreEqual(expectedValue.Id, actualValue.Id);
            //Assert.AreEqual(expectedValue.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.PrivateLinkServiceConnectionState.Status, actualValue.Data.PrivateLinkServiceConnectionState.Status);
            Assert.AreEqual(expectedValue.PrivateLinkServiceConnectionState.Description, actualValue.Data.PrivateLinkServiceConnectionState.Description);
            Assert.AreEqual(expectedValue.PrivateLinkServiceConnectionState.ActionsRequired, actualValue.Data.PrivateLinkServiceConnectionState.ActionsRequired);
        }
    }
}
