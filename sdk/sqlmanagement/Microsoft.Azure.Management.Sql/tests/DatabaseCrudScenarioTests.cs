
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
                    Sku = SqlTestConstants.DefaultDatabaseSku(),
                    MaxSizeBytes = 2 * 1024L * 1024L * 1024L,
                    Tags = tags,
                    CreateMode = "Default",
                    SampleName = SampleName.AdventureWorksLT,
                    StorageAccountType = "GRS",
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db2Input);
                Assert.NotNull(db2);
                SqlManagementTestUtilities.ValidateDatabase(db2Input, db2, dbName);

                // Service Objective Name
                //
                dbName = SqlManagementTestUtilities.GenerateName();
                var db4Input = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.S0),
                    Tags = tags,
                };
                var db4 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db4Input);
                Assert.NotNull(db4);
                SqlManagementTestUtilities.ValidateDatabase(db4Input, db4, dbName);

                // Create database with Serverless specific parameters
                //
                dbName = SqlManagementTestUtilities.GenerateName();
                var db5Input = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku("GP_S_Gen5_2"),
                    Tags = tags,
                    AutoPauseDelay = 360,
                    MinCapacity = 0.5,
                };
                var db5 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db5Input);
                Assert.NotNull(db5);
                SqlManagementTestUtilities.ValidateDatabase(db5Input, db5, dbName);

                // ReadScale properties
                //
                dbName = SqlManagementTestUtilities.GenerateName();
                var db6Input = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1),
                    ReadScale = "Enabled",
                };
                var db6 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db6Input);
                Assert.NotNull(db6);
                SqlManagementTestUtilities.ValidateDatabase(db6Input, db6, dbName);

                dbName = SqlManagementTestUtilities.GenerateName();
                var db7Input = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku("HS_Gen5_4", "Hyperscale"),
                    HighAvailabilityReplicaCount = 4,
                };
                var db7 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db7Input);
                Assert.NotNull(db7);
                SqlManagementTestUtilities.ValidateDatabase(db7Input, db7, dbName);

                dbName = SqlManagementTestUtilities.GenerateName();
                var db8Input = new Database()
                {
                    Location = server.Location,
                    StorageAccountType = "GRS",
                };
                var db8 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db8Input);
                Assert.NotNull(db8);
                SqlManagementTestUtilities.ValidateDatabase(db8Input, db8, dbName);

                dbName = SqlManagementTestUtilities.GenerateName();
                var db9Input = new Database()
                {
                    Location = server.Location,
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1),
                    MaintenanceConfigurationId = SqlManagementTestUtilities.GetTestMaintenanceConfigurationId(sqlClient.SubscriptionId),
                };
                var db9 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db9Input);
                Assert.NotNull(db9);
                SqlManagementTestUtilities.ValidateDatabase(db9Input, db9, dbName);

                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db1.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db2.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db4.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db5.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db6.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db7.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db8.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db9.Name);
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

                // Rename using id
                string newSuffix = "_renamed";
                string newName = db1.Name + newSuffix;
                string newId = db1.Id + newSuffix;
                sqlClient.Databases.Rename(resourceGroup.Name, server.Name, dbName, new ResourceMoveDefinition
                {
                    Id = newId
                });

                // Get database at its new id
                Database newDb = sqlClient.Databases.Get(resourceGroup.Name, server.Name, newName);
                Assert.Equal(newId, newDb.Id);

                // Rename using new name
                string newSuffix2 = "2";
                string newName2 = newName + newSuffix2;
                string newId2 = newId + newSuffix2;
                sqlClient.Databases.Rename(resourceGroup.Name, server.Name, newName, newName2);

                // Get database at its new id
                Database newDb2 = sqlClient.Databases.Get(resourceGroup.Name, server.Name, newName2);
                Assert.Equal(newId2, newDb2.Id);
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
                MaxSizeBytes = 2 * 1024L * 1024L * 1024L,
                Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.S0),
                ZoneRedundant = false,
                Tags = tags,
            };
            var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
            Assert.NotNull(db1);
            SqlManagementTestUtilities.ValidateDatabase(dbInput, db1, dbName);

            // Update Zone Redundancy
            //
            var dbInput2 = new Database()
            {
                Location = server.Location,
                Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1),
                ZoneRedundant = true,
            };
            var db8 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput2);
            Assert.NotNull(db8);
            SqlManagementTestUtilities.ValidateDatabase(dbInput2, db8, dbName);

            // Upgrade Edition + SLO Name
            //
            dynamic updateEditionAndSloInput = createModelFunc();
            updateEditionAndSloInput.Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.S0, "Standard");
            updateEditionAndSloInput.ZoneRedundant = false;
            var db2 = updateFunc(resourceGroup.Name, server.Name, dbName, updateEditionAndSloInput);
            SqlManagementTestUtilities.ValidateDatabase(updateEditionAndSloInput, db2, dbName);

            // Sometimes we get CloudException "Operation on server '{0}' and database '{1}' is in progress."
            // Mitigate by adding brief sleep while recording
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }

            // Update max size
            //
            dynamic updateMaxSize = createModelFunc();
            updateMaxSize.MaxSizeBytes = 250 * 1024L * 1024L * 1024L;
            var db6 = updateFunc(resourceGroup.Name, server.Name, dbName, updateMaxSize);
            SqlManagementTestUtilities.ValidateDatabase(updateMaxSize, db6, dbName);

            // Update tags
            //
            dynamic updateTags = createModelFunc();
            updateTags.Tags = new Dictionary<string, string> { { "asdf", "zxcv" } };
            var db7 = updateFunc(resourceGroup.Name, server.Name, dbName, updateTags);
            SqlManagementTestUtilities.ValidateDatabase(updateTags, db7, dbName);

            // Update maintenance
            //
            dynamic updateMaintnenace = createModelFunc();
            updateMaintnenace.Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.S2, "Standard");
            updateMaintnenace.MaintenanceConfigurationId = SqlManagementTestUtilities.GetTestMaintenanceConfigurationId(sqlClient.SubscriptionId);
            var db9 = updateFunc(resourceGroup.Name, server.Name, dbName, updateMaintnenace);
            SqlManagementTestUtilities.ValidateDatabase(updateMaintnenace, db9, dbName);
        }

        [Fact]
        public async Task TestCancelDatabaseOperation()
        {
            string testPrefix = "sqldblistcanceloperation-";
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup("West Europe");
                Server server = context.CreateServer(resourceGroup, "westeurope");
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
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.S0),
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Start updateslo operation
                //
                var dbUpdateResponse = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P2),
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
                IEnumerable<Database> listResponse = sqlClient.Databases.ListByServer(resourceGroup.Name, server.Name);

                // Remove master database from the list
                listResponse = listResponse.Where(db => db.Name != "master");
                Assert.Equal(inputs.Count(), listResponse.Count());
                foreach(var db in listResponse)
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
                    Sku = SqlTestConstants.DefaultElasticPoolSku(),
                    Tags = tags,
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
                    ElasticPoolId = returnedEp.Id
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Remove the database from the pool
                dbInput = new Database()
                {
                    Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.Basic),
                    Location = server.Location,
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
