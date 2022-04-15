// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceCrudScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDropManagedInstance()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                bool publicDataEndpointEnabled = true;
                string proxyOverride = ManagedInstanceProxyOverride.Proxy;
                string requestedBSR = "Geo";
                string publicResourceName = "SQL_Default";
                string maintenanceConfigurationId = ManagedInstanceTestUtilities.getManagedInstanceFullMaintenanceResourceid();

                // Create resource group
                var resourceGroup = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                //Create server 
                var managedInstance1 = context.CreateManagedInstance(resourceGroup, new ManagedInstance()
                {
                    Tags = tags,
                    MaintenanceConfigurationId = maintenanceConfigurationId
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance1, tags, shouldCheckState: true);

                // Create second server
                var managedInstance2 = context.CreateManagedInstance(resourceGroup, new ManagedInstance()
                {
                    DnsZonePartner = string.Format(
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/managedInstances/{2}",
                        ManagedInstanceTestUtilities.SubscriptionId,
                        ManagedInstanceTestUtilities.ResourceGroupName,
                        managedInstance1.Name),
                    PublicDataEndpointEnabled = publicDataEndpointEnabled,
                    ProxyOverride = proxyOverride
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance2, shouldCheckState: true);

                // Get first server
                var getMI1 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstance1.Name);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI1, tags, shouldCheckState: true);

                // Get second server
                var getMI2 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstance2.Name);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI2, shouldCheckState: true);

                // Verify that maintenanceConfigurationId value is correctly set
                Assert.Contains(publicResourceName, getMI1.MaintenanceConfigurationId);

                // Verify that storageAccountType value is correctly set
                Assert.Equal(requestedBSR, getMI1.RequestedBackupStorageRedundancy);
                Assert.Equal(requestedBSR, getMI2.RequestedBackupStorageRedundancy);
                Assert.Equal(requestedBSR, getMI1.CurrentBackupStorageRedundancy);
                Assert.Equal(requestedBSR, getMI2.CurrentBackupStorageRedundancy);

                // Verify that dns zone value is correctly inherited from dns zone partner
                Assert.Equal(getMI1.DnsZone, getMI2.DnsZone);

                // Verify PublicDataEndpointEnabled value for second server
                Assert.Equal(publicDataEndpointEnabled, getMI2.PublicDataEndpointEnabled);

                // Verify ProxyOverride value for second server
                Assert.Equal(proxyOverride, getMI2.ProxyOverride);

                var listMI = context.ListManagedInstanceByResourceGroup(resourceGroup.Name);
                
                Assert.Equal(2, listMI.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateMI1 = sqlClient.ManagedInstances.Update(resourceGroup.Name, getMI1.Name, new ManagedInstanceUpdate
                {
                    Tags = newTags,
                    LicenseType = "LicenseIncluded"
                });
                SqlManagementTestUtilities.ValidateManagedInstance(updateMI1, newTags);

                // Drop server, update count
                sqlClient.ManagedInstances.Delete(resourceGroup.Name, getMI1.Name);

                var listMI2 = context.ListManagedInstanceByResourceGroup(resourceGroup.Name);
                Assert.Single(listMI2);

                sqlClient.ManagedInstances.Delete(resourceGroup.Name, managedInstance2.Name);
                var listMI3 = context.ListManagedInstanceByResourceGroup(resourceGroup.Name);
                Assert.Empty(listMI3);
            }
        }
    }
}
