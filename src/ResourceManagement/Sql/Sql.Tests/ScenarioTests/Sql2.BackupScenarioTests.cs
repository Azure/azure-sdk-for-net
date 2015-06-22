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
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
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
                            RequestedServiceObjectiveId = dbSloS0,
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