// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.AppConfiguration.Models;

using NUnit.Framework;

using Sku = Azure.ResourceManager.AppConfiguration.Models.Sku;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public class AppConfigurationTest : AppConfigurationClientBase
    {
        public AppConfigurationTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task AppConfigurationListKeyValues()
        {
            var resourceGroup = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AzureLocation, resourceGroup);
            //create configuration
            var configurationStoreName = Recording.GenerateAssetName("configuration");
            var configurationCreateResponse = await ConfigurationStoresOperations.StartCreateAsync(resourceGroup, configurationStoreName,
                                              new ConfigurationStore("westus",
                                                  new Sku("Standard")
                                                  ));
            var configCreateResult = (await WaitForCompletionAsync(configurationCreateResponse)).Value;
            Assert.IsNotNull(configCreateResult);
            Assert.AreEqual(configCreateResult.ProvisioningState.ToString(), "Succeeded");
            //list configuration
            var configListResponse = ConfigurationStoresOperations.ListKeysAsync(resourceGroup, configurationStoreName);
            var conListResult = await configListResponse.ToEnumerableAsync();
            Assert.True(conListResult.Count >= 1);
            //# ConfigurationStoresListKeys[post]
            var configRegenerateResponse = await ConfigurationStoresOperations.RegenerateKeyAsync(resourceGroup, configurationStoreName, new RegenerateKeyParameters() { Id = conListResult.First().Id });
            Assert.IsNotNull(configRegenerateResponse.Value);
            //TODO need to use data sdk to create key value
            //create Key-Value
            //var listKeyValueResponse = await ConfigurationStoresOperations.ListKeyValueAsync(resourceGroup, configurationStoreName,new ListKeyValueParameters(Key));
            //Assert.IsNotNull(listKeyValueResponse);
        }

        [Test]
        public async Task AppConfiguration()
        {
            string ServiceName = Recording.GenerateAssetName("myapimrndxyz");
            string VnetName = Recording.GenerateAssetName("vnetname");
            string SubnetName = Recording.GenerateAssetName("subnetname");
            string EndpointName = Recording.GenerateAssetName("endpointxyz");
            string configurationStoreName = Recording.GenerateAssetName("configuration");
            string privateEndpointConnectionName = Recording.GenerateAssetName("privateendpoint");
            var resourceGroupName = Recording.GenerateAssetName(ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, AzureLocation, resourceGroupName);

            var configurationCreateResponse = await ConfigurationStoresOperations.StartCreateAsync(resourceGroupName, configurationStoreName, new ConfigurationStore("westus", new Sku("Standard")));
            var configurationCreateResult = await WaitForCompletionAsync(configurationCreateResponse);
            Assert.IsNotNull(configurationCreateResult.Value);
            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = "eastus",
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new Subnet() { Name = SubnetName, AddressPrefix = "10.0.0.0/24", PrivateEndpointNetworkPolicies = "Disabled" } }
            };
            var putVnetResponseOperation = await WaitForCompletionAsync(await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, VnetName, vnet));
            Assert.IsNotNull(putVnetResponseOperation.Value);
            var setPrivateEndpointResponse = await WaitForCompletionAsync(await PrivateEndpointsOperations.StartCreateOrUpdateAsync(resourceGroupName, EndpointName,
                new ResourceManager.Network.Models.PrivateEndpoint()
                {
                    Location = "eastus",
                    PrivateLinkServiceConnections = { new PrivateLinkServiceConnection()
                        {
                            Name ="myconnection",
                            PrivateLinkServiceId = configurationCreateResult.Value.Id,
                            GroupIds = {"configurationStores"},
                            RequestMessage = "Please approve my connection",
                        }
                    },
                    Subnet = new Subnet() { Id = "/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/virtualNetworks/" + VnetName + "/subnets/" + SubnetName }
                }));
            //get Configuration
            var configurationGetResult = (await ConfigurationStoresOperations.GetAsync(resourceGroupName, configurationStoreName)).Value;
            Assert.IsNotNull(configurationGetResult);
            privateEndpointConnectionName = configurationGetResult.PrivateEndpointConnections[0].Name;
            var privateConnectionId = configurationGetResult.PrivateEndpointConnections[0].Id;
            //Create PrivateEndpointConnection
            var createPrivateEndPointConnectionResponse = await WaitForCompletionAsync(await PrivateEndpointConnectionsOperations.StartCreateOrUpdateAsync(resourceGroupName, configurationStoreName, privateEndpointConnectionName,
                            new Models.PrivateEndpointConnection(
                                //privateConnectionId,privateEndpointConnectionName,null,null,
                                privateConnectionId, privateEndpointConnectionName, null, null,
                                new Models.PrivateEndpoint("/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.Network/privateEndpoints/" + EndpointName),
                                new Models.PrivateLinkServiceConnectionState(Models.ConnectionStatus.Approved, "Auto-Approved", null)
                                )));
            Assert.IsNotNull(createPrivateEndPointConnectionResponse);
            var getPrivateEndPointConnectionResponse = await PrivateEndpointConnectionsOperations.GetAsync(resourceGroupName, configurationStoreName, privateEndpointConnectionName);
            Assert.IsNotNull(getPrivateEndPointConnectionResponse);

            var listByConfigurationResult = PrivateLinkResourcesOperations.ListByConfigurationStoreAsync(resourceGroupName, configurationStoreName);
            var listByConfigurationRes = await listByConfigurationResult.ToEnumerableAsync();
            var privateLinkResourceName = listByConfigurationRes.First().Name;

            var privatelinkresourcegetResult = await PrivateLinkResourcesOperations.GetAsync(resourceGroupName, configurationStoreName, privateLinkResourceName);
            Assert.IsNotNull(privatelinkresourcegetResult.Value);
            var listByConfigurationStoreResult = PrivateEndpointConnectionsOperations.ListByConfigurationStoreAsync(resourceGroupName, configurationStoreName);
            var listByConfigurationStoreResponse = await listByConfigurationStoreResult.ToEnumerableAsync();
            Assert.IsTrue(listByConfigurationStoreResponse.Count() >= 1);
            // get PrivateEndpointConnectionList
            var ConfigurationStoreListResponse = await PrivateLinkResourcesOperations.ListByConfigurationStoreAsync(resourceGroupName, configurationStoreName).ToEnumerableAsync();
            privateLinkResourceName = ConfigurationStoreListResponse.First().Name;

            //get privatelinkResource
            var GetPrivatelinkResponse = await PrivateLinkResourcesOperations.GetAsync(resourceGroupName, configurationStoreName, privateLinkResourceName);
            Assert.IsNotNull(GetPrivatelinkResponse.Value);

            //get privatelinkResource list
            var GetPrivatelinkListResponse = await PrivateLinkResourcesOperations.ListByConfigurationStoreAsync(resourceGroupName, configurationStoreName).ToEnumerableAsync();
            Assert.IsTrue(GetPrivatelinkListResponse.Count >= 1);

            // operation list test
            var operationListResult = await Operations.ListAsync().ToEnumerableAsync();

            Assert.IsTrue(operationListResult.Count >= 1);
            // ConfigurationStoresOperations list by resourcegroup test

            var configurationStoreListByResourceGroupResult = await ConfigurationStoresOperations.ListByResourceGroupAsync(resourceGroupName).ToEnumerableAsync();
            Assert.IsTrue(configurationStoreListByResourceGroupResult.Count >= 1);

            //ConfigurationStoresOperations list by subscription test
            var configurationStoresListResult = await ConfigurationStoresOperations.ListAsync().ToEnumerableAsync();
            Assert.IsTrue(configurationStoresListResult.Count >= 1);

            //update ConfigurationStores_Update
            var configurationStoresBeginUpdateResult = await WaitForCompletionAsync(await ConfigurationStoresOperations.StartUpdateAsync(resourceGroupName, configurationStoreName, new ConfigurationStoreUpdateParameters()
            {
                Tags = { { "category", "Marketing" } },
                Sku = new Sku("Standard")
            }));
            Assert.AreEqual(configurationStoresBeginUpdateResult.Value.ProvisioningState.ToString(), "Succeeded");
            // ConfigurationStores CheckNameNotAvailable
            var checkNameAvailabilityResponse = await Operations.CheckNameAvailabilityAsync(new CheckNameAvailabilityParameters("contoso", "Microsoft.AppConfiguration/configurationStores"));
            Assert.IsNotNull(checkNameAvailabilityResponse.Value);
            //PrivateEndpointConnections Delete
            var deletePrivateEndpointConnectionResponse = await WaitForCompletionAsync(await PrivateEndpointConnectionsOperations.StartDeleteAsync(resourceGroupName, configurationStoreName, privateEndpointConnectionName));
            Assert.IsNotNull(deletePrivateEndpointConnectionResponse.Value);
            //ConfigurationStores Delete
            var deleteConfigurationStores = await WaitForCompletionAsync(await ConfigurationStoresOperations.StartDeleteAsync(resourceGroupName, configurationStoreName));
            Assert.IsNotNull(deleteConfigurationStores.Value);
        }
    }
}
