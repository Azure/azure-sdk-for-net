﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class ManagedInstanceCrudScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDropManagedInstance()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

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

                string subnetId = "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/StdjordjTestResourceGroup/providers/Microsoft.Network/virtualNetworks/ZiwaVirtualNetwork4/subnets/default";
                string location = "westcentralus";

                //Create server 
                var managedInstance1 = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, managedInstanceName, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = location,
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId);

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
                    DnsZonePartner = string.Format("/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/{0}/providers/Microsoft.Sql/managedInstances/sqlcl-crudtestswithdnszone-dotnetsdk1", resourceGroup.Name)
                });
                SqlManagementTestUtilities.ValidateManagedInstance(managedInstance2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get first server
                var getMI1 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstanceName);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI1, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Get second server
                var getMI2 = sqlClient.ManagedInstances.Get(resourceGroup.Name, managedInstanceName2);
                SqlManagementTestUtilities.ValidateManagedInstance(getMI2, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Verify that dns zone value is correctly inherited from dns zone partner
                Assert.Equal(getMI1.DnsZone, getMI2.DnsZone);

                var listMI = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(2, listMI.Count());

                // Update first server
                Dictionary<string, string> newTags = new Dictionary<string, string>()
                    {
                        { "asdf", "zxcv" }
                    };
                var updateMI1 = sqlClient.ManagedInstances.Update(resourceGroup.Name, managedInstanceName, new ManagedInstanceUpdate { Tags = newTags });
                SqlManagementTestUtilities.ValidateManagedInstance(updateMI1, managedInstanceName, login, newTags, TestEnvironmentUtilities.DefaultLocationId);

                // Drop server, update count
                sqlClient.ManagedInstances.DeleteAsync(resourceGroup.Name, managedInstanceName);

                var listMI2 = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(1, listMI2.Count());

                sqlClient.ManagedInstances.DeleteAsync(resourceGroup.Name, managedInstanceName2);
                var listMI3 = sqlClient.ManagedInstances.ListByResourceGroup(resourceGroup.Name);
                Assert.Empty(listMI3);
            }
        }
    }
}
