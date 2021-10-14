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

                Random r = new Random();
                string managedInstanceName = "sqlcl-crudtestswithfmw-dotnetsdk1";
                string login = "dummylogin";
                string password = "Un53cuRE!12314124";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku();
                sku.Name = "MIGP4G4";
                sku.Tier = "GeneralPurpose";
                sku.Family = "Gen5";

                string subnetId = "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG/providers/Microsoft.Network/virtualNetworks/vnet-mi-tooling/subnets/ManagedInstance";
                string location = "westcentralus";

                bool publicDataEndpointEnabled = true;
                string proxyOverride = ManagedInstanceProxyOverride.Proxy;
                string storageAccountType = "Geo";
                string publicResourceName = "MI_Sat_12AM_6AM";
                

                //Create server 
                var managedInstance1 = sqlClient.ManagedInstances.CreateOrUpdate("CustomerExperienceTeam_RG", managedInstanceName, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                    RequestedBackupStorageRedundancy = storageAccountType
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Create second server
                string managedInstanceName2 = "sqlcl-crudtestswithfmw-dotnetsdk2";
                var managedInstance2 = sqlClient.ManagedInstances.CreateOrUpdate("CustomerExperienceTeam_RG", managedInstanceName2, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                    DnsZonePartner = string.Format("/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/{0}/providers/Microsoft.Sql/managedInstances/{1}", "CustomerExperienceTeam_RG", managedInstanceName),
                    PublicDataEndpointEnabled = publicDataEndpointEnabled,
                    ProxyOverride = proxyOverride,
                    RequestedBackupStorageRedundancy = storageAccountType
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Get first server
                var getMI1 = sqlClient.ManagedInstances.Get("CustomerExperienceTeam_RG", managedInstanceName);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Get second server
                var getMI2 = sqlClient.ManagedInstances.Get("CustomerExperienceTeam_RG", managedInstanceName2);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId, shouldCheckState: true);

                // Verify that maintenanceConfigurationId value is correctly set
                // Assert.Equal(publicResourceName, getMI1.MaintenanceConfigurationId);
                // Assert.Equal(publicResourceName, getMI2.MaintenanceConfigurationId);

                // Verify that storageAccountType value is correctly set
                Assert.Equal(storageAccountType, getMI1.RequestedBackupStorageRedundancy);
                Assert.Equal(storageAccountType, getMI2.RequestedBackupStorageRedundancy);
                Assert.Equal(storageAccountType, getMI1.CurrentBackupStorageRedundancy);
                Assert.Equal(storageAccountType, getMI2.CurrentBackupStorageRedundancy);

                // Verify that dns zone value is correctly inherited from dns zone partner
                Assert.Equal(getMI1.DnsZone, getMI2.DnsZone);

                // Verify PublicDataEndpointEnabled value for second server
                Assert.Equal(publicDataEndpointEnabled, getMI2.PublicDataEndpointEnabled);

                // Verify ProxyOverride value for second server
                Assert.Equal(proxyOverride, getMI2.ProxyOverride);

                var listMI = sqlClient.ManagedInstances.ListByResourceGroup("CustomerExperienceTeam_RG");
                Assert.Equal(2, listMI.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateMI1 = sqlClient.ManagedInstances.Update("CustomerExperienceTeam_RG", managedInstanceName, new ManagedInstanceUpdate { Tags = newTags, LicenseType = "LicenseIncluded" });
                SqlManagementTestUtilities.ValidateManagedInstance(updateMI1, managedInstanceName, login, newTags, TestEnvironmentUtilities.DefaultLocationId);

                // Drop server, update count
                sqlClient.ManagedInstances.Delete("CustomerExperienceTeam_RG", managedInstanceName);

                var listMI2 = sqlClient.ManagedInstances.ListByResourceGroup("CustomerExperienceTeam_RG");
                Assert.Single(listMI2);

                sqlClient.ManagedInstances.Delete("CustomerExperienceTeam_RG", managedInstanceName2);
                var listMI3 = sqlClient.ManagedInstances.ListByResourceGroup("CustomerExperienceTeam_RG");
                Assert.Empty(listMI3);
            }
        }
    }
}
