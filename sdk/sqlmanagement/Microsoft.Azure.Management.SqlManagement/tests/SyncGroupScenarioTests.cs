// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Xunit;
using Microsoft.Rest.Azure;

namespace Sql.Tests
{
    public class SyncGroupScenarioTests
    {
        [Fact]
        public void SyncGroupCRUDTest()
        {
            string testPrefix = "syncgroupcrudtest-";
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                // Create sync database
                string syncDatabaseName = SqlManagementTestUtilities.GenerateName(testPrefix + "sync");
                Database syncDatabase = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, syncDatabaseName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(syncDatabase);
                Assert.NotNull(syncDatabase.Id);

                // Create database
                string testDatabaseName = SqlManagementTestUtilities.GenerateName(testPrefix + "test");
                Database testDatabase = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, testDatabaseName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(testDatabase);

                // Create sync group
                string syncGroupName = SqlManagementTestUtilities.GenerateName(testPrefix + "syncgroup");
                int interval1 = -1; // Manual
                string conflictPolicy = SyncConflictResolutionPolicy.MemberWin;
                SyncGroup createSyncGroup = sqlClient.SyncGroups.CreateOrUpdate(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, new SyncGroup
                {
                    Interval = interval1,
                    ConflictResolutionPolicy = conflictPolicy,
                    SyncDatabaseId = syncDatabase.Id,
                    HubDatabaseUserName = SqlManagementTestUtilities.DefaultLogin,
                    HubDatabasePassword = SqlManagementTestUtilities.DefaultPassword
                });
                Assert.NotNull(createSyncGroup);
                Assert.Equal(interval1, createSyncGroup.Interval);
                Assert.Equal(conflictPolicy, createSyncGroup.ConflictResolutionPolicy);
                Assert.Equal(syncDatabase.Id, createSyncGroup.SyncDatabaseId);

                // Get sync group
                SyncGroup getSyncGroup = sqlClient.SyncGroups.Get(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);
                Assert.NotNull(getSyncGroup);
                Assert.Equal(interval1, getSyncGroup.Interval);
                Assert.Equal(conflictPolicy, getSyncGroup.ConflictResolutionPolicy);
                Assert.Equal(syncDatabase.Id, getSyncGroup.SyncDatabaseId);

                // List sync group
                IPage<SyncGroup> listSyncGroups = sqlClient.SyncGroups.ListByDatabase(resourceGroup.Name, server.Name, testDatabaseName);
                Assert.NotNull(listSyncGroups);
                Assert.Equal(1, listSyncGroups.Count());
                Assert.Equal(syncGroupName, listSyncGroups.Single().Name);

                // Update sync group
                int interval2 = 600;
                SyncGroup updateSyncGroup = sqlClient.SyncGroups.Update(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, new SyncGroup
                {
                    Interval = interval2
                });
                Assert.NotNull(updateSyncGroup);
                Assert.Equal(interval2, updateSyncGroup.Interval);

                // Get updated sync group
                SyncGroup getUpdatedSyncGroup = sqlClient.SyncGroups.Get(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);
                Assert.NotNull(getUpdatedSyncGroup);
                Assert.Equal(interval2, getUpdatedSyncGroup.Interval);
                Assert.Equal(conflictPolicy, getUpdatedSyncGroup.ConflictResolutionPolicy);
                Assert.Equal(syncDatabase.Id, getUpdatedSyncGroup.SyncDatabaseId);

				// Update sync group with an empty model
				Assert.Throws<CloudException>(() =>
				{
					sqlClient.SyncGroups.Update(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, new SyncGroup());
				});

				// Refresh hub schema
				sqlClient.SyncGroups.RefreshHubSchema(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);

                // List hub schemas
                IPage<SyncFullSchemaProperties> listHubSchemas = sqlClient.SyncGroups.ListHubSchemas(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);
                Assert.NotNull(listHubSchemas);

                // List logs
                string startTime = "2017-01-01T00:00:00";
                string endTime = "2099-12-31T00:00:00";

                string logType = SyncGroupLogType.All;
                IPage<SyncGroupLogProperties> listLogs = sqlClient.SyncGroups.ListLogs(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, startTime, endTime, logType);
                Assert.NotNull(listLogs);
                foreach(SyncGroupLogProperties log in listLogs)
                {
                    Assert.NotNull(log);
                    Assert.NotNull(log.Timestamp);
                    Assert.NotNull(log.Type);
                    Assert.NotNull(log.Details);
                    Assert.NotNull(log.Source);
                }

                // Delete sync group
                sqlClient.SyncGroups.Delete(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);
            }
        }
    }
}
