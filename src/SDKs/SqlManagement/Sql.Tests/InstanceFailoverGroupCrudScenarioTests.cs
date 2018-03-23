// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class InstanceFailoverGroupCrudScenarioTests
    {
        [Fact]
        public void TestCrudInstanceFailoverGroup()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                string managedInstanceName = "jugeorge-crudtests-managedinstance";
                string login = "dummylogin";
                string password = "Un53cuRE!";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku();
                sku.Name = "CLS3";
                sku.Tier = "Standard";

                string subnetId = "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/RG_MIPlayground/providers/Microsoft.Network/virtualNetworks/VNET_MIPlayground/subnets/MISubnet";
                string secondarySubnetId = "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ReadyWorkshop/providers/Microsoft.Network/virtualNetworks/VNET_Workshop_2/subnets/MIsubnet";
                string primaryLocation = "eastus";
                string secondaryLocation = "westus";

                //Create server 
                var sourceManagedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, managedInstanceName, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = subnetId,
                    Tags = tags,
                    Location = primaryLocation,
                });
                SqlManagementTestUtilities.ValidateManagedInstance(sourceManagedInstance, managedInstanceName, login, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Create second server
                string managedInstanceName2 = "jugeorge-crudtests-managedinstance2";
                var targetManagedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, managedInstanceName2, new ManagedInstance()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Sku = sku,
                    SubnetId = secondarySubnetId,
                    Tags = tags,
                    Location = secondaryLocation,
                });
                SqlManagementTestUtilities.ValidateManagedInstance(targetManagedInstance, managedInstanceName2, login, tags, TestEnvironmentUtilities.DefaultLocationId);

                // Create database only required parameters
                //
                string mdbName = SqlManagementTestUtilities.GenerateName();
                var mdb1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, sourceManagedInstance.Name, mdbName, new ManagedDatabase()
                {
                    Location = sourceManagedInstance.Location,
                });
                Assert.NotNull(mdb1);

                ManagedDatabase primaryDatabase = sqlClient.ManagedDatabases.Get(resourceGroup.Name, sourceManagedInstance.Name, mdbName);
                Assert.Null(primaryDatabase.FailoverGroupId);

                // Drop servers
                sqlClient.ManagedInstances.Delete(resourceGroup.Name, managedInstanceName);
                sqlClient.ManagedInstances.Delete(resourceGroup.Name, managedInstanceName2);
            }
        }
    }
}