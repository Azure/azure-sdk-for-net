// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceFailoverTests
    {
        [Fact]
        public void FailoverPrimary()
        {
            using(SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = new ResourceGroup(
                    TestEnvironmentUtilities.DefaultLocationId, name: "mibrkic");
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                string managedInstanceName = "sqlcl-failovertests-dotnetsdk1";
                
                VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku
                {
                    Name = "MIGP8G4",
                    Tier = "GeneralPurpose"
                };

                ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
                    managedInstanceName + SqlManagementTestUtilities.GenerateName(methodName: "failover_primary"), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });
                Assert.NotNull(managedInstance);

                sqlClient.ManagedInstances.Failover(resourceGroup.Name, managedInstance.Name, ReplicaType.Primary);
            }
        }

        [Fact]
        public void FailoverReadableSecondaryInstance()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = new ResourceGroup(
                    TestEnvironmentUtilities.DefaultLocationId, name: "mibrkic");
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                string managedInstanceName = "sqlcl-failovertests-dotnetsdk1";

                VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

                Microsoft.Azure.Management.Sql.Models.Sku sku = new Microsoft.Azure.Management.Sql.Models.Sku
                {
                    Name = "MIBC8G5",
                    Tier = "BusinessCritical"
                };

                ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
                    managedInstanceName + SqlManagementTestUtilities.GenerateName(methodName: "failover_readable_secondary"), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });
                Assert.NotNull(managedInstance);

                sqlClient.ManagedInstances.Failover(resourceGroup.Name, managedInstance.Name, ReplicaType.ReadableSecondary);
            }
        }
    }
}