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
    public class SyncMemberScenarioTests
    {
        [Fact]
        public void SyncMemberCRUDTest()
        {
            string testPrefix = "syncmembercrudtest-";
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

                // Create member database
                string memberDatabaseName = SqlManagementTestUtilities.GenerateName(testPrefix + "member");
                Database memberDatabase = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, memberDatabaseName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(memberDatabase);

                // Create sync group
                string syncGroupName = SqlManagementTestUtilities.GenerateName(testPrefix + "syncgroup");
                SyncGroup createSyncGroup = sqlClient.SyncGroups.CreateOrUpdate(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, new SyncGroup
                {
                    Interval = -1, // Manual
                    ConflictResolutionPolicy = SyncConflictResolutionPolicy.MemberWin,
                    SyncDatabaseId = syncDatabase.Id,
                    HubDatabaseUserName = SqlManagementTestUtilities.DefaultLogin,
                    HubDatabasePassword = SqlManagementTestUtilities.DefaultPassword
                });
                Assert.NotNull(createSyncGroup);

                #region Azure SQL database member

                // Create an Azure SQL database member
                string syncMemberName = SqlManagementTestUtilities.GenerateName(testPrefix + "azsyncmember");
                string syncMemberDirection = SyncDirection.OneWayMemberToHub;
                string syncMemberDatabaseType = SyncMemberDbType.AzureSqlDatabase;
                SyncMember createSyncMember = sqlClient.SyncMembers.CreateOrUpdate(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName, new SyncMember
                {
                    SyncDirection = syncMemberDirection,
                    DatabaseType = syncMemberDatabaseType,
                    DatabaseName = memberDatabaseName,
                    ServerName = server.Name,
                    UserName = SqlManagementTestUtilities.DefaultLogin,
                    Password = SqlManagementTestUtilities.DefaultPassword,
                });
                Assert.NotNull(createSyncMember);
                Assert.Equal(syncMemberDirection, createSyncMember.SyncDirection);
                Assert.Equal(syncMemberDatabaseType, createSyncMember.DatabaseType);
                Assert.Equal(memberDatabaseName, createSyncMember.DatabaseName);
                Assert.Equal(server.Name, createSyncMember.ServerName);

                // Get Azure SQL database member
                SyncMember getSyncMember = sqlClient.SyncMembers.Get(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName);
                Assert.NotNull(getSyncMember);
                Assert.Equal(syncMemberDirection, getSyncMember.SyncDirection);
                Assert.Equal(syncMemberDatabaseType, getSyncMember.DatabaseType);
                Assert.Equal(memberDatabaseName, getSyncMember.DatabaseName);
                Assert.Equal(server.Name, getSyncMember.ServerName);

                // List sync members
                IPage<SyncMember> listSyncMembers = sqlClient.SyncMembers.ListBySyncGroup(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName);
                Assert.NotNull(listSyncMembers);
                Assert.Equal(1, listSyncMembers.Count());
                Assert.Equal(syncMemberName, listSyncMembers.Single().Name);

                // Update sync member
                string updateSyncMemberDirection = SyncDirection.Bidirectional;
                SyncMember updateSyncMember = sqlClient.SyncMembers.Update(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName, new SyncMember
                {
                    SyncDirection = updateSyncMemberDirection,
                    DatabaseType = syncMemberDatabaseType,
                    UserName = SqlManagementTestUtilities.DefaultLogin,
                    Password = SqlManagementTestUtilities.DefaultPassword,
                });
                Assert.NotNull(updateSyncMember);
                Assert.Equal(updateSyncMemberDirection, updateSyncMember.SyncDirection);
                Assert.NotEqual(syncMemberDirection, updateSyncMemberDirection);

				// Update sync member with an empty model
				Assert.Throws<CloudException>(() =>
				{
					sqlClient.SyncMembers.Update(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName, new SyncMember());
				});

				// Refresh member schemas
				sqlClient.SyncMembers.RefreshMemberSchema(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName);

                // List member schemas
                IPage<SyncFullSchemaProperties> memberSchemas = sqlClient.SyncMembers.ListMemberSchemas(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName);
                Assert.NotNull(memberSchemas);

                // Delete Azure SQL database member
                sqlClient.SyncMembers.Delete(resourceGroup.Name, server.Name, testDatabaseName, syncGroupName, syncMemberName);

                #endregion
            }
        }
    }
}
