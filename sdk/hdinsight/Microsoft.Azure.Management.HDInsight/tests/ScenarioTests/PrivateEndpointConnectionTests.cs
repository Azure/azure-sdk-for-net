using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using NetworkPrivateEndpoint = Microsoft.Azure.Management.Network.Models.PrivateEndpoint;
using NetworkPrivateLinkServiceConnection = Microsoft.Azure.Management.Network.Models.PrivateLinkServiceConnection;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Management.HDInsight.Tests
{
    public class PrivateEndpointConnectionTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestPrivateEndpointConnection()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-pe");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";

            var networkProperties = new NetworkProperties(ResourceProviderConnection.Outbound, PrivateLink.Enabled);
            createParams.Properties.NetworkProperties = networkProperties;

            string storageAccountResourceId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Storage/storageAccounts/{2}", CommonData.SubscriptionId, CommonData.ResourceGroupName, CommonData.StorageAccountName);
            createParams.Properties.StorageProfile.Storageaccounts[0].ResourceId = storageAccountResourceId;

            string vnetId = "/subscriptions/964c10bb-8a6c-43bc-83d3-6b318c6c7305/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet";
            string subnetId = "/subscriptions/964c10bb-8a6c-43bc-83d3-6b318c6c7305/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet/subnets/default";

            foreach (var role in createParams.Properties.ComputeProfile.Roles)
            {
                role.VirtualNetworkProfile = new VirtualNetworkProfile(vnetId, subnetId);
            }

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);

            var privateLinkResourceListResult = HDInsightClient.PrivateLinkResources.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.NotNull(privateLinkResourceListResult);

            var headNodePrivateLinkResource = privateLinkResourceListResult.Value.Where(pls => pls.Name.Equals("headnode")).FirstOrDefault();

            // call Network sdk to create private endpoint and choose the approve manually way.
            // please notice that the 
            NetworkPrivateEndpoint privateEndpointParameter = new NetworkPrivateEndpoint()
            {
                Location = cluster.Location,
                ManualPrivateLinkServiceConnections = new List<NetworkPrivateLinkServiceConnection>
                {
                    new NetworkPrivateLinkServiceConnection()
                    {
                        Name = cluster.Name, // Private link service name is the cluster name
                        PrivateLinkServiceId = cluster.Id, // Private link service id is the cluster resource id
                        GroupIds = new List<string> {
                            headNodePrivateLinkResource.GroupId,
                        },
                        RequestMessage = "Want to connect to head node private link resource."
                    },
                },
                Subnet = new Subnet(id: subnetId)

            };
            string privateEndpointName = "headnodepe";
            var createPrivateEndpointResult = HDInsightManagementHelper.CreatePrivateEndpoint(CommonData.ResourceGroupName, privateEndpointName, privateEndpointParameter);

            // Get the private endpoint connection and check the status
            
            
            var privateEndpointConnectionListResult = HDInsightClient.PrivateEndpointConnections.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.NotNull(privateEndpointConnectionListResult);

            foreach( var privateEndpointConnection in privateEndpointConnectionListResult)
            {
                Assert.Equal(PrivateLinkServiceConnectionStatus.Pending, privateEndpointConnection.PrivateLinkServiceConnectionState.Status);

                //Approve
                privateEndpointConnection.PrivateLinkServiceConnectionState.Status = PrivateLinkServiceConnectionStatus.Approved;
                HDInsightClient.PrivateEndpointConnections.CreateOrUpdate(CommonData.ResourceGroupName, clusterName, privateEndpointConnection.Name, privateEndpointConnection);

                //Delete
                HDInsightClient.PrivateEndpointConnections.Delete(CommonData.ResourceGroupName, clusterName, privateEndpointConnection.Name);
            }
        }
    }
}
