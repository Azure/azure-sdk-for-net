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
    public class DatabaseGeoBackupPolicyScenarioTests
    {
        [Fact]
        public void TestUpdateGetListGeoBackupPolicy()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create data warehouse
                string dbName = SqlManagementTestUtilities.GenerateName();
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                    Sku = SqlTestConstants.DefaultDataWarehouseSku()
                });
                Assert.NotNull(db1);

                // List Geo Backup Policy
                IEnumerable<GeoBackupPolicy> policies = sqlClient.GeoBackupPolicies.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(1, policies.Count());

                GeoBackupPolicy policy = policies.First();
                Assert.Equal("Default", policy.Name);
                Assert.Equal(GeoBackupPolicyState.Enabled, policy.State);
                Assert.Equal("Premium", policy.StorageType);

                // Get Geo Backup Policy
                policy = sqlClient.GeoBackupPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal("Default", policy.Name);
                Assert.Equal(GeoBackupPolicyState.Enabled, policy.State);
                Assert.Equal("Premium", policy.StorageType);

                // Update policy
                sqlClient.GeoBackupPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new GeoBackupPolicy
                {
                    State = GeoBackupPolicyState.Disabled
                });

                // List Geo Backup Policy
                policies = sqlClient.GeoBackupPolicies.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(1, policies.Count());

                policy = policies.First();
                Assert.Equal("Default", policy.Name);
                Assert.Equal(GeoBackupPolicyState.Disabled, policy.State);
                Assert.Equal("Premium", policy.StorageType);

                // Get Geo Backup Policy
                policy = sqlClient.GeoBackupPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal("Default", policy.Name);
                Assert.Equal(GeoBackupPolicyState.Disabled, policy.State);
                Assert.Equal("Premium", policy.StorageType);
            }
        }
    }
}
