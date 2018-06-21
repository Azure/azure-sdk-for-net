// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseRestoreScenarioTests
    {
        [Fact]
        public void TestDatabasePointInTimeRestore()
        {
            // Warning: This test takes around 20 minutes to run in record mode.

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Database db1 = CreateDatabaseAndWaitUntilBackupCreated(
                    sqlClient,
                    resourceGroup,
                    server,
                    dbName: SqlManagementTestUtilities.GenerateName());

                // Create a new database that is the first database restored to an earlier point in time
                string db2Name = SqlManagementTestUtilities.GenerateName();
                Database db2Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.PointInTimeRestore,
                    RestorePointInTime = db1.EarliestRestoreDate.Value,
                    SourceDatabaseId = db1.Id
                };
                Database db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, db2Name, db2Input);
                Assert.NotNull(db2);
                SqlManagementTestUtilities.ValidateDatabase(db2Input, db2, db2Name);
            }
        }

        [Fact]
        public void TestDatabaseRestore()
        {
            // Warning: This test takes around 20 minutes to run in record mode.

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                Database db1 = CreateDatabaseAndWaitUntilBackupCreated(
                    sqlClient,
                    resourceGroup,
                    server,
                    dbName: SqlManagementTestUtilities.GenerateName());

                // Delete the original database
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db1.Name);

                // Wait until the final backup is created and the restorable dropped database exists.
                // This could be up to 10 minutes after the database is deleted, and the database must already
                // have a backup (which was accomplished by the previous wait period). Let's wait up to 15
                // just to give it a little more room.
                IEnumerable<RestorableDroppedDatabase> droppedDatabases;
                DateTime startTime = DateTime.UtcNow;
                TimeSpan timeout = TimeSpan.FromMinutes(15);
                do
                {
                    droppedDatabases = sqlClient.RestorableDroppedDatabases.ListByServer(resourceGroup.Name, server.Name);

                    if (droppedDatabases.Any())
                    {
                        // Dropped database now exists. Exit polling loop.
                        break;
                    }

                    // Sleep if we are running live to avoid hammering the server.
                    // No need to sleep if we are playing back the recording.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                } while (DateTime.UtcNow < startTime + timeout);

                // Assert that we found a restorable db before timeout ended.
                Assert.True(droppedDatabases.Any(), "No dropped databases were found after waiting for " + timeout);

                // The original database should now exist as a restorable dropped database
                var droppedDatabase = droppedDatabases.Single();
                Assert.StartsWith(db1.Name, droppedDatabase.Name);

                // Restore the deleted database using restorable dropped database id
                //   In new DB API (Version 2017), if use restorable dropped database id, need to specify the RestorableDroppedDatabaseId,
                //       which include the source database id and deletion time
                var db3Name = SqlManagementTestUtilities.GenerateName();
                var db3Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.Restore,
                    RestorableDroppedDatabaseId = droppedDatabase.Id,
                    RestorePointInTime = droppedDatabase.EarliestRestoreDate // optional param for Restore
                };
                var db3Response = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db3Name, db3Input);

                // Concurrently (to make test faster) also restore the deleted database using its original id
                // and deletion date
                var db4Name = SqlManagementTestUtilities.GenerateName();
                var db4Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.Restore,
                    SourceDatabaseId = db1.Id,
                    SourceDatabaseDeletionDate = droppedDatabase.DeletionDate,
                    RestorePointInTime = droppedDatabase.EarliestRestoreDate // optional param for Restore
                };
                var db4Response = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db4Name, db4Input);

                // Wait for completion
                sqlClient.GetPutOrPatchOperationResultAsync(db3Response.Result, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();
                sqlClient.GetPutOrPatchOperationResultAsync(db4Response.Result, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();
            }
        }

        private static Database CreateDatabaseAndWaitUntilBackupCreated(
            SqlManagementClient sqlClient,
            ResourceGroup resourceGroup,
            Server server,
            string dbName)
        {
            // Create database with only required parameters
            var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database
            {
                Location = server.Location,
            });
            Assert.NotNull(db);

            // If earliest restore time is in the future, we need to wait until then.
            // Add some padding in case of clock skew between Azure and this machine.
            // Beware this wait is at least 10 minutes long. Note that this is specifically
            // written so that it will actually be 0 wait when in playback mode.
            DateTime waitUntilTime = db.EarliestRestoreDate.Value.AddMinutes(1);
            TimeSpan waitDelay = waitUntilTime.Subtract(DateTime.UtcNow);
            if (waitDelay > TimeSpan.Zero)
            {
                Thread.Sleep(waitDelay);
            }

            return db;
        }

        [Fact]
        public void TestLongTermRetentionV2Policies()
        {
            string defaultPolicy = "PT0S";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(), new Database { Location = server.Location });

                // Get the policy and verify it is the default policy
                //
                BackupLongTermRetentionPolicy policy = sqlClient.BackupLongTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultPolicy, policy.WeeklyRetention);
                Assert.Equal(defaultPolicy, policy.MonthlyRetention);
                Assert.Equal(defaultPolicy, policy.YearlyRetention);
                Assert.Equal(0, policy.WeekOfYear);

                // Set the retention policy to two weeks for the weekly retention policy
                //
                BackupLongTermRetentionPolicy parameters = new BackupLongTermRetentionPolicy(weeklyRetention: "P2W");
                sqlClient.BackupLongTermRetentionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, database.Name, parameters);

                // Get the policy and verify the weekly policy is two weeks but all the rest stayed the same
                //
                policy = sqlClient.BackupLongTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.WeeklyRetention, policy.WeeklyRetention);
                Assert.Equal(defaultPolicy, policy.MonthlyRetention);
                Assert.Equal(defaultPolicy, policy.YearlyRetention);
                Assert.Equal(0, policy.WeekOfYear);
            }
        }

        [Fact]
        public void TestLongTermRetentionV2Backups()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(), new Database { Location = server.Location });

                // Get the backups under the server and database. Assert there are no backups returned.
                // Note: While we call ListByLocation, we can't guarantee there are no backups under that location for the subscription.
                //
                IPage<LongTermRetentionBackup> backups = sqlClient.LongTermRetentionBackups.ListByLocation(server.Location);
                backups = sqlClient.LongTermRetentionBackups.ListByServer(server.Location, server.Name);
                Assert.True(backups.Count() == 0);
                backups = sqlClient.LongTermRetentionBackups.ListByDatabase(server.Location, server.Name, database.Name);
                Assert.True(backups.Count() == 0);
                Assert.Throws(typeof(CloudException), () => sqlClient.LongTermRetentionBackups.Get(server.Location, server.Name, database.Name, "backup"));
            }
        }


        [Fact]
        public void TestShortTermRetentionPolicyOnPremium()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Create a Premium DB so it defaults to 35 days retention.
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1)
                    });

                // Decrease retention period to 8 days and verfiy that it was updated.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);

                // Increase retention period to 35 days again and verfiy that it was updated.
                parameters = new BackupShortTermRetentionPolicy(retentionDays: 35);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnBasic()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                int basicRetention = 7;

                // Create a Basic DB so it defaults to 7 days retention.
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.Basic)
                    });

                // Attempt to increase retention period to 8 days and verfiy that the operation fails.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(basicRetention, policy.RetentionDays);

                // Attempt to dncrease retention period to 3 days and verify operation failure.
                parameters = new BackupShortTermRetentionPolicy(retentionDays: 3);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(basicRetention, policy.RetentionDays);
            }
        }

        [Fact(Skip = "Manual test due to long setup time required (over 18 hours).")]
        public void TestLongTermRetentionV2Crud()
        {
            // MANUAL INSTRUCTIONS
            // Create a server and database and fill in the appropriate information below
            // Set the weekly retention on the database so that the first backup gets picked up
            // Wait about 18 hours until it gets properly copied and you see the backup when run get backups
            //
            string locationName = "";
            string resourceGroupName = "";
            string serverName = "";
            string databaseName = "";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.Get(resourceGroupName, serverName, databaseName);

                // Set the retention policy to two weeks for the weekly retention policy
                //
                Microsoft.Azure.Management.Sql.Models.BackupLongTermRetentionPolicy parameters = new Microsoft.Azure.Management.Sql.Models.BackupLongTermRetentionPolicy(weeklyRetention: "P2W");
                var policyResult = sqlClient.BackupLongTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, parameters).Result;
                sqlClient.GetPutOrPatchOperationResultAsync(policyResult, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();

                // Get the policy and verify the weekly policy is two weeks
                //
                Microsoft.Azure.Management.Sql.Models.BackupLongTermRetentionPolicy policy = sqlClient.BackupLongTermRetentionPolicies.Get(resourceGroupName, serverName, databaseName);
                Assert.Equal(parameters.WeeklyRetention, policy.WeeklyRetention);

                // Get the backups under the location, server, and database. Assert there is at least one backup for each call.
                //
                IPage<LongTermRetentionBackup> backups = sqlClient.LongTermRetentionBackups.ListByLocation(locationName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionBackups.ListByServer(locationName, serverName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionBackups.ListByDatabase(locationName, serverName, databaseName);
                Assert.True(backups.Count() >= 1);

                // Get a specific backup using the previous call
                //
                LongTermRetentionBackup backup = sqlClient.LongTermRetentionBackups.Get(locationName, serverName, databaseName, backups.First().Name);
                Assert.NotNull(backup);

                // Restore the backup
                //
                Database restoredDatabase = sqlClient.Databases.CreateOrUpdate(
                    resourceGroupName, serverName, databaseName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new Database
                    {
                        Location = locationName,
                        CreateMode = CreateMode.RestoreLongTermRetentionBackup,
                        LongTermRetentionBackupResourceId = backup.Id
                    });

                // Delete the backup.
                //
                var deleteResult = sqlClient.LongTermRetentionBackups.BeginDeleteWithHttpMessagesAsync(locationName, serverName, databaseName, backup.Name).Result;
                sqlClient.GetPutOrPatchOperationResultAsync(deleteResult, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();

                // Verify the backup is gone.
                //
                try
                {
                    sqlClient.LongTermRetentionBackups.Get(locationName, serverName, databaseName, backup.Name);
                }
                catch (CloudException e)
                {
                    Assert.Contains(string.Format("'{0}' was not found.", backup.Name), e.Message);
                }

                // Set the retention policy back to one week for the weekly retention policy
                //
                parameters = new Microsoft.Azure.Management.Sql.Models.BackupLongTermRetentionPolicy(weeklyRetention: "P1W");
                policyResult = sqlClient.BackupLongTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, serverName, databaseName, parameters).Result;
                sqlClient.GetPutOrPatchOperationResultAsync(policyResult, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();

                // Get the policy and verify the weekly policy is two weeks
                //
                policy = sqlClient.BackupLongTermRetentionPolicies.Get(resourceGroupName, serverName, databaseName);
                Assert.Equal(parameters.WeeklyRetention, policy.WeeklyRetention);
            }
        }

        [Fact(Skip = "Manual test due to long setup time required (potentially several hours).")]
        public void TestDatabaseGeoRecovery()
        {
            // There can be a delay of several hours before the fist geo recoverable database backup
            // is available, which is not appropriate for a scenario test. Therefore this test
            // must run against a pre-created server that should have at least one database that
            // was created a few hours ago.

            // Pre-created database info
            string resourceGroupName = "jaredmoo_cli";
            string serverName = "jaredmoocli";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // List geo recoverable database backups
                IEnumerable<RecoverableDatabase> recoverableDatabases =
                    sqlClient.RecoverableDatabases.ListByServer(resourceGroupName, serverName);
                Assert.True(recoverableDatabases.Any(), "No recoverable databases found.");

                // Get geo recoverable database backup
                RecoverableDatabase recoverableDatabase = sqlClient.RecoverableDatabases.Get(
                    resourceGroupName, serverName, recoverableDatabases.First().Name);

                // Create database from geo recoverable database backup
                Server server = sqlClient.Servers.Get(resourceGroupName, serverName);
                Database newDatabase = sqlClient.Databases.CreateOrUpdate(
                    resourceGroupName, serverName, databaseName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new Database
                    {
                        Location = server.Location,
                        CreateMode = CreateMode.Recovery,
                        SourceDatabaseId = recoverableDatabase.Id
                    });
            }
        }

        [Fact]
        public void TestDatabaseRestorePoint()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                string restoreLabel = "restorePointLabel";

                // Create database with only required parameters
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.DW100)
                    });
                Assert.NotNull(db);

                CreateDatabaseRestorePointDefinition restoreDefinition = new CreateDatabaseRestorePointDefinition { RestorePointLabel = restoreLabel };

                RestorePoint postResponse = sqlClient.RestorePoints.Create(
                        resourceGroup.Name,
                        server.Name,
                        db.Name,
                        restoreDefinition);

                Assert.True(postResponse.RestorePointType == RestorePointType.DISCRETE);
                Assert.True(postResponse.RestorePointLabel == restoreLabel);
                Assert.True(!string.IsNullOrWhiteSpace(postResponse.RestorePointCreationDate.ToString()));

                IEnumerable<RestorePoint> listResponse =
                    sqlClient.RestorePoints.ListByDatabase(
                        resourceGroup.Name,
                        server.Name,
                        db.Name);

                IEnumerable<RestorePoint> restorePointList = listResponse.ToList<RestorePoint>();

                Assert.True(restorePointList.Any());

                RestorePoint getResponse =
                    sqlClient.RestorePoints.Get(
                        resourceGroup.Name,
                        server.Name,
                        db.Name,
                        postResponse.Name);

                Assert.True(getResponse.RestorePointType == RestorePointType.DISCRETE);
                Assert.True(!string.IsNullOrWhiteSpace(getResponse.RestorePointCreationDate.ToString()));
                Assert.True(getResponse.Name == postResponse.Name);

                sqlClient.RestorePoints.Delete(
                    resourceGroup.Name,
                    server.Name,
                    db.Name,
                    getResponse.Name);

                IEnumerable<RestorePoint> listResponseAfterDelete =
                    sqlClient.RestorePoints.ListByDatabase(
                        resourceGroup.Name,
                        server.Name,
                        db.Name);

                Assert.True(!listResponseAfterDelete.Any()
                    || !listResponseAfterDelete.Where(x => x.Name == postResponse.Name).Any());
            }
        }
    }
}
