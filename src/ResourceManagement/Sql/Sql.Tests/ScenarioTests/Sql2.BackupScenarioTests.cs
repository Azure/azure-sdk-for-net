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
    /// Contains tests for server CRUD, database CRUD, and firewall CRUD
    /// </summary>
    public class Sql2ScenarioTest : TestBase
    {

        /// <summary>
        /// Test for Azure SQL Data Warehouse database pause and resume operations.
        /// </summary>
        [Fact]
        public void DatabaseActivationTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server creation.
                string serverName = TestUtilities.GenerateName("csm-sql-activation");
                string resGroupName = TestUtilities.GenerateName("csm-rg-activation");

                string serverLocation = "Southeast Asia";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";


                // Constants for database creation.
                var defaultDatabaseSize = 250L * 1024L * 1024L * 1024L; // 250 GB
                Guid dwSlo = new Guid("4E63CB0E-91B9-46FD-B05C-51FDD2367618 "); // DW100
                var defaultCollation = "SQL_Latin1_General_CP1_CI_AS";
                var databaseName = TestUtilities.GenerateName("csm-sql-activation-db");
                string databaseEdition = "DataWarehouse";

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
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Create database test.

                    // Create only required
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
                    VerifyDatabaseInformation(createDbResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Pause database.

                    var pauseResponse = sqlClient.DatabaseActivation.Pause(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(pauseResponse, HttpStatusCode.OK);
                    VerifyDatabaseInformation(pauseResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo, "Paused");
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Resume database.

                    var resumeResponse = sqlClient.DatabaseActivation.Resume(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(resumeResponse, HttpStatusCode.OK);
                    VerifyDatabaseInformation(resumeResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo, "Online");
                    ///////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }
    }
}