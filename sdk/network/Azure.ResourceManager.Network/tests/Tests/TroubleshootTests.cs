// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
//using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
//using Sku = Azure.ResourceManager.Storage.Models.Sku;

namespace Azure.ResourceManager.Network.Tests
{
    public class TroubleshootTests : NetworkServiceClientTestBase
    {
        public TroubleshootTests(bool isAsync) : base(isAsync)
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

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task TroubleshootApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = CreateResourceGroup(resourceGroupName, location);

            // CreateVirtualNetworkGateway API
            // Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);

            //Prerequisite:-Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<SubnetResource> getSubnetResponse = await GetVirtualNetworkCollection(resourceGroupName).Get(vnetName).Value.GetSubnets().GetAsync(subnetName);

            // CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = null,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource() { Id = nic1publicIp.Id }, Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Basic, Tier = VirtualNetworkGatewaySkuTier.Basic }
            };

            var virtualNetworkGatewayCollection = GetVirtualNetworkGatewayCollection(resourceGroupName);
            var putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayCollection.CreateOrUpdateAsync(true, virtualNetworkGatewayName, virtualNetworkGateway);
            await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();;
            // GetVirtualNetworkGateway API
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse =
                await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, resourceGroupName, networkWatcherName, properties);

            //Create storage
            //string storageName = Recording.GenerateAssetName("azsmnet");
            //var storageParameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardLRS), Kind.Storage, location);

            //Operation<StorageAccountResource> accountOperation = await StorageManagementClient.StorageAccounts.CreateAsync(resourceGroupName, storageName, storageParameters);
            //Response<StorageAccountResource> account = await accountOperation.WaitForCompletionAsync();;
            //TroubleshootingParameters parameters = new TroubleshootingParameters(getVirtualNetworkGatewayResponse.Value.Id, account.Value.Id, "https://nwtestdbdzq4xsvskrei6.blob.core.windows.net/vhds");

            ////Get troubleshooting
            //var networkWatcherCollection = GetNetworkWatcherCollection("NetworkWatcherRG");
            //var troubleshootOperation = await networkWatcherCollection.Get("NetworkWatcher_westus2").Value.GetTroubleshootingAsync(parameters);
            //await troubleshootOperation.WaitForCompletionAsync();;

            ////Query last troubleshoot
            //var queryTroubleshootOperation = await networkWatcherCollection.Get("NetworkWatcher_westus2").Value.GetTroubleshootingResultAsync(new QueryTroubleshootingParameters(getVirtualNetworkGatewayResponse.Value.Id));
            //await queryTroubleshootOperation.WaitForCompletionAsync();;
            //TODO: make verification once fixed for troubleshoot API deployed
        }
    }
}
#endif
