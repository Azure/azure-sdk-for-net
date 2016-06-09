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

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Sql.Tests;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for Azure SQL Database backup operations.
    /// </summary>
    public class Sql2BackupScenarioTest : TestBase
    {
        /// <summary>
        /// Test for List Azure SQL Database Restore Points operations.
        /// </summary>
        [Fact]
        public void ListRestorePointsTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server creation.
                string serverName = TestUtilities.GenerateName("csm-sql-backup");
                string resGroupName = TestUtilities.GenerateName("csm-rg-backup");

                string serverLocation = "Japan East";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";

                // Constants for Azure SQL Data Warehouse database creation.
                var defaultDatabaseSize = 250L * 1024L * 1024L * 1024L; // 250 GB
                Guid dwSlo = new Guid("4E63CB0E-91B9-46FD-B05C-51FDD2367618 "); // DW100
                var databaseName = TestUtilities.GenerateName("csm-sql-backup-dwdb");
                string databaseEdition = "DataWarehouse";

                // Constants for Azure SQL standard database creation.
                var standardDefaultDatabaseSize = 1L * 1024L * 1024L * 1024L; // 1 GB
                var standardDatabaseName = TestUtilities.GenerateName("csm-sql-backup-db");
                string standardDatabaseEdition = "Standard";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
                    var createResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Create database test.

                    // Create data warehouse database
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = defaultDatabaseSize,
                            Edition = databaseEdition,
                            RequestedServiceObjectiveId = dwSlo,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);

                    // Create standard database
                    createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = standardDefaultDatabaseSize,
                            Edition = standardDatabaseEdition,
                            RequestedServiceObjectiveId = SqlConstants.DbSloS0,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Get restore points for data warehouse database.

                    RestorePointListResponse restorePointsListResponse = sqlClient.DatabaseBackup.ListRestorePoints(resGroupName, serverName, databaseName);

                    // Creating a data warehouse database should not have any discrete restore points right after.
                    TestUtilities.ValidateOperationResponse(restorePointsListResponse, HttpStatusCode.OK);
                    ValidateRestorePointListResponse(restorePointsListResponse, true, 0);
                    ///////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Get restore points for standard database.

                    restorePointsListResponse = sqlClient.DatabaseBackup.ListRestorePoints(resGroupName, serverName, standardDatabaseName);

                    TestUtilities.ValidateOperationResponse(restorePointsListResponse, HttpStatusCode.OK);
                    ValidateRestorePointListResponse(restorePointsListResponse, false, 1);
                    ///////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Test for List Azure SQL Database Geo Backups operations.
        /// </summary>
        [Fact]
        public void ListGeoBackupsTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Use a preconfigured runner server/db in order to test this
                // Create a resource group/server/db with the following details prior to running this test
                // If first run on a live cluster, wait several hours for the geo pair to be created

                string serverName = "csm-sql-backup-geo31415seasia";
                string resGroupName = "csm-rg-backup-geo31415seasia";
                string serverLocation = "Southeast Asia";
                string standardDatabaseName = "csm-sql-backup-geo-db31415";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";
                var standardDefaultDatabaseSize = 1L * 1024L * 1024L * 1024L; // 1 GB
                string standardDatabaseEdition = "Standard";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                var createResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new ServerCreateOrUpdateProperties()
                    {
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass,
                        Version = version,
                    }
                });

                var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName, new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        MaxSizeBytes = standardDefaultDatabaseSize,
                        Edition = standardDatabaseEdition,
                        RequestedServiceObjectiveId = SqlConstants.DbSloS0,
                    },
                });

                GeoBackupListResponse geoBackups = sqlClient.DatabaseBackup.ListGeoBackups(resGroupName, serverName);

                Assert.True(geoBackups.GeoBackups.Count >= 1);

                var geoRestoreDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName + "_georestored", new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        SourceDatabaseId = geoBackups.GeoBackups[0].Id,
                        CreateMode = "Recovery"
                    }
                });

                TestUtilities.ValidateOperationResponse(geoRestoreDbResponse, HttpStatusCode.Created);
            }
        }

        /// <summary>
        /// Test for List Azure SQL Database deleted database operations.
        /// </summary>
        [Fact]
        public void ListDeletedDatabaseBackupTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server creation.
                string serverName = "csm-sql-backup31415";
                string resGroupName = "csm-rg-backup31415";

                string serverLocation = "North Europe";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";

                // Constants for Azure SQL standard database creation.
                var standardDefaultDatabaseSize = 1L * 1024L * 1024L * 1024L; // 1 GB
                var standardDatabaseName = "csm-sql-backup-db31415";
                string standardDatabaseEdition = "Standard";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                //////////////////////////////////////////////////////////////////////
                // Create server for test.
                var createResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new ServerCreateOrUpdateProperties()
                    {
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass,
                        Version = version,
                    }
                });

                // Verify the the response from the service contains the right information
                TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                //////////////////////////////////////////////////////////////////////

                // Create standard database
                var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName, new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        MaxSizeBytes = standardDefaultDatabaseSize,
                        Edition = standardDatabaseEdition,
                        RequestedServiceObjectiveId = SqlConstants.DbSloS0,
                    },
                });

                TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                //////////////////////////////////////////////////////////////////////

                // If first run on a live cluster, wait 10 minutes for backup to be taken (set a breakpoint to stop execution here)
                var deleteDbResponse = sqlClient.Databases.Delete(resGroupName, serverName, standardDatabaseName);

                TestUtilities.ValidateOperationResponse(deleteDbResponse, HttpStatusCode.OK);

                DeletedDatabaseBackupListResponse deletedDatabaseBackups = sqlClient.DatabaseBackup.ListDeletedDatabaseBackups(resGroupName, serverName);

                Assert.True(deletedDatabaseBackups.DeletedDatabaseBackups.Count > 0);

                var restoreDroppedDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName + "_restored", new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        SourceDatabaseId = deletedDatabaseBackups.DeletedDatabaseBackups[0].Id,
                        RestorePointInTime = deletedDatabaseBackups.DeletedDatabaseBackups[0].Properties.DeletionDate,
                        CreateMode = "Restore"
                    }
                });

                TestUtilities.ValidateOperationResponse(restoreDroppedDbResponse, HttpStatusCode.Created);
            }
        }

        /// <summary>
        /// Test for Azure SQL Server Backup Long Term Retention Vault operations
        /// </summary>
        [Fact]
        public void ServerLTRVaultTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Use a preconfigured runner server/db in order to test this
                // Create a resource group/server/db/vault with the following details prior to running this test

                string serverName = "hchung-testsvr";
                string resGroupName = "hchung";

                sqlClient.DatabaseBackup.CreateOrUpdateBackupLongTermRetentionVault(resGroupName, serverName, "RegisteredVault", new BackupLongTermRetentionVaultCreateOrUpdateParameters()
                {
                    Location = "North Europe",
                    Properties = new BackupLongTermRetentionVaultProperties()
                    {
                        RecoveryServicesVaultResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault",
                    }
                });

                BackupLongTermRetentionVaultGetResponse resp = sqlClient.DatabaseBackup.GetBackupLongTermRetentionVault(resGroupName, serverName, "RegisteredVault");

                Assert.NotNull(resp.BackupLongTermRetentionVault.Properties.RecoveryServicesVaultResourceId);
            }
        }

        /// <summary>
        /// Test for Azure SQL Database Backup Long Term Retention Policy operations
        /// </summary>
        [Fact]
        public void DatabaseLTRPolicyTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                string serverName = "hchung-testsvr";
                string resGroupName = "hchung";
                string databaseName = "hchung-testdb";

                sqlClient.DatabaseBackup.CreateOrUpdateDatabaseBackupLongTermRetentionPolicy(resGroupName, serverName, databaseName, "Default", new DatabaseBackupLongTermRetentionPolicyCreateOrUpdateParameters()
                {
                    Location = "North Europe",
                    Properties = new DatabaseBackupLongTermRetentionPolicyProperties()
                    {
                        State = "Enabled",
                        RecoveryServicesBackupPolicyResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault/backupPolicies/hchung-testpolicy",
                    }
                });

                DatabaseBackupLongTermRetentionPolicyGetResponse resp = sqlClient.DatabaseBackup.GetDatabaseBackupLongTermRetentionPolicy(resGroupName, serverName, databaseName, "Default");

                Assert.NotNull(resp.DatabaseBackupLongTermRetentionPolicy.Properties.RecoveryServicesBackupPolicyResourceId);
            }
        }

        /// <summary>
        /// Test for List Azure SQL Database Restore operations.
        /// </summary>
        [Fact]
        public void RestoreTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server creation.
                string serverName = "hchung-testsvr2";
                string resGroupName = "hchung-test2";
                string standardDatabaseName = "hchung-testdb-geo2";
                string serverLocation = "Southeast Asia";

                // Create or update standard database
                var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName, new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                    },
                });

                TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                //////////////////////////////////////////////////////////////////////

                string databaseId = createDbResponse.Database.Id;

                // If first run on a live cluster, wait 10 minutes for backup to be taken (set a breakpoint to stop execution here).  The time of the restore will also need to be updated if running on a a live cluster.
                string timeString = "2016-02-24T00:00:00";
                DateTime restorePointInTime = DateTime.Parse(timeString);

                var restoreDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, standardDatabaseName + "_" + timeString, new DatabaseCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new DatabaseCreateOrUpdateProperties()
                    {
                        SourceDatabaseId = databaseId,
                        RestorePointInTime = restorePointInTime,
                        CreateMode = "PointInTimeRestore"
                    }
                });

                TestUtilities.ValidateOperationResponse(restoreDbResponse, HttpStatusCode.Created);
            }
        }

        /// <summary>
        /// Validates the RestorePointListResponse.
        /// </summary>
        /// <param name="restorePointsListResponse">Response to validate.</param>
        /// <param name="isDataWarehouseDatabase">Is this response from a data warehouse database? Data warehouse databases return different values than other databases.</param>
        /// <param name="expectedCount">Expected number of restore points.</param>
        private static void ValidateRestorePointListResponse(RestorePointListResponse restorePointsListResponse, bool isDataWarehouseDatabase, int expectedCount)
        {
            Assert.Equal(expectedCount, restorePointsListResponse.Count());
            int count = restorePointsListResponse.Count();
            if (count == expectedCount && count > 0)
            {
                RestorePoint selectedRestorePoint = restorePointsListResponse.RestorePoints.First();
                if (isDataWarehouseDatabase)
                {
                    Assert.Equal("DISCRETE", selectedRestorePoint.Properties.RestorePointType);
                    Assert.Null(selectedRestorePoint.Properties.EarliestRestoreDate);
                    Assert.NotNull(selectedRestorePoint.Properties.RestorePointCreationDate);
                }
                else
                {
                    Assert.Equal("CONTINUOUS", selectedRestorePoint.Properties.RestorePointType);
                    Assert.NotNull(selectedRestorePoint.Properties.EarliestRestoreDate);
                    Assert.Null(selectedRestorePoint.Properties.RestorePointCreationDate);
                }
            }
        }
    }
}