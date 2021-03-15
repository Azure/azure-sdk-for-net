// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class DatabaseLongTermRetentionBackupsTests
    {
        [Fact(Skip = "Manual test due to long setup time required (over 18 hours).")]        public void TestUpdateLongTermRetentionBackup()
        {
            // MANUAL TEST INSTRUCTIONS
            // PlayBack Mode: 
            //     Remove skip flag
            // Record Mode:
            //     Create a server and database and fill in the appropriate information below
            //     Set the weekly retention on the database so that the first backup gets picked up
            //     Wait about 18 hours until it gets properly copied and you see the backup when run get backups
            //
            string locationName = "Southeast Asia";
            string resourceGroupName = "testrg";
            string serverName = "ayang-stage-seas";
            string databaseName = "ltr3";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.Get(resourceGroupName, serverName, databaseName);

                // Get backups under database
                //
                IPage<LongTermRetentionBackup> backups = sqlClient.LongTermRetentionBackups.ListByResourceGroupDatabase(resourceGroupName, locationName, serverName, databaseName);
                Assert.True(backups.Count() >= 1);

                // Get a single backup using the previous call
                //
                LongTermRetentionBackup backup = sqlClient.LongTermRetentionBackups.GetByResourceGroup(resourceGroupName, locationName, serverName, databaseName, backups.First().Name);
                Assert.NotNull(backup);

                // Update the Backup Storage Redundancy of the backup
                //
                UpdateLongTermRetentionBackupParameters updateParameters = new UpdateLongTermRetentionBackupParameters(requestedBackupStorageRedundancy: "Geo");
                LongTermRetentionBackupOperationResult restoredDatabase = sqlClient.LongTermRetentionBackups.Update(locationName, serverName, databaseName, backup.Name, updateParameters); 
            }
        }

        [Fact(Skip = "Manual test due to long setup time required (over 18 hours).")]
        public void TestCopyLongTermRetentionBackup()
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
            string subscriptionId = "01c4ec88-e179-44f7-9eb0-e9719a5087ab"; 
            string resourceGroupName = "testrg";
            string sourceServerName = "ayang-stage-seas";
            string sourceDatabaseName = "ltr3";
            string targetServerName = "ayang-stage-seas-1";
            string targetDatabaseName = "ltr1";


            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.Get(resourceGroupName, sourceServerName, sourceDatabaseName);

                // Get backups under database
                //
                IPage<LongTermRetentionBackup> backups = sqlClient.LongTermRetentionBackups.ListByResourceGroupDatabase(resourceGroupName, locationName, sourceServerName, sourceDatabaseName);
                Assert.True(backups.Count() >= 1);

                // Get a single backup using the previous call
                //
                LongTermRetentionBackup backup = sqlClient.LongTermRetentionBackups.GetByResourceGroup(resourceGroupName, locationName, sourceServerName, sourceDatabaseName, backups.First().Name);
                Assert.NotNull(backup);

                // Copy the backup to target database 
                //
                string targetServerResourceId = String.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}", subscriptionId, resourceGroupName, targetServerName);
                CopyLongTermRetentionBackupParameters copyParameters = new CopyLongTermRetentionBackupParameters(
                    targetSubscriptionId: subscriptionId,
                    targetResourceGroup: resourceGroupName,
                    targetServerResourceId: targetServerResourceId,
                    targetDatabaseName: targetDatabaseName);
                LongTermRetentionBackupOperationResult restoredDatabase = sqlClient.LongTermRetentionBackups.Copy(locationName, sourceServerName, sourceDatabaseName, backup.Name, copyParameters);
            }
        }
    }
}
