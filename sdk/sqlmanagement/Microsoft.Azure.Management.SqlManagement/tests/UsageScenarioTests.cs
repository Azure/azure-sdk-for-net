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
    public class UsageScenarioTests
    {
        [Fact]
        public void TestGetSubscriptionUsageData()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Get subscription usages for a location
                IEnumerable<SubscriptionUsage> subscriptionUsages =
                    sqlClient.SubscriptionUsages.ListByLocation(TestEnvironmentUtilities.DefaultLocation);
                Assert.True(subscriptionUsages.Count() > 0);

                // Get a single subscription usage for a location
                SubscriptionUsage subscriptionUsage =
                    sqlClient.SubscriptionUsages.Get(TestEnvironmentUtilities.DefaultLocation, "ServerQuota");
            }
        }

        [Fact]
        public void TestGetUsageData()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Get server Usages
                IEnumerable<ServerUsage> serverUsages = sqlClient.ServerUsages.ListByServer(resourceGroup.Name, server.Name);
                Assert.True(serverUsages.Count(s => s.ResourceName == server.Name) > 1);

                // Create a database and get usages
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                IEnumerable<DatabaseUsage> databaseUsages = sqlClient.DatabaseUsages.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.True(databaseUsages.Where(db => db.ResourceName == dbName).Count() == 1);
            }
        }
    }
}
