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
using System.Linq;
using System.Net;
using Sql.Tests;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for job account CRUD
    /// </summary>
    public class Sql2JobAccountScenarioTest : TestBase
    {
        /// <summary>
        /// Tests for the job account CRUD operations
        /// </summary>
        [Fact]
        public void JobAccountCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-jobaccountcrud-server");
                string resGroupName = TestUtilities.GenerateName("csm-rg-jobaccountcrud");
                string serverLocation = "Southeast Asia";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ss";
                string version = "12.0";

                // Variables for database create
                string databaseName = TestUtilities.GenerateName("csm-sql-jobaccountcrud-db");
                string databaseCollation = "Japanese_Bushu_Kakusu_100_CS_AS_KS_WS";
                string databaseEdition = "Standard";
                long databaseMaxSize = 5L * 1024L * 1024L * 1024L; // 5 GB
                Guid dbSloS1 = SqlConstants.DbSloS1;

                // Variables for job account create
                string jobAccountName = TestUtilities.GenerateName("csm-sql-jobaccountcrud-jobaccount");

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
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

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createServerResponse, HttpStatusCode.Created);

                    //////////////////////////////////////////////////////////////////////
                    // Create database for test.

                    // Create all options.
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
                    // Create job account test.

                    var createJobResonse = sqlClient.JobAccounts.CreateOrUpdate(resGroupName, serverName, jobAccountName,
                        new JobAccountCreateOrUpdateParameters
                        {
                            Location = serverLocation,
                            Properties = new JobAccountCreateOrUpdateProperties
                            {
                                DatabaseId = createDbResponse.Database.Id
                            }
                        });

                    TestUtilities.ValidateOperationResponse(createJobResonse, HttpStatusCode.Created);
                    VerifyJobAccountInformation(createJobResonse.JobAccount, jobAccountName, createDbResponse.Database.Id);

                    //////////////////////////////////////////////////////////////////////
                    // Get job account test

                    var getJobAccountResponse = sqlClient.JobAccounts.Get(resGroupName, serverName, jobAccountName);
                    TestUtilities.ValidateOperationResponse(getJobAccountResponse);
                    VerifyJobAccountInformation(getJobAccountResponse.JobAccount, jobAccountName, createDbResponse.Database.Id);

                    //////////////////////////////////////////////////////////////////////
                    // List job account test

                    var listJobAccountResponse = sqlClient.JobAccounts.List(resGroupName, serverName);
                    TestUtilities.ValidateOperationResponse(listJobAccountResponse);
                    Assert.Equal(1, listJobAccountResponse.Count());
                    VerifyJobAccountInformation(listJobAccountResponse.JobAccounts[0], jobAccountName, createDbResponse.Database.Id);

                    //////////////////////////////////////////////////////////////////////
                    // Delete job account test

                    var deleteJobAccountResponse = sqlClient.JobAccounts.Delete(resGroupName, serverName, jobAccountName);
                    TestUtilities.ValidateOperationResponse(deleteJobAccountResponse);
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Verify that the Database object matches the provided values
        /// </summary>
        /// <param name="jobAccount">The job account.</param>
        /// <param name="jobAccountName">Name of the job account.</param>
        /// <param name="databaseId">The database identifier.</param>
        private static void VerifyJobAccountInformation(JobAccount jobAccount, string jobAccountName, string databaseId)
        {
            Assert.Equal(jobAccountName, jobAccount.Name);
            Assert.Equal(databaseId, jobAccount.Properties.DatabaseId);
        }
    }
}