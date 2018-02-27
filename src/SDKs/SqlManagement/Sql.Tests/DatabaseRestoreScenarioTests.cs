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
                var db3Name = SqlManagementTestUtilities.GenerateName();
                var db3Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.Restore,
                    SourceDatabaseId = droppedDatabase.Id,
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
        public void TestLongTermRetentionCrud()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                RecoveryServicesClient recoveryClient = context.GetClient<RecoveryServicesClient>();
                RecoveryServicesBackupClient backupClient = context.GetClient<RecoveryServicesBackupClient>();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create recovery services vault
                Vault vault = recoveryClient.Vaults.CreateOrUpdate(
                    resourceGroup.Name,
                    vaultName: SqlManagementTestUtilities.GenerateName(),
                    vault: new Vault(resourceGroup.Location)
                    {
                        Sku = new Microsoft.Azure.Management.RecoveryServices.Models.Sku(SkuName.Standard),
                        Properties = new VaultProperties()
                    });

                // Create recovery services backup policy
                AzureOperationResponse<ProtectionPolicyResource> policyResponse =
                    backupClient.ProtectionPolicies.CreateOrUpdateWithHttpMessagesAsync(
                        vault.Name,
                        resourceGroup.Name,
                        policyName: SqlManagementTestUtilities.GenerateName(),
                        resourceProtectionPolicy: new ProtectionPolicyResource
                        {
                            Properties = new AzureSqlProtectionPolicy
                            {
                                RetentionPolicy = new SimpleRetentionPolicy
                                {
                                    RetentionDuration = new RetentionDuration
                                    {
                                        Count = 3,
                                        DurationType = RetentionDurationType.Weeks
                                    }
                                }
                            }
                        }).Result;
                ProtectionPolicyResource policy = backupClient.GetPutOrPatchOperationResultAsync(
                    policyResponse, new Dictionary<string, List<string>>(), CancellationToken.None).Result.Body;

                // Create server LTR backup vault
                Server server = context.CreateServer(resourceGroup);
                BackupLongTermRetentionVault serverVault = sqlClient.BackupLongTermRetentionVaults.CreateOrUpdate(
                    resourceGroup.Name, server.Name, new BackupLongTermRetentionVault
                    {
                        RecoveryServicesVaultResourceId = vault.Id
                    });

                // Get server LTR backup vault
                serverVault = sqlClient.BackupLongTermRetentionVaults.Get(resourceGroup.Name, server.Name);
                Assert.Equal(vault.Id, serverVault.RecoveryServicesVaultResourceId, ignoreCase: true);

                // List server LTR backup vaults
                IEnumerable<BackupLongTermRetentionVault> serverVaults = sqlClient.BackupLongTermRetentionVaults.ListByServer(resourceGroup.Name, server.Name);
                Assert.Single(serverVaults);
                Assert.Equal(vault.Id, serverVaults.Single().RecoveryServicesVaultResourceId, ignoreCase: true);

                // Create database LTR policy
                Database db = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, 
                    server.Name,
                    databaseName: SqlManagementTestUtilities.GenerateName(), 
                    parameters: new Database(resourceGroup.Location));
                BackupLongTermRetentionPolicy databasePolicy = sqlClient.BackupLongTermRetentionPolicies.CreateOrUpdate(
                    resourceGroup.Name, server.Name, db.Name, new BackupLongTermRetentionPolicy(
                        BackupLongTermRetentionPolicyState.Enabled,
                        policy.Id));

                // Get database LTR policy
                databasePolicy = sqlClient.BackupLongTermRetentionPolicies.Get(resourceGroup.Name, server.Name, db.Name);
                Assert.Equal(policy.Id, databasePolicy.RecoveryServicesBackupPolicyResourceId, ignoreCase: true);

                // List database LTR policies
                IEnumerable<BackupLongTermRetentionPolicy> databasePolicies = sqlClient.BackupLongTermRetentionPolicies.ListByDatabase(resourceGroup.Name, server.Name, db.Name);
                Assert.Single(databasePolicies);
                Assert.Equal(policy.Id, databasePolicies.Single().RecoveryServicesBackupPolicyResourceId, ignoreCase: true);

                // Update database LTR policy
                databasePolicy = sqlClient.BackupLongTermRetentionPolicies.CreateOrUpdate(
                    resourceGroup.Name, server.Name, db.Name, new BackupLongTermRetentionPolicy(
                        BackupLongTermRetentionPolicyState.Disabled,
                        policy.Id /* policy Id must be set even when disabling */));

                // Restore from LTR
                // Commented out because there can be a delay of several hours before the first
                // LTR backup is created. This code is just to show example.
                /*
                Database restoredDatabase = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, databaseName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new Database
                    {
                        Location = resourceGroup.Location,
                        CreateMode = CreateMode.RestoreLongTermRetentionBackup,
                        RecoveryServicesRecoveryPointResourceId = // recovery point resource id
                    });
                */
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
    }
}
