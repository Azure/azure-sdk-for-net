
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseCrudScenarioTests
    {
        [Fact]
        public void TestCreateDropDatabase()
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

                // Create database only required parameters
                //
                string dbName = SqlManagementTestUtilities.GenerateName();
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Create a database with all parameters specified
                // 
                dbName = SqlManagementTestUtilities.GenerateName();
                var db2Input = new Database()
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
                dbName = SqlManagementTestUtilities.GenerateName();
                var db3Input = new Database()
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
                dbName = SqlManagementTestUtilities.GenerateName();
                var db4Input = new Database()
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
                dbName = SqlManagementTestUtilities.GenerateName();
                var db5Input = new Database()
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
            }
        }

        [Fact]
        public void TestRenameDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create database only required parameters
                string dbName = SqlManagementTestUtilities.GenerateName();
                Database db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Rename
                string newSuffix = "_renamed";
                string newName = db1.Name + newSuffix;
                string newId = db1.Id + newSuffix;
                sqlClient.Databases.Rename(resourceGroup.Name, server.Name, dbName, new ResourceMoveDefinition
                {
                    Id = newId
                });

                // Get database at its new id
                Database db2 = sqlClient.Databases.Get(resourceGroup.Name, server.Name, newName);
                Assert.Equal(newId, db2.Id);
            }
        }

        [Fact]
        public void TestUpdateDatabaseWithCreateOrUpdate()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // For 2014-04-01, PUT and PATCH are so similar in behavior that we can test them with common code.
                // This might not be the same for future api versions.
                Func<string, string, string, Database, Database> updateFunc = sqlClient.Databases.CreateOrUpdate;
                Func<Database> createModelFunc = () => new Database(server.Location);
                TestUpdateDatabase(sqlClient, resourceGroup, server, createModelFunc, updateFunc);
            };
        }

        [Fact]
        public void TestUpdateDatabaseWithUpdate()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // For 2014-04-01, PUT and PATCH are so similar in behavior that we can test them with common code.
                // This might not be the same for future api versions.
                Func<string, string, string, DatabaseUpdate, Database> updateFunc = sqlClient.Databases.Update;
                Func<DatabaseUpdate> createModelFunc = () => new DatabaseUpdate();
                TestUpdateDatabase(sqlClient, resourceGroup, server, createModelFunc, updateFunc);
            };
        }

        private void TestUpdateDatabase<TUpdateModel>(
            SqlManagementClient sqlClient,
            ResourceGroup resourceGroup,
            Server server,
            Func<TUpdateModel> createModelFunc,
            Func<string, string, string, TUpdateModel, Database> updateFunc)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>()
                {
                    { "tagKey1", "TagValue1" }
                };

            string dbName = SqlManagementTestUtilities.GenerateName("sqlcrudtest-");

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

            // Create zone redundant database
            //
            var dbInput2 = new Database()
            {
                Location = server.Location,
                Edition = "Premium",
                ZoneRedundant = true,
            };
            var db8 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput2);
            Assert.NotNull(db8);
            SqlManagementTestUtilities.ValidateDatabase(dbInput2, db8, dbName);

            // Upgrade Edition + SLO Name
            //
            dynamic updateEditionAndSloInput = createModelFunc();
            updateEditionAndSloInput.Edition = DatabaseEdition.Standard;
            updateEditionAndSloInput.RequestedServiceObjectiveName = ServiceObjectiveName.S0;
            var db2 = updateFunc(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput);
            SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput, db2, dbName);

            // Upgrade Edition + SLO ID
            //
            dynamic updateEditionAndSloInput2 = createModelFunc();
            updateEditionAndSloInput2.Edition = SqlTestConstants.DefaultDatabaseEdition;
            updateEditionAndSloInput2.RequestedServiceObjectiveId = ServiceObjectiveId.Basic;
            var db3 = updateFunc(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput2);
            SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput2, db3, dbName);

            // Upgrade Edition
            //
            dynamic updateEditionInput = createModelFunc();
            updateEditionInput.Edition = DatabaseEdition.Premium;
            var db4 = updateFunc(resourceGroup.Name, server.Name, dbName, updateEditionInput);
            SqlManagementTestUtilities.ValidateDatabase(updateEditionInput, db4, dbName);

            // Upgrade SLO ID & Slo Name
            //
            dynamic updateSloInput2 = createModelFunc();
            updateSloInput2.RequestedServiceObjectiveName = ServiceObjectiveName.P2;
            updateSloInput2.RequestedServiceObjectiveId = ServiceObjectiveId.P2;
            var db5 = updateFunc(resourceGroup.Name, server.Name, dbName, updateSloInput2);
            SqlManagementTestUtilities.ValidateDatabase(updateSloInput2, db5, dbName);

            // Sometimes we get CloudException "Operation on server '{0}' and database '{1}' is in progress."
            // Mitigate by adding brief sleep while recording
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            // Update max size
            //
            dynamic updateMaxSize = createModelFunc();
            updateMaxSize.MaxSizeBytes = (250 * 1024L * 1024L * 1024L).ToString();
            var db6 = updateFunc(resourceGroup.Name, server.Name, dbName, updateMaxSize);
            SqlManagementTestUtilities.ValidateDatabase(updateMaxSize, db6, dbName);

            // Update tags
            //
            dynamic updateTags = createModelFunc();
            updateTags.Tags = new Dictionary<string, string> { { "asdf", "zxcv" } };
            var db7 = updateFunc(resourceGroup.Name, server.Name, dbName, updateTags);
            SqlManagementTestUtilities.ValidateDatabase(updateTags, db7, dbName);

            // Update Zone Redundancy
            //
            dynamic updateZoneRedundant = createModelFunc();
            updateZoneRedundant.Edition = "Premium";
            updateZoneRedundant.ZoneRedundant = true;
            var db9 = updateFunc(resourceGroup.Name, server.Name, dbName, updateZoneRedundant);
            SqlManagementTestUtilities.ValidateDatabase(updateZoneRedundant, db9, dbName);
        }

        [Fact]
        public async Task TestCancelDatabaseOperation()
        {
            string testPrefix = "sqldblistcanceloperation-";
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup("North Europe");
                Server server = context.CreateServer(resourceGroup, "northeurope");
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create database only required parameters
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    RequestedServiceObjectiveName = ServiceObjectiveName.S0,
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Start updateslo operation
                //
                var dbUpdateResponse = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    RequestedServiceObjectiveName = ServiceObjectiveName.P2,
                    Location = server.Location,
                });
                TestUtilities.Wait(TimeSpan.FromSeconds(3));

                // Get the updateslo operation
                //
                AzureOperationResponse<IPage<DatabaseOperation>> response = sqlClient.DatabaseOperations.ListByDatabaseWithHttpMessagesAsync(
                    resourceGroup.Name, server.Name, dbName).Result;
                Assert.Equal(response.Response.StatusCode, HttpStatusCode.OK);
                IList<DatabaseOperation> responseObject = response.Body.ToList();
                Assert.Equal(responseObject.Count(), 1);

                // Cancel the database updateslo operation
                //
                string requestId = responseObject[0].Name;
                sqlClient.DatabaseOperations.Cancel(resourceGroup.Name, server.Name, dbName, Guid.Parse(requestId));

                CloudException ex = await Assert.ThrowsAsync<CloudException>(() => sqlClient.GetPutOrPatchOperationResultAsync(dbUpdateResponse.Result, new Dictionary<string, List<string>>(), CancellationToken.None));
                Assert.Contains("Long running operation failed with status 'Canceled'", ex.Message);

                // Make sure the database is not updated due to cancel operation
                //
                var dbGetResponse = sqlClient.Databases.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(dbGetResponse.ServiceLevelObjective, ServiceObjectiveName.S0);
            }
        }

        [Fact]
        public void TestGetAndListDatabase()
        {
            string testPrefix = "sqlcrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create some small databases to run the get/List tests on.
                Database[] databases = SqlManagementTestUtilities.CreateDatabasesAsync(
                    sqlClient, resourceGroup.Name, server, testPrefix, 4).Result;

                // Organize into a dictionary for better lookup later
                IDictionary<string, Database> inputs = databases.ToDictionary(
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
            }
        }
        
        [Fact]
        public void TestRemoveDatabaseFromPool()
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
            }
        }

        [Fact]
        public void TestDatabaseTransparentDataEncryptionConfiguration()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create database only required parameters
                //
                string dbName = SqlManagementTestUtilities.GenerateName();
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Get TDE config
                // Recently changed to be enabled by default
                var config = sqlClient.TransparentDataEncryptions.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(TransparentDataEncryptionStatus.Enabled, config.Status);

                // Update TDE config
                config.Status = TransparentDataEncryptionStatus.Disabled;

                // Sometimes the config is still being updated from the previous PUT, so execute with retry

                SqlManagementTestUtilities.ExecuteWithRetry(() =>
                {
                    config = sqlClient.TransparentDataEncryptions.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, config);
                },
                TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(5),
                (CloudException e) =>
                {
                    return e.Response.StatusCode == HttpStatusCode.Conflict;
                });

                Assert.Equal(TransparentDataEncryptionStatus.Disabled, config.Status);
            }
        }
    }
}
