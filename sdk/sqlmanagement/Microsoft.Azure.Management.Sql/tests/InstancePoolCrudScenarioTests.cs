// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class InstancePoolCrudScenarioTests
    {
        [Fact(Skip = "Due long running setup")]
        public void TestCreateUpdateGetDropInstancePool()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Setup
                string subscriptionId = "2e7fe4bd-90c7-454e-8bb6-dc44649f27b2";
                string resourceGroupName = "sqlcrudtest-5294";
                string instancePoolName = "sqlcl-crudtestinstancepool-dotnetsdk1";
                string subnetId = $"/subscriptions/2e7fe4bd-90c7-454e-8bb6-dc44649f27b2/resourceGroups/instancepoolnetsdkcanadacentral/providers/Microsoft.Network/virtualNetworks/vnet-instancepoolnetsdkcanadacentral/subnets/InstancePool";
                string location = "canadacentral";
                int instancePoolVCores = 32;
                var tags1 = new Dictionary<string, string>()
                {
                    {"tagKey1", "TagValue1"}
                };
                var tags2 = new Dictionary<string, string>()
                {
                    {"tagKey2", "TagValue2"}
                };

                // Create an instance pool
                var instancePool = sqlClient.InstancePools.CreateOrUpdate(
                  resourceGroupName,
                  instancePoolName,
                  parameters: new InstancePool()
                  {
                      LicenseType = "LicenseIncluded",
                      Sku = new Sku()
                      {
                          Name = "GP_Gen5",
                          Tier = "GeneralPurpose",
                          Family = "Gen5"
                      },
                      SubnetId = subnetId,
                      Tags = tags1,
                      VCores = instancePoolVCores,
                      Location = location
                  });

                SqlManagementTestUtilities.ValidateInstancePool(
                    instancePool,
                    instancePoolName, vCores: instancePoolVCores, subnetId: subnetId, location: location, tags: tags1);

                // Update the instance pool tags
                instancePool = sqlClient.InstancePools.Update(
                    resourceGroupName,
                    instancePoolName,
                    parameters: new InstancePoolUpdate(tags: tags2));

                SqlManagementTestUtilities.ValidateInstancePool(
                    instancePool,
                    instancePoolName, vCores: instancePoolVCores, subnetId: subnetId, location: location, tags: tags2);

                // Get the instance pool
                instancePool = sqlClient.InstancePools.Get(
                    resourceGroupName,
                    instancePoolName);

                SqlManagementTestUtilities.ValidateInstancePool(
                    instancePool,
                    instancePoolName, vCores: instancePoolVCores, subnetId: subnetId, location: location, tags: tags2);

                // Get the resource group instance pools
                var instancePoolsRg = sqlClient.InstancePools.ListByResourceGroup(resourceGroupName);
                Assert.NotNull(instancePoolsRg);

                // Gets all instance pools in sub
                var instancePoolsSub = sqlClient.InstancePools.List();
                Assert.NotNull(instancePoolsSub);

                // Verify usage
                var instancePoolUsage = sqlClient.Usages.ListByInstancePool(resourceGroupName, instancePoolName, true).ToList();
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[0],
                    currentValue: 0, limit: instancePoolVCores, requestedLimit: null, usageName: "VCore utilization");
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[1],
                    currentValue: 0, limit: 8192, requestedLimit: null, usageName: "Storage utilization");
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[2],
                    currentValue: 0, limit: 100, requestedLimit: null, usageName: "Database utilization");

                var instanceParams = new ManagedInstance
                {
                    AdministratorLogin = "cloudsa",
                    AdministratorLoginPassword = "Yukon900!",
                    InstancePoolId = instancePool.Id,
                    Location = location,
                    PublicDataEndpointEnabled = true,
                    Sku = new Sku
                    {
                        Name = "GP_Gen5",
                        Tier = "GeneralPurpose",
                        Family = "Gen5"
                    },
                    StorageSizeInGB = 32,
                    SubnetId = instancePool.SubnetId,
                    VCores = 2,
                    Tags = tags1
                };

                // Create instance 1 in pool
                var instance1 = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroupName, "netsdk-instance-in-pool-1-cc", parameters: instanceParams);
                SqlManagementTestUtilities.ValidateManagedInstance(instance1, tags: tags1, instancePoolId: instancePool.Id);

                // Create instance 2 in pool
                var instance2 = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroupName, "netsdk-instance-in-pool-2-cc", parameters: instanceParams);
                SqlManagementTestUtilities.ValidateManagedInstance(instance2, tags: tags1, instancePoolId: instancePool.Id);

                // Gets instances in an instance pool
                var instances = sqlClient.ManagedInstances.ListByInstancePool(resourceGroupName, instancePoolName);
                instances = sqlClient.ManagedInstances.ListByInstancePool(resourceGroupName, instancePoolName);
                Assert.Equal(2, instances.Count());

                // Validate instance pool usage
                instancePoolUsage = sqlClient.Usages.ListByInstancePool(resourceGroupName, instancePoolName, true).ToList();
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[0],
                    currentValue: 4, limit: instancePoolVCores, requestedLimit: null, usageName: "VCore utilization");
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[1],
                    currentValue: 64, limit: 8192, requestedLimit: null, usageName: "Storage utilization");
                SqlManagementTestUtilities.ValidateInstancePoolUsage(instancePoolUsage[2],
                    currentValue: 0, limit: 100, requestedLimit: null, usageName: "Database utilization");

                // Delete the instances in the instance pool
                foreach (var instance in instances)
                {
                    sqlClient.ManagedInstances.Delete(resourceGroupName, instance.Name);
                }

                // Delete the instance pool
                sqlClient.InstancePools.Delete(resourceGroupName, instancePool.Name);
            }
        }
    }
}
