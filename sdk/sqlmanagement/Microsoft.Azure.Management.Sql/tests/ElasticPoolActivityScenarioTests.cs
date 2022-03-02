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
    public class ElasticPoolActivityScenarioTests
    {
        [Fact]
        public void TestListElasticPoolDatabaseActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create a elastic pool
                // 
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Tags = tags,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);

                // Create a database
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Add database to elastic pool - should have CREATE and UPDATE records
                // This is because we moved existing DB to elastic pool instead of creating in Elastic Pool
                dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = returnedEp.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List
                var activity = sqlClient.ElasticPoolDatabaseActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);

                Assert.Equal(2, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "UPDATE").Count());
            }
        }

        [Fact]
        public void TestListHyperscaleElasticPoolDatabaseActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup(TestEnvironmentUtilities.DefaultStagePrimaryLocation);
                Server server = context.CreateServer(resourceGroup, TestEnvironmentUtilities.DefaultStagePrimaryLocation);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create a Hyperscale elasticPool with specified replica count of 2
                // 
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku("HS_Gen5_4"),
                    HighAvailabilityReplicaCount = 2
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);

                // Create a database in Hyperscale elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = returnedEp.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                var returnedDb = sqlClient.Databases.Get(resourceGroup.Name, server.Name, dbName);

                // Verify database has the same value for replica count as pool
                Assert.Equal(2, returnedDb.HighAvailabilityReplicaCount);

                // Get the Elastic Pool Database Activity List
                var activity = sqlClient.ElasticPoolDatabaseActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);

                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());
            }
        }

        [Fact]
        public void TestListElasticPoolActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create a elastic pool
                // 
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Tags = tags,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);
                
                // Get the Elastic Pool Activity List
                var activity = sqlClient.ElasticPoolActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);

                Assert.Equal(1, activity.Where(a => a.ElasticPoolName == epName).Count());
                Assert.Equal(1, activity.Where(a => a.Operation == "CREATE").Count());
            }
        }

        [Fact]
        public void TestMoveBetweenPoolsAndGetActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create two elastic pools
                // 
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Tags = tags,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp1 = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp1, epName);
                
                string epName2 = SqlManagementTestUtilities.GenerateName();
                epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Tags = tags,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp2 = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName2, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp2, epName2);

                // Create a database in first elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = returnedEp1.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List for first pool
                var activity = sqlClient.ElasticPoolDatabaseActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName);
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());

                // Move database to second elastic pool
                dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = returnedEp2.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List for second pool
                activity = sqlClient.ElasticPoolDatabaseActivities.ListByElasticPool(resourceGroup.Name, server.Name, epName2);
                Assert.Equal(2, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "UPDATE").Count());
            }
        }

        [Fact]
        public void TestMoveOutOfHyperscalePoolAndGetActivity()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup(TestEnvironmentUtilities.DefaultStagePrimaryLocation);
                Server server = context.CreateServer(resourceGroup, TestEnvironmentUtilities.DefaultStagePrimaryLocation);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create a Hyperscale elasticPool with specified replica count of 2
                // 
                string epName = SqlManagementTestUtilities.GenerateName();
                var epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku("HS_Gen5_4"),
                    HighAvailabilityReplicaCount = 2
                };

                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);

                // Create a database in elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolId = returnedEp.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Move database out of elastic pool
                dbInput = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku("HS_Gen5_4")
                };
                var returnedDb = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Verify database has the same value for replica count as pool
                Assert.Equal(2, returnedDb.HighAvailabilityReplicaCount);
            }
        }
    }
}
