// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseCrudScenarioTests
    {
        [Fact]
        public void TestCreateDropDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestCreateDropDatabase", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create database only required parameters
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Create a database with all parameters specified
                // 
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db2Input = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    Collation = SqlTestConstants.DefaultCollation,
                    Edition = SqlTestConstants.DefaultDatabaseEdition,
                    MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    RequestedServiceObjectiveName = SqlTestConstants.DefaultDatabaseEdition,
                    RequestedServiceObjectiveId = ServiceObjectiveId.Basic,
                    Tags = tags,
                    CreateMode = "Default",
                    SampleName = SampleName.AdventureWorksLT
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db2Input);
                Assert.NotNull(db2);
                SqlManagementTestUtilities.ValidateDatabase(db2Input, db2, dbName);

                // Service Objective ID
                //
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db3Input = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    RequestedServiceObjectiveId = ServiceObjectiveId.Basic,
                    Tags = tags,
                };
                var db3 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db3Input);
                Assert.NotNull(db3);
                SqlManagementTestUtilities.ValidateDatabase(db3Input, db3, dbName);

                // Service Objective Name
                //
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db4Input = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    RequestedServiceObjectiveName = SqlTestConstants.DefaultDatabaseEdition,
                    Tags = tags,
                };
                var db4 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db4Input);
                Assert.NotNull(db4);
                SqlManagementTestUtilities.ValidateDatabase(db4Input, db4, dbName);

                // Edition
                //
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db5Input = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    Edition = SqlTestConstants.DefaultDatabaseEdition,
                    Tags = tags,
                };
                var db5 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db5Input);
                Assert.NotNull(db5);
                SqlManagementTestUtilities.ValidateDatabase(db5Input, db5, dbName);

                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db1.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db2.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db3.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db4.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db5.Name);
            });
        }

        [Fact]
        public void TestUpdateDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestUpdateDatabase", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);

                // Create initial database
                //
                var dbInput = new Database()
                {
                    Location = server.Location,
                    Collation = SqlTestConstants.DefaultCollation,
                    Edition = SqlTestConstants.DefaultDatabaseEdition,
                    MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    RequestedServiceObjectiveName = SqlTestConstants.DefaultDatabaseEdition,
                    RequestedServiceObjectiveId = ServiceObjectiveId.Basic,
                    Tags = tags,
                };
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db1);
                SqlManagementTestUtilities.ValidateDatabase(dbInput, db1, dbName);

                // Upgrade Edition + SLO Name
                //
                var updateEditionAndSloInput = new Database()
                {
                    Edition = DatabaseEditions.Standard,
                    RequestedServiceObjectiveName = ServiceObjectiveName.S0,
                    Location = server.Location
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput, db2, dbName);

                // Upgrade Edition + SLO ID
                //
                var updateEditionAndSloInput2 = new Database()
                {
                    Edition = SqlTestConstants.DefaultDatabaseEdition,
                    RequestedServiceObjectiveId = ServiceObjectiveId.Basic,
                    Location = server.Location
                };
                var db3 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput2);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput2, db3, dbName);

                // Upgrade Edition
                //
                var updateEditionInput = new Database()
                {
                    Edition = DatabaseEditions.Premium,
                    Location = server.Location
                };
                var db4 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionInput);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionInput, db4, dbName);

                // Upgrade SLO ID & Slo Name
                //
                var updateSloInput2 = new Database()
                {
                    RequestedServiceObjectiveName = ServiceObjectiveName.P2,
                    RequestedServiceObjectiveId = ServiceObjectiveId.P2,
                    Location = server.Location
                };
                var db5 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateSloInput2);
                SqlManagementTestUtilities.ValidateDatabase(updateSloInput2, db5, dbName);

                // Update max size
                //
                var updateMaxSize = new Database()
                {
                    MaxSizeBytes = (250 * 1024L * 1024L * 1024L).ToString(),
                    Location = server.Location
                };
                var db6 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateMaxSize);
                SqlManagementTestUtilities.ValidateDatabase(updateMaxSize, db6, dbName);
            });
        }

        [Fact]
        public void TestGetAndListDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestGetAndListDatabase", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Begin creating some small databases to run the get/List tests on.
                //
                List<Task<Database>> createDbTasks = new List<Task<Database>>();
                for (int i = 0; i < 4; i++)
                {
                    string name = SqlManagementTestUtilities.GenerateName(testPrefix);
                    createDbTasks.Add(sqlClient.Databases.CreateOrUpdateAsync(resourceGroup.Name, server.Name, name,
                        new Database()
                        {
                            Location = server.Location
                        }));
                }

                // Wait for all databases to be created.
                IDictionary<string, Database> inputs =
                    Task.WhenAll(createDbTasks.ToArray())
                        .Result
                        .ToDictionary(
                            keySelector: d => d.Name,
                            elementSelector: d => d);

                // Get each database and compare to the results of create database
                //
                foreach (var db in inputs)
                {
                    var response = sqlClient.Databases.Get(resourceGroup.Name, server.Name, db.Key);
                    SqlManagementTestUtilities.ValidateDatabaseEx(db.Value, response);
                }

                // List all databases
                //
                var listResponse = sqlClient.Databases.ListByServer(resourceGroup.Name, server.Name);

                // Remove master database from the list
                listResponse = listResponse.Where(db => db.Name != "master");
                Assert.Equal(inputs.Count(), listResponse.Count());
                foreach(var db in listResponse)
                {
                    SqlManagementTestUtilities.ValidateDatabase(inputs[db.Name], db, db.Name);
                }

                // List databases with filter
                //
                listResponse = sqlClient.Databases.ListByServer(resourceGroup.Name, server.Name, filter: "properties/edition ne 'System'");
                Assert.Equal(inputs.Count(), listResponse.Count());
                foreach (var db in listResponse)
                {
                    SqlManagementTestUtilities.ValidateDatabase(inputs[db.Name], db, db.Name);
                }
            });
        }
        
        [Fact]
        public void TestRemoveDatabaseFromPool()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestRemoveDatabaseFromPool", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create an elastic pool
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

                // Create a database in first elastic pool
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    ElasticPoolName = epName
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Remove the database from the pool
                dbInput = new Database()
                {
                    Location = server.Location,
                    RequestedServiceObjectiveName = ServiceObjectiveName.Basic
                };
                var dbResult = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                Assert.Equal(null, dbResult.ElasticPoolName);
            });
        }
    }
}
