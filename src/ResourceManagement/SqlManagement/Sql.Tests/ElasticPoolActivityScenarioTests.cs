// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
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
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestListElasticPoolDatabaseActivity", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
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
                    Edition = SqlTestConstants.DefaultElasticPoolEdition,
                    Tags = tags,
                    Dtu = 100,
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
                    ElasticPoolName = epName
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List
                var activity = sqlClient.ElasticPools.ListDatabaseActivity(resourceGroup.Name, server.Name, epName);

                Assert.Equal(2, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "UPDATE").Count());
            });
        }

        [Fact]
        public void TestListElasticPoolActivity()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestListElasticPoolActivity", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
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
                    Edition = SqlTestConstants.DefaultElasticPoolEdition,
                    Tags = tags,
                    Dtu = 100,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);
                
                // Get the Elastic Pool Activity List
                var activity = sqlClient.ElasticPools.ListActivity(resourceGroup.Name, server.Name, epName);

                Assert.Equal(1, activity.Where(a => a.ElasticPoolName == epName).Count());
                Assert.Equal(1, activity.Where(a => a.Operation == "CREATE").Count());
            });
        }

        [Fact]
        public void TestMoveBetweenPoolsAndGetActivity()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestMoveBetweenPoolsAndGetActivity", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
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
                    Edition = SqlTestConstants.DefaultElasticPoolEdition,
                    Tags = tags,
                    Dtu = 100,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                var returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName);
                
                string epName2 = SqlManagementTestUtilities.GenerateName();
                epInput = new ElasticPool()
                {
                    Location = server.Location,
                    Edition = SqlTestConstants.DefaultElasticPoolEdition,
                    Tags = tags,
                    Dtu = 100,
                    DatabaseDtuMax = 5,
                    DatabaseDtuMin = 0
                };
                returnedEp = sqlClient.ElasticPools.CreateOrUpdate(resourceGroup.Name, server.Name, epName2, epInput);
                SqlManagementTestUtilities.ValidateElasticPool(epInput, returnedEp, epName2);

                // Create a database in first elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolName = epName
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List for first pool
                var activity = sqlClient.ElasticPools.ListDatabaseActivity(resourceGroup.Name, server.Name, epName);
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());

                // Move database to second elastic pool
                dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolName = epName2
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the Elastic Pool Database Activity List for second pool
                activity = sqlClient.ElasticPools.ListDatabaseActivity(resourceGroup.Name, server.Name, epName2);
                Assert.Equal(2, activity.Where(a => a.DatabaseName == dbName).Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "CREATE").Count());
                Assert.Equal(1, activity.Where(a => a.DatabaseName == dbName && a.Operation == "UPDATE").Count());
            });
        }
    }
}
