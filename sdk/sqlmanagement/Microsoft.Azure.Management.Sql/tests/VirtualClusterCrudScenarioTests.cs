// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class VirtualClusterCrudScenarioTests
    {
        [Fact]
        public void TestCreateGetDeleteVirtualCluster()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                string resourceGroupName = "RG_MIPlayground";
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                string managedInstanceName = "sqlcl-vccrudtests-dotnetsdk1";
                string login = "dummylogin";
                string password = "Un53cuRE!Pa$$w0rd1";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                sku.Family = "Gen4";

                string subnetId = "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/RG_MIPlayground/providers/Microsoft.Network/virtualNetworks/VNET_MIPlayground/subnets/VCReservedSubnet";
                string location = "eastus";

                //Create server 
                var managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroupName, managedInstanceName, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance, tags: tags);

                // Get and verify Virtual cluster
                var virtualClusters = sqlClient.VirtualClusters.List();
                Assert.True(virtualClusters.Count() > 0);
                var virtualCluster = virtualClusters.Single(vc => vc.SubnetId == subnetId);
                Assert.Equal(location, virtualCluster.Location, ignoreCase: true);
                string virtualClusterName = virtualCluster.Name;
                virtualCluster = sqlClient.VirtualClusters.ListByResourceGroup(resourceGroupName).Single(vc => vc.SubnetId == subnetId);
                Assert.Equal(location, virtualCluster.Location, ignoreCase: true);
                Assert.Equal(virtualClusterName, virtualCluster.Name);
                virtualCluster = sqlClient.VirtualClusters.Get(resourceGroupName, virtualClusterName);
                Assert.Equal(location, virtualCluster.Location, ignoreCase: true);
                Assert.Equal(virtualClusterName, virtualCluster.Name);
                Assert.Equal(subnetId, virtualCluster.SubnetId);

                // Drop managed server
                sqlClient.ManagedInstances.Delete(resourceGroupName, managedInstanceName);

                // Delete Virtual Cluster
                sqlClient.VirtualClusters.Delete(resourceGroupName, virtualClusterName);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.VirtualClusters.Get(resourceGroupName, virtualClusterName));
            }
        }
    }
}
