using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using SubResource = Microsoft.Azure.Management.Network.Models.SubResource;
    using Helpers;
    using Networks.Tests;
    using Microsoft.Azure.Management.Storage.Models;

    public class TroubleshootTests
    {
        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void TroubleshootApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler4 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);
                var storageManagementClient = NetworkManagementTestUtilities.GetStorageManagementClientWithHandler(context, handler4);

                string location = "westcentralus";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // CreateVirtualNetworkGateway API
                // Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkManagementClient);

                //Prerequisite:-Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayDefaultSite = null,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>()
                    {
                        new VirtualNetworkGatewayIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PublicIPAddress = new SubResource()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    },
                    Sku = new VirtualNetworkGatewaySku()
                    {
                        Name = VirtualNetworkGatewaySkuName.Basic,
                        Tier = VirtualNetworkGatewaySkuTier.Basic
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);

                // GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;
               
                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);


                //Create storage
                string storageName = TestUtilities.GenerateName();

                var storageParameters = new StorageAccountCreateParameters()
                {
                    Location = location,
                    Kind = Kind.Storage,
                    Sku = new Sku
                    {
                        Name = SkuName.StandardLRS
                    }
                };

                var account = storageManagementClient.StorageAccounts.Create(resourceGroupName, storageName, storageParameters);

                TroubleshootingParameters parameters = new TroubleshootingParameters()
                {
                    TargetResourceId = getVirtualNetworkGatewayResponse.Id,
                    StorageId = account.Id,
                    StoragePath = "https://nwtestdbdzq4xsvskrei6.blob.core.windows.net/vhds",
                };

                //Get troubleshooting
                var troubleshoot = networkManagementClient.NetworkWatchers.GetTroubleshooting(resourceGroupName, networkWatcherName, parameters);

                QueryTroubleshootingParameters qParameters = new QueryTroubleshootingParameters()
                {
                    TargetResourceId = getVirtualNetworkGatewayResponse.Id
                };

                //Query last troubleshoot
                var queryTroubleshoot = networkManagementClient.NetworkWatchers.GetTroubleshootingResult(resourceGroupName, networkWatcherName, qParameters);
                
                //TO DO: make verification once fixed for troubleshoot API deployed
            }
        }
    }
}

