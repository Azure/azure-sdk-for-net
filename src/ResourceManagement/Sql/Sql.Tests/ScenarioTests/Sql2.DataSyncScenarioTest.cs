//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for data sync
    /// </summary>
    public class Sql2DataSyncScenarioTests
    {
        /// <summary>
        /// Tests for the sync agent CRUD operations
        /// </summary>
        [Fact]
        public void SyncAgentCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-sacrud-server");
                string resGroupName = TestUtilities.GenerateName("csm-rg-sacrud");
                string resourceGroupLocation = "West US";
                string serverLocation = "West US 2";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ss";
                string version = "12.0";

                // Variables for database create
                string databaseName = TestUtilities.GenerateName("csm-sql-sacrud-db");
                string syncDatabaseName = TestUtilities.GenerateName("csm-sql-sacrud-syncdb");
                string databaseCollation = "SQL_Latin1_General_CP1_CI_AS";
                string databaseEdition = "Standard";
                long databaseMaxSize = 5L * 1024L * 1024L * 1024L; // 5 GB
                Guid dbSloShared = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2"); // Web / Business
                Guid dbSloBasic = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"); // Basic
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
                Guid dbSloS1 = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"); // S1
                Guid dbSloS2 = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"); // S2

                string subscriptionId = sqlClient.Credentials.SubscriptionId;
                string syncDatabaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                    subscriptionId, resGroupName, serverName, databaseName);

                // Variables for sync agent creation
                string syncAgentName1 = TestUtilities.GenerateName("csm-sql-sacrud-syncagent");

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = resourceGroupLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test
                    var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });

                    TestUtilities.ValidateOperationResponse(createServerResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create database for test
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync database for test
                    var createDbResponse2 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, syncDatabaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse2, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync agent 1 for test
                    var createSyncAgentResponse1 = sqlClient.DataSync.CreateOrUpdateSyncAgent(resGroupName, serverName, syncAgentName1, new SyncAgentCreateOrUpdateParameters()
                    {
                        Properties = new SyncAgentCreateOrUpdateProperties()
                        {
                            SyncDatabaseId = syncDatabaseId
                        },
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createSyncAgentResponse1, HttpStatusCode.Created);
                    VerifySyncAgentInformation(createSyncAgentResponse1.SyncAgent, syncDatabaseId);

                    //////////////////////////////////////////////////////////////////////
                    // Get the sync agent
                    var getSyncAgent1 = sqlClient.DataSync.GetSyncAgent(resGroupName, serverName, syncAgentName1);
                    TestUtilities.ValidateOperationResponse(getSyncAgent1);
                    VerifySyncAgentInformation(getSyncAgent1.SyncAgent, syncDatabaseId);

                    //////////////////////////////////////////////////////////////////////
                    // List all sync agents
                    var listSyncAgent1 = sqlClient.DataSync.ListSyncAgent(resGroupName, serverName);
                    TestUtilities.ValidateOperationResponse(listSyncAgent1);
                    Assert.Equal(1, listSyncAgent1.SyncAgents.Count);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync agent key for test
                    var createSyncAgentKeyResponse = sqlClient.DataSync.CreateSyncAgentKey(resGroupName, serverName, syncAgentName1);

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createSyncAgentKeyResponse);
                    Assert.NotNull(createSyncAgentKeyResponse.SyncAgentKey);

                    //////////////////////////////////////////////////////////////////////
                    // Get sync agent linked databases
                    var getSyncAgentLinkedDatabaseResponse = sqlClient.DataSync.ListSyncAgentLinkedDatabase(resGroupName, serverName, syncAgentName1);

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(getSyncAgentLinkedDatabaseResponse);
                    Assert.Equal(HttpStatusCode.OK, getSyncAgentLinkedDatabaseResponse.StatusCode);

                    //////////////////////////////////////////////////////////////////////
                    // Delete sync agent test.
                    var deleteSyncAgent1 = sqlClient.DataSync.DeleteSyncAgent(resGroupName, serverName, syncAgentName1);
                    TestUtilities.ValidateOperationResponse(deleteSyncAgent1);

                    sqlClient.Servers.Delete(resGroupName, serverName);
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Tests for the sync group CRUD operations
        /// </summary>
        [Fact]
        public void SyncGroupCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-sgcrud-server");
                string resGroupName = TestUtilities.GenerateName("csm-rg-sgcrud");
                string resourceGroupLocation = "West US";
                string serverLocation = "West US 2";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ss";
                string version = "12.0";

                // Variables for database create
                string databaseName = TestUtilities.GenerateName("csm-sql-sgcrud-db");
                string syncDatabaseName = TestUtilities.GenerateName("csm-sql-sgcrud-syncdb");
                string databaseCollation = "SQL_Latin1_General_CP1_CI_AS";
                string databaseEdition = "Standard";
                long databaseMaxSize = 5L * 1024L * 1024L * 1024L; // 5 GB
                Guid dbSloShared = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2"); // Web / Business
                Guid dbSloBasic = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"); // Basic
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
                Guid dbSloS1 = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"); // S1
                Guid dbSloS2 = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"); // S2

                // Variables for sync group 1 create
                string syncGroupName = TestUtilities.GenerateName("csm-sql-sgcrud-syncgroup");
                int interval1 = 300;
                int interval2 = 200;
                string subscriptionId = sqlClient.Credentials.SubscriptionId;
                string syncDatabaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                    subscriptionId, resGroupName, serverName, syncDatabaseName);
                ConflictResolutionPolicyType conflictResolutionPolicy1 = ConflictResolutionPolicyType.HubWin;

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = resourceGroupLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test
                    var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });

                    TestUtilities.ValidateOperationResponse(createServerResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create database for test
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync database for test
                    var createDbResponse2 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, syncDatabaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse2, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync group 1 for test
                    var createSyncGroupResponse1 = sqlClient.DataSync.CreateOrUpdateSyncGroup(resGroupName, serverName, databaseName, new SyncGroupCreateOrUpdateParameters()
                    {
                        SyncGroupName = syncGroupName,
                        Properties = new SyncGroupCreateOrUpdateProperties()
                        {
                            Interval = interval1,
                            ConflictResolutionPolicy = conflictResolutionPolicy1,
                            SyncDatabaseId = syncDatabaseId,
                            HubDatabaseUserName = adminLogin,
                            HubDatabasePassword = adminPass
                        },
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createSyncGroupResponse1, HttpStatusCode.Created);
                    VerifySyncGroupInformation(createSyncGroupResponse1.SyncGroup, interval1, syncDatabaseId, adminLogin, conflictResolutionPolicy1);

                    //////////////////////////////////////////////////////////////////////
                    // Get the sync group
                    var getSyncGroup1 = sqlClient.DataSync.GetSyncGroup(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(getSyncGroup1);
                    VerifySyncGroupInformation(getSyncGroup1.SyncGroup, interval1, syncDatabaseId, adminLogin, conflictResolutionPolicy1);

                    //////////////////////////////////////////////////////////////////////
                    // Get all sync groups
                    var listSyncGroup1 = sqlClient.DataSync.ListSyncGroup(resGroupName, serverName, databaseName);
                    TestUtilities.ValidateOperationResponse(listSyncGroup1);
                    Assert.Equal(1, listSyncGroup1.SyncGroups.Count);
                    VerifySyncGroupInformation(listSyncGroup1.SyncGroups[0], interval1, syncDatabaseId, adminLogin, conflictResolutionPolicy1);

                    //////////////////////////////////////////////////////////////////////
                    // Update description and schema of sync group 2 test
                    var updateSyncGroup1 = sqlClient.DataSync.UpdateSyncGroup(resGroupName, serverName, databaseName, new SyncGroupCreateOrUpdateParameters()
                    {
                        SyncGroupName = syncGroupName,
                        Properties = new SyncGroupCreateOrUpdateProperties()
                        {
                            Interval = interval2
                        },
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(updateSyncGroup1);
                    Assert.Equal(interval2, updateSyncGroup1.SyncGroup.Properties.Interval);

                    // Get the sync group after updating
                    var getSyncGroup2 = sqlClient.DataSync.GetSyncGroup(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(getSyncGroup2);
                    VerifySyncGroupInformation(getSyncGroup2.SyncGroup, interval2, syncDatabaseId, adminLogin, conflictResolutionPolicy1);

                    var refreshSchemaResponse = sqlClient.DataSync.InvokeSyncHubSchemaRefresh(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(refreshSchemaResponse);

                    //////////////////////////////////////////////////////////////////////
                    // Get full schema of member database of a hub database
                    var getSyncMemberSchema1 = sqlClient.DataSync.GetSyncHubSchema(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(getSyncMemberSchema1);

                    //////////////////////////////////////////////////////////////////////
                    // Get log of sync group
                    var getSyncGroupLog = sqlClient.DataSync.ListSyncGroupLog(resGroupName, serverName, databaseName, new SyncGroupLogGetParameters
                    {
                        SyncGroupName = syncGroupName,
                        StartTime = "9/16/2016 11:31:12",
                        EndTime = "9/16/2016 12:31:00",
                        Type = LogType.All.ToString()
                    });
                    TestUtilities.ValidateOperationResponse(getSyncGroupLog);
                    VerifySyncGroupLogInformation(getSyncGroupLog);

                    //////////////////////////////////////////////////////////////////////
                    // Delete sync group test.
                    var deleteSyncGroup1 = sqlClient.DataSync.DeleteSyncGroup(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(deleteSyncGroup1);

                    sqlClient.Servers.Delete(resGroupName, serverName);
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Tests for the sync member CRUD operations and get, refresh the full schema of member database
        /// </summary>
        [Fact]
        public void SyncMemberCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-smcrud-server");
                string resGroupName = TestUtilities.GenerateName("csm-rg-smcrud");
                string resourceGroupLocation = "West US";
                string serverLocation = "West US 2";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ss";
                string version = "12.0";

                // Variables for database create
                string databaseName = TestUtilities.GenerateName("csm-sql-smcrud-db");
                string syncDatabaseName = TestUtilities.GenerateName("csm-sql-smcrud-syncdb");
                string memberDatabaseName = TestUtilities.GenerateName("csm-sql-smcrud-memberdb");
                string memberFullDNSServerName = serverName + ".sqltest-eg1.mscds.com";
                string databaseCollation = "SQL_Latin1_General_CP1_CI_AS";
                string databaseEdition = "Standard";
                long databaseMaxSize = 5L * 1024L * 1024L * 1024L; // 5 GB
                Guid dbSloShared = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2"); // Web / Business
                Guid dbSloBasic = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"); // Basic
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
                Guid dbSloS1 = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"); // S1
                Guid dbSloS2 = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"); // S2

                // Variables for sync group create
                string syncGroupName = TestUtilities.GenerateName("csm-sql-smcrud-syncgroup");
                int interval = 300;
                ConflictResolutionPolicyType conflictResolutionPolicy = ConflictResolutionPolicyType.Memberwin;
                string subscriptionId = sqlClient.Credentials.SubscriptionId;
                string syncDatabaseId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}",
                    subscriptionId, resGroupName, serverName, databaseName);

                // Variables for sync member creation
                string syncMemberName1 = TestUtilities.GenerateName("csm-sql-smcrud-sm");
                SyncDirectionEnum syncDirection = SyncDirectionEnum.Bidirectional;
                DatabaseTypeEnum databaseType = DatabaseTypeEnum.AzureSqlDatabase;
                SyncMemberGeneralParameters syncMemberGeneralParameter = new SyncMemberGeneralParameters()
                {
                    SyncGroupName = syncGroupName,
                    SyncMemberName = syncMemberName1
                };

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = resourceGroupLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test
                    var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });

                    TestUtilities.ValidateOperationResponse(createServerResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create database for test
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync database for test
                    var createDbResponse2 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, syncDatabaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse2, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create member database for test
                    var createMemberDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, memberDatabaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create sync group for test
                    var createSyncGroupResponse = sqlClient.DataSync.CreateOrUpdateSyncGroup(resGroupName, serverName, databaseName, new SyncGroupCreateOrUpdateParameters()
                    {
                        SyncGroupName = syncGroupName,
                        Properties = new SyncGroupCreateOrUpdateProperties()
                        {
                            Interval = interval,
                            ConflictResolutionPolicy = conflictResolutionPolicy,
                            SyncDatabaseId = syncDatabaseId,
                        },
                    });

                    //////////////////////////////////////////////////////////////////////
                    // Create sync member for test
                    var createSyncMemberResponse = sqlClient.DataSync.CreateOrUpdateSyncMember(resGroupName, serverName, databaseName, new SyncMemberCreateOrUpdateParameters()
                    {
                        SyncGroupName = syncGroupName,
                        SyncMemberName = syncMemberName1,
                        Properties = new SyncMemberCreateOrUpdateProperties()
                        {
                            SyncDirection = syncDirection,
                            DatabaseType = databaseType,
                            DatabaseName = memberDatabaseName,
                            ServerName = memberFullDNSServerName,
                            UserName = adminLogin,
                            Password = adminPass,
                        },
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createSyncMemberResponse, HttpStatusCode.Created);
                    VerifySyncMemberInformation(createSyncMemberResponse.SyncMember, syncDirection, databaseType, memberFullDNSServerName, memberDatabaseName);

                    //////////////////////////////////////////////////////////////////////
                    // Get the sync member
                    var getSyncMember1 = sqlClient.DataSync.GetSyncMember(resGroupName, serverName, databaseName, syncMemberGeneralParameter);
                    TestUtilities.ValidateOperationResponse(getSyncMember1);
                    VerifySyncMemberInformation(getSyncMember1.SyncMember, syncDirection, databaseType, memberFullDNSServerName, memberDatabaseName);

                    //////////////////////////////////////////////////////////////////////
                    // List all sync members
                    var listSyncMember = sqlClient.DataSync.ListSyncMember(resGroupName, serverName, databaseName, syncGroupName);
                    TestUtilities.ValidateOperationResponse(listSyncMember);
                    Assert.Equal(1, listSyncMember.SyncMembers.Count);
                    VerifySyncMemberInformation(listSyncMember.SyncMembers[0], syncDirection, databaseType, memberFullDNSServerName, memberDatabaseName);

                    //////////////////////////////////////////////////////////////////////
                    // Update sync member test
                    var updateSyncMember1 = sqlClient.DataSync.UpdateSyncMember(resGroupName, serverName, databaseName, new SyncMemberCreateOrUpdateParameters()
                    {
                        SyncGroupName = syncGroupName,
                        SyncMemberName = syncMemberName1,
                        Properties = new SyncMemberCreateOrUpdateProperties()
                        {
                            DatabaseType = DatabaseTypeEnum.AzureSqlDatabase,
                            UserName = adminLogin,
                            Password = adminPass
                        },
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(updateSyncMember1);
                //    VerifySyncMemberInformation(updateSyncMember1.SyncMember, syncDirection, databaseType, memberFullDNSServerName, memberDatabaseName);

                    var refreshSchemaResponse = sqlClient.DataSync.InvokeSyncMemberSchemaRefresh(resGroupName, serverName, databaseName, syncMemberGeneralParameter);
                    TestUtilities.ValidateOperationResponse(refreshSchemaResponse);

                    //////////////////////////////////////////////////////////////////////
                    // Get full schema of member database of sync member
                    var getSyncMemberSchema1 = sqlClient.DataSync.GetSyncMemberSchema(resGroupName, serverName, databaseName, syncMemberGeneralParameter);
                    TestUtilities.ValidateOperationResponse(getSyncMemberSchema1);

                    //////////////////////////////////////////////////////////////////////
                    // Delete sync member test.
                    var deleteSyncMember1 = sqlClient.DataSync.DeleteSyncMember(resGroupName, serverName, databaseName, syncMemberGeneralParameter);
                    TestUtilities.ValidateOperationResponse(deleteSyncMember1);

                    //////////////////////////////////////////////////////////////////////
                    // Delete sync group.
                    var deleteSyncGroup1 = sqlClient.DataSync.DeleteSyncGroup(resGroupName, serverName, databaseName, syncGroupName);

                    sqlClient.Servers.Delete(resGroupName, serverName);
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        private static void VerifySyncGroupInformation(SyncGroup syncGroup, int interval, string syncDatabaseId, string hubDatabaseUserName, ConflictResolutionPolicyType? conflictResolutionPolicy)
        {
            Assert.Equal(interval, syncGroup.Properties.Interval);
            Assert.Equal(conflictResolutionPolicy, syncGroup.Properties.ConflictResolutionPolicy);
//            Assert.Equal(syncDatabaseId, syncGroup.Properties.SyncDatabaseId);
        }

        private static void VerifySyncMemberInformation(SyncMember syncMember, SyncDirectionEnum syncDirection, DatabaseTypeEnum databaseType, string memberServerName, string memberDatabaseName)
        {
            Assert.Equal(syncDirection, syncMember.Properties.SyncDirection);
            Assert.Equal(databaseType, syncMember.Properties.DatabaseType);
            if (databaseType == DatabaseTypeEnum.AzureSqlDatabase)
            {
                Assert.Equal(memberDatabaseName, syncMember.Properties.DatabaseName);
                Assert.Equal(memberServerName, syncMember.Properties.ServerName);
            }
        }

        private static void VerifySyncGroupLogInformation(SyncGroupLogListResponse response)
        {
            IList<SyncGroupLog> syncGroupLogs = response.SyncGroupLogs;
            foreach (SyncGroupLog syncGroupLog in syncGroupLogs)
            {
                Assert.NotNull(syncGroupLog.TimeStamp);
                Assert.NotNull(syncGroupLog.Type);
                Assert.NotNull(syncGroupLog.Details);
                Assert.NotNull(syncGroupLog.Source);
            }
        }

        private static void VerifySyncAgentInformation(SyncAgent syncAgent, string syncDatabaseId)
        {
            Assert.Equal(syncDatabaseId, syncAgent.Properties.SyncDatabaseId);
        }
    }
}


