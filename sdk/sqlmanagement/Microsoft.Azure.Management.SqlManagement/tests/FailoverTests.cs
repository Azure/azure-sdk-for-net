// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class FailoverTests
    {
        [Fact]
        public void FailoverDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                // Create database
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db);

                // Failover database
                sqlClient.Databases.Failover(
                    resourceGroup.Name,
                    server.Name,
                    dbName);
            }
        }

        [Fact]
        public void FailoverReadableSecondaryDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                // Create database
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1)
                };
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db);

                // Failover database
                sqlClient.Databases.Failover(
                    resourceGroup.Name,
                    server.Name,
                    dbName,
                    "ReadableSecondary");
            }
        }

        [Fact]
        public void FailoverElasticPool()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);
                
                // Create elastic pool
                string epName = SqlManagementTestUtilities.GenerateName();
                var ep = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, new ElasticPool()
                {
                    Location = server.Location
                });
                Assert.NotNull(ep);

                // Create database in elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = ep.Id
                };
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db);

                // Failover elastic pool
                sqlClient.ElasticPools.Failover(
                    resourceGroup.Name,
                    server.Name,
                    epName);
            }
        }
    }
}
