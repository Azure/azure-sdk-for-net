using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Collation = "SQL_Latin1_General_CP1_CI_AS",
                    Edition = "Basic",
                    MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    RequestedServiceObjectiveName = "Basic",
                    RequestedServiceObjectiveId = Guid.Parse("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"),
                    Tags = tags,
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
                    RequestedServiceObjectiveId = Guid.Parse("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"),
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
                    RequestedServiceObjectiveName = "Basic",
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
                    Edition = "Basic",
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
                    Collation = "SQL_Latin1_General_CP1_CI_AS",
                    Edition = "Basic",
                    MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    RequestedServiceObjectiveName = "Basic",
                    RequestedServiceObjectiveId = Guid.Parse("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"),
                    Tags = tags,
                };
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db1);
                SqlManagementTestUtilities.ValidateDatabase(dbInput, db1, dbName);

                // Upgrade Edition + SLO Name
                //
                var updateEditionAndSloInput = new Database()
                {
                    Edition = "Standard",
                    RequestedServiceObjectiveName = "S0",
                    Location = server.Location
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput, db2, dbName);

                // Upgrade Edition + SLO ID
                //
                var updateEditionAndSloInput2 = new Database()
                {
                    Edition = "Basic",
                    RequestedServiceObjectiveId = Guid.Parse("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"),
                    Location = server.Location
                };
                var db3 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput2);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput2, db3, dbName);

                // Upgrade Edition
                //
                var updateEditionInput = new Database()
                {
                    Edition = "Premium",
                    Location = server.Location
                };
                var db4 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updateEditionInput);
                SqlManagementTestUtilities.ValidateDatabase(updateEditionInput, db4, dbName);

                // Upgrade SLO ID & Slo Name
                //
                var updateSloInput2 = new Database()
                {
                    RequestedServiceObjectiveName = "P2",
                    RequestedServiceObjectiveId = Guid.Parse("a7d1b92d-c987-4375-b54d-2b1d0e0f5bb0"),
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
                Dictionary<string, Database> inputs = new Dictionary<string, Database>();

                // Create some small databases to run the get/List tests on.
                for (int i = 0; i < 4; i++)
                {
                    string name = SqlManagementTestUtilities.GenerateName(testPrefix);
                    inputs.Add(
                        name,
                        sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, name, 
                        new Database() {
                            Location = server.Location
                        }));
                }

                // Get each database and compare to the results of create database
                //
                foreach (var db in inputs)
                {
                    var response = sqlClient.Databases.Get(resourceGroup.Name, server.Name, db.Key);
                    SqlManagementTestUtilities.ValidateDatabaseEx(db.Value, response);
                }

                var listResponse = sqlClient.Databases.ListByServer(resourceGroup.Name, server.Name);

                // Remove master database from the list
                listResponse = listResponse.Where(db => db.Name != "master");
                Assert.Equal(inputs.Count(), listResponse.Count());
                
                foreach(var db in listResponse)
                {
                    SqlManagementTestUtilities.ValidateDatabase(inputs[db.Name], db, db.Name);
                }
            });
        }
    }
}
