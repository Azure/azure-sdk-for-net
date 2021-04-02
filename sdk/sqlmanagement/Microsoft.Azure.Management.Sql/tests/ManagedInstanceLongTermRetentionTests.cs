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
    public class ManagedInstanceLongTermRetentionTests
    {
        [Fact]
        public void TestManagedInstanceLongTermRetentionPolicies()
        {
            // MANUAL TEST INSTRUCTIONS
            // PlayBack Mode:
            //     Make sure information below matches what is gets recorded in Session Records
            //
            string locationName = "southeastasia";
            string resourceGroupName = "sdk-test-rg";
            string managedInstanceName = "sdk-test-mi";
            string defaultPolicy = "PT0S";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                ManagedDatabase database = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroupName, managedInstanceName, SqlManagementTestUtilities.GenerateName(), new ManagedDatabase { Location = locationName });

                // Get the policy and verify it is the default policy
                //
                ManagedInstanceLongTermRetentionPolicy policy = sqlClient.ManagedInstanceLongTermRetentionPolicies.Get(resourceGroupName, managedInstanceName, database.Name);
                Assert.Equal(defaultPolicy, policy.WeeklyRetention);
                Assert.Equal(defaultPolicy, policy.MonthlyRetention);
                Assert.Equal(defaultPolicy, policy.YearlyRetention);
                Assert.Equal(0, policy.WeekOfYear);

                // Set the retention policy to two weeks for the weekly retention policy
                //
                ManagedInstanceLongTermRetentionPolicy parameters = new ManagedInstanceLongTermRetentionPolicy(weeklyRetention: "P2W");
                sqlClient.ManagedInstanceLongTermRetentionPolicies.CreateOrUpdate(resourceGroupName, managedInstanceName, database.Name, parameters);

                // Get the policy and verify the weekly policy is two weeks but all the rest stayed the same
                //
                policy = sqlClient.ManagedInstanceLongTermRetentionPolicies.Get(resourceGroupName, managedInstanceName, database.Name);
                Assert.Equal(parameters.WeeklyRetention, policy.WeeklyRetention);
                Assert.Equal(defaultPolicy, policy.MonthlyRetention);
                Assert.Equal(defaultPolicy, policy.YearlyRetention);
                Assert.Equal(0, policy.WeekOfYear);
            }
        }

        [Fact]
        public void TestManagedIntanceLongTermRetentionCrud()
        {
            // MANUAL TEST INSTRUCTIONS
            // PlayBack Mode:
            //     Make sure information below matches what is gets recorded in Session Records
            // Record Mode:
            //     Create a server and database and fill in the appropriate information below
            //     Set the weekly retention on the database so that the first backup gets picked up
            //     Wait about 18 hours until it gets properly copied and you see the backup when run get backups
            //     OR
            //     Use existing instance/database that already has LTR backups
            //
            string locationName = "southeastasia";
            string resourceGroupName = "sdk-test-rg";
            string managedInstanceName = "sdk-test-mi";
            string databaseName = "test";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                //ManagedDatabase database = sqlClient.ManagedDatabases.Get(resourceGroupName, managedInstanceName, databaseName);

                // Get the backups under the location, server, and database. Assert there is at least one backup for each call.
                //
                IPage<ManagedInstanceLongTermRetentionBackup> backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByLocation(locationName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByInstance(locationName, managedInstanceName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByDatabase(locationName, managedInstanceName, databaseName);
                Assert.True(backups.Count() >= 1);

                // Get a specific backup using the previous call
                //
                ManagedInstanceLongTermRetentionBackup backup = sqlClient.LongTermRetentionManagedInstanceBackups.Get(locationName, managedInstanceName, databaseName, backups.First().Name);
                Assert.NotNull(backup);

                // Restore the backup
                //
                ManagedDatabase restoredDatabase = sqlClient.ManagedDatabases.CreateOrUpdate(
                    resourceGroupName, managedInstanceName, databaseName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new ManagedDatabase
                    {
                        Location = locationName,
                        CreateMode = ManagedDatabaseCreateMode.RestoreLongTermRetentionBackup,
                        LongTermRetentionBackupResourceId = backup.Id
                    });
            }
        }

        [Fact]
        public void TestManagedInstanceLongTermRetentionResourceGroupBasedCrud()
        {
            // MANUAL TEST INSTRUCTIONS
            // PlayBack Mode:
            //     Make sure information below matches what is gets recorded in Session Records
            // Record Mode:
            //     Create a server and database and fill in the appropriate information below
            //     Set the weekly retention on the database so that the first backup gets picked up
            //     Wait about 18 hours until it gets properly copied and you see the backup when run get backups
            //     OR
            //     Use existing instance/database that already has LTR backups
            //
            string locationName = "southeastasia";
            string resourceGroupName = "sdk-test-rg";
            string managedInstanceName = "sdk-test-mi";
            string databaseName = "test";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                //ManagedDatabase database = sqlClient.ManagedDatabases.Get(resourceGroupName, managedInstanceName, databaseName);

                // Get the backups under the location, server, and database. Assert there is at least one backup for each call.
                //
                IPage<ManagedInstanceLongTermRetentionBackup> backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByResourceGroupLocation(resourceGroupName, locationName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByResourceGroupInstance(resourceGroupName, locationName, managedInstanceName);
                Assert.True(backups.Count() >= 1);
                backups = sqlClient.LongTermRetentionManagedInstanceBackups.ListByResourceGroupDatabase(resourceGroupName, locationName, managedInstanceName, databaseName);
                Assert.True(backups.Count() >= 1);

                // Get a specific backup using the previous call
                //
                ManagedInstanceLongTermRetentionBackup backup = sqlClient.LongTermRetentionManagedInstanceBackups.GetByResourceGroup(resourceGroupName, locationName, managedInstanceName, databaseName, backups.First().Name);
                Assert.NotNull(backup);

                // Restore the backup
                //
                ManagedDatabase restoredDatabase = sqlClient.ManagedDatabases.CreateOrUpdate(
                    resourceGroupName, managedInstanceName, databaseName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new ManagedDatabase
                    {
                        Location = locationName,
                        CreateMode = ManagedDatabaseCreateMode.RestoreLongTermRetentionBackup,
                        LongTermRetentionBackupResourceId = backup.Id
                    });

                // Delete the backup.
                //
                sqlClient.LongTermRetentionManagedInstanceBackups.DeleteByResourceGroupWithHttpMessagesAsync(resourceGroupName, locationName, managedInstanceName, databaseName, backup.Name);
            }
        }
    }
}
