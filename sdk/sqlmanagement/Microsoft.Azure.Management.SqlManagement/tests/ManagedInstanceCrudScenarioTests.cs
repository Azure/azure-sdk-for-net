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
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Random r = new Random();
                string managedInstanceName = "sqlcl-crudtestswithdnszone-dotnetsdk1";
                string login = "dummylogin";
                string password = "Un53cuRE!";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                sku.Family = "Gen5";

                string subnetId = "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/v-urmila/providers/Microsoft.Network/virtualNetworks/MIVirtualNetwork/subnets/ManagedInsanceSubnet";
                string location = "westeurope";

                bool publicDataEndpointEnabled = true;
                string proxyOverride = ManagedInstanceProxyOverride.Proxy;
                string storageAccountType = "GRS";

                //Create server 
                var managedInstance1 = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, managedInstanceName, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                    StorageAccountType = storageAccountType
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Create second server
                string managedInstanceName2 = "sqlcl-crudtestswithdnszone-dotnetsdk2";
                var managedInstance2 = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, managedInstanceName2, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                    DnsZonePartner = string.Format("/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/{0}/providers/Microsoft.Sql/managedInstances/{1}", resourceGroup.Name, managedInstanceName),
                    PublicDataEndpointEnabled = publicDataEndpointEnabled,
                    ProxyOverride = proxyOverride,
                    StorageAccountType = storageAccountType
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Get first server
                var getMI1 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstanceName);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Get second server
                var getMI2 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstanceName2);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Verify that storageAccountType value is correctly set
                Assert.Equal(storageAccountType, getMI1.StorageAccountType);
                Assert.Equal(storageAccountType, getMI2.StorageAccountType);

                // Verify that dns zone value is correctly inherited from dns zone partner
                Assert.Equal(getMI1.DnsZone, getMI2.DnsZone);

                // Verify PublicDataEndpointEnabled value for second server
                Assert.Equal(publicDataEndpointEnabled, getMI2.PublicDataEndpointEnabled);

                // Verify ProxyOverride value for second server
                Assert.Equal(proxyOverride, getMI2.ProxyOverride);

                var listMI = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(2, listMI.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateMI1 = sqlClient.ManagedInstances.Update(resourceGroup.Name, managedInstanceName, new ManagedInstanceUpdate { Tags = newTags, LicenseType = "LicenseIncluded" });
                SqlManagementTestUtilities.ValidateManagedInstance(updateMI1, managedInstanceName, login, newTags, TestEnvironmentUtilities.DefaultLocationId);

                // Drop server, update count
                sqlClient.ManagedInstances.DeleteAsync(resourceGroup.Name, managedInstanceName).ConfigureAwait(true);

                var listMI2 = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(1, listMI2.Count());

                sqlClient.ManagedInstances.DeleteAsync(resourceGroup.Name, managedInstanceName2).ConfigureAwait(true);
                var listMI3 = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Empty(listMI3);
            }
        }
    }
}
