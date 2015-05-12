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

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Hyak.Common;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for server upgrade test
    /// </summary>
    public class Sql2ServerUpgradeScenarioTest : TestBase
    {
        private const string serverLocation = "West US";
        private const string currentVersion = "2.0";
        private const string upgradedVersion = "12.0";
        private const string targetEdition = DatabaseEditions.Standard;
        private const string targetServiceLevelObjective = "S0";

        private const string upgradeStatusQueued = "Queued";
        private const string upgradeStatusInProgress = "InProgress";
        private const string upgradeStatusCancelling = "Cancelling";

        // Short sleep time so that test with Playback runs faster. 
        // If running the test in Record mode, change to 60 seconds
        private const int UpgradePollingTimeInSeconds = 1;

        /// <summary>
        /// Positive test for server upgrade operation and polling the upgrade status until completed. 
        /// This test is for empty server
        /// </summary>
        [Fact]
        public void PositiveTestEmptyServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    new BasicDelegatingHandler(), 
                    currentVersion, 
                    serverLocation, 
                    UpgradeEmptyServer);
            }
        }

        /// <summary>
        /// Positive test for server upgrade operation and polling the upgrade status until completed. 
        /// This test is for server with 1 Basic database mapped to a new target edition and SLO
        /// </summary>
        [Fact]
        public void PositiveTestWithRecommendedDatabase()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(
                    new BasicDelegatingHandler(), 
                    currentVersion, 
                    serverLocation, 
                    UpgradeServer);
            }
        }

        /// <summary>
        /// Positive test for server upgrade operation, getting upgrade status and cancel for empty server.
        /// Empty server is sufficient since server upgrade with databases are already tested in previous tests.
        /// </summary>
        [Fact]
        public void PositiveTestWithCancel()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    new BasicDelegatingHandler(), 
                    currentVersion, 
                    serverLocation, 
                    UpgradeAndCancelEmptyServer);
            }
        }

        /// <summary>
        /// Negative test for the server upgrade operation
        /// </summary>
        [Fact]
        public void NegativeTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(
                    new BasicDelegatingHandler(), 
                    currentVersion, 
                    serverLocation, 
                    UpgradeServerNegative);
            }
        }

        /// <summary>
        /// Implementation of the positive test to upgrade server and poll for upgrade status until the upgrade is completed.
        /// The test server is empty
        /// </summary>
        /// <param name="sqlClient">The SQL Management client</param>
        /// <param name="resourceGroupName">The resource group containing the server to upgrade</param>
        /// <param name="server">The server to upgrade</param>
        private void UpgradeEmptyServer(SqlManagementClient sqlClient, string resourceGroupName, Server server)
        {
            UpgradeServer(sqlClient, resourceGroupName, server, null);
        }

        /// <summary>
        /// Implementation of the positive test to upgrade server and poll for upgrade status until the upgrade is completed.
        /// The test server has 1 database that will be mapped to a new edition and SLO after the upgrade
        /// </summary>
        /// <param name="sqlClient">The SQL Management client</param>
        /// <param name="resourceGroupName">The resource group containing the server to upgrade</param>
        /// <param name="server">The server to upgrade</param>
        /// <param name="database">The database under server that will be mapped to new edition and SLO</param>
        private void UpgradeServer(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            var parameters = CreateUpgradeStartParameters(database: database);

            var startResponse = sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, parameters);
            Assert.True(startResponse.StatusCode == HttpStatusCode.Accepted);

            // Get server upgrade status
            while (true)
            {
                var getUpgradeResponse = sqlClient.ServerUpgrades.Get(resourceGroupName, server.Name);
                if (getUpgradeResponse.StatusCode == HttpStatusCode.OK)
                {
                    Debug.WriteLine(getUpgradeResponse);
                    break;
                }

                // status must be Queued or InProgress
                Assert.True(getUpgradeResponse.Status.Equals(upgradeStatusQueued, StringComparison.InvariantCultureIgnoreCase) ||
                            getUpgradeResponse.Status.Equals(upgradeStatusInProgress, StringComparison.InvariantCultureIgnoreCase));

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(UpgradePollingTimeInSeconds));
            }

            // Make sure that server has new version
            var serverGetResponse = sqlClient.Servers.Get(resourceGroupName, server.Name);
            TestUtilities.ValidateOperationResponse(serverGetResponse);
            Assert.Equal(serverGetResponse.Server.Properties.Version, upgradedVersion);

            if (database != null)
            {
                // Make sure that database has new edition
                var databaseGetResponse = sqlClient.Databases.Get(resourceGroupName, server.Name, database.Name);
                TestUtilities.ValidateOperationResponse(databaseGetResponse);
                Assert.Equal(databaseGetResponse.Database.Properties.Edition, targetEdition);
            }
        }

        /// <summary>
        /// Implementation of the positive test to upgrade server, get upgrade status and cancel the upgrade successfully.
        /// </summary>
        /// <param name="sqlClient">The SQL Management client</param>
        /// <param name="resourceGroupName">The resource group containing the server to upgrade</param>
        /// <param name="server">The server to upgrade</param>
        private void UpgradeAndCancelEmptyServer(SqlManagementClient sqlClient, string resourceGroupName, Server server)
        {
            var parameters = CreateUpgradeStartParameters();

            var startResponse = sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, parameters);
            Assert.True(startResponse.StatusCode == HttpStatusCode.Accepted);

            // Polling for the upgrade status. When it's InProgress, we issue Cancel and verify that the status becomes Cancelling
            // and then BadRequest when the upgrade is cancelled
            bool cancelSent = false;
            while (true)
            {
                ServerUpgradeGetResponse getUpgradeResponse;
                try
                {
                    // Get the upgrade status
                    getUpgradeResponse = sqlClient.ServerUpgrades.Get(resourceGroupName, server.Name);
                }
                catch (CloudException exception)
                {
                    // Exception is expected when the cancel finishes
                    Debug.WriteLine(exception);
                    Assert.True(exception.Response.StatusCode == HttpStatusCode.BadRequest);
                    break;
                }

                if (cancelSent)
                {
                    // status must be Cancelling
                    Assert.True(getUpgradeResponse.Status.Equals(upgradeStatusCancelling, StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    Assert.True(getUpgradeResponse.Status.Equals(upgradeStatusQueued, StringComparison.InvariantCultureIgnoreCase) ||
                        getUpgradeResponse.Status.Equals(upgradeStatusInProgress, StringComparison.InvariantCultureIgnoreCase));

                    var cancelResponse = sqlClient.ServerUpgrades.Cancel(resourceGroupName, server.Name);
                    Assert.True(cancelResponse.StatusCode == HttpStatusCode.Accepted);
                    cancelSent = true;
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(UpgradePollingTimeInSeconds));
            }

            var getResponse = sqlClient.Servers.Get(resourceGroupName, server.Name);
            TestUtilities.ValidateOperationResponse(getResponse, HttpStatusCode.OK);
            // Verify the server version is correct
            Assert.Equal(getResponse.Server.Properties.Version, currentVersion);
        }

        /// <summary>
        /// Implementation of the negative test for upgrade server.
        /// </summary>
        /// <param name="sqlClient">The SQL Management client</param>
        /// <param name="resourceGroupName">The resource group containing the server to upgrade</param>
        /// <param name="server">The server to upgrade</param>
        /// <param name="database">The database under server that will be mapped to new edition and SLO</param>
        private void UpgradeServerNegative(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            // Null or empty parameter for upgrade
            Assert.Throws<ArgumentNullException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, null));
            Assert.Throws<ArgumentNullException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, new ServerUpgradeStartParameters()));

            // Invalid version
            var invalidVersionParameters = CreateUpgradeStartParameters(version: "13.0");
            Assert.Throws<CloudException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, invalidVersionParameters));

            // Invalid ScheduleAfter time
            var invalidScheduleParameters = CreateUpgradeStartParameters(scheduleUpgradeAfter: DateTime.UtcNow);
            Assert.Throws<CloudException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, invalidScheduleParameters));

            // Invalid edition
            var invalidEditionParameters = CreateUpgradeStartParameters(database: database);
            invalidEditionParameters.Properties.DatabaseCollection[0].TargetEdition = "InvalidEdition";
            Assert.Throws<CloudException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, invalidEditionParameters));

            // Invalid edition and slo combination
            var mismatchedSloAndEditionParameters = CreateUpgradeStartParameters(database: database);
            mismatchedSloAndEditionParameters.Properties.DatabaseCollection[0].TargetEdition = "Premium";
            mismatchedSloAndEditionParameters.Properties.DatabaseCollection[0].TargetServiceLevelObjective = "S0";
            Assert.Throws<CloudException>(() => sqlClient.ServerUpgrades.Start(resourceGroupName, server.Name, mismatchedSloAndEditionParameters));
        }

        /// <summary>
        /// Create upgrade start parameters for testing
        /// </summary>
        /// <param name="version">The version to upgrade the server to</param>
        /// <param name="scheduleUpgradeAfter">The earliest time to upgrade the server</param>
        /// <param name="database">The database to map to new edition and SLO. Target SLO and edition are in the constants at the top of this file</param>
        /// <returns>The server upgrade start parameters object</returns>
        private ServerUpgradeStartParameters CreateUpgradeStartParameters(
            string version = upgradedVersion,
            DateTime? scheduleUpgradeAfter = null,
            Database database = null)
        {
            var parameters = new ServerUpgradeStartParameters()
            {
                Properties = new ServerUpgradeProperties()
                {
                    Version = version,
                    ScheduleUpgradeAfterUtcDateTime = scheduleUpgradeAfter
                }
            };

            if (database != null)
            {
                parameters.Properties.DatabaseCollection = new List<RecommendedDatabaseProperties>()
                {
                    new RecommendedDatabaseProperties()
                    {
                        Name = database.Name,
                        TargetServiceLevelObjective = targetServiceLevelObjective,
                        TargetEdition = targetEdition
                    }
                };
            }

            return parameters;
        }
    }
}
