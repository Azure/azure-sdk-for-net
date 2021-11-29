using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;
using Xunit;
using System.Linq;

namespace Management.HDInsight.Tests
{
    public class PrivateLinkResourceTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestGetAndListPrivateLinkResource()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-plservice");
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

            // Test List API
            var privateLinkResourceListResult = HDInsightClient.PrivateLinkResources.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.NotNull(privateLinkResourceListResult);

            // Test Get API
            var signlePrivateLinkResource = HDInsightClient.PrivateLinkResources.Get(CommonData.ResourceGroupName, clusterName, privateLinkResourceListResult.Value.First().Name);
            Assert.Equal(signlePrivateLinkResource.GroupId, privateLinkResourceListResult.Value.First().GroupId);


        }
    }
}
