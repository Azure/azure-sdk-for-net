// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseActivationScenarioTests
    {
        [Fact]
        public void TestPauseResumeDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestPauseResumeDatabase", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create data warehouse
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                    Edition = DatabaseEdition.DataWarehouse
                });
                Assert.NotNull(db1);

                // Pause
                sqlClient.Databases.Pause(resourceGroup.Name, server.Name, dbName);
                // TODO: Get result and verify that status is now resumed - blocked by https://github.com/Azure/autorest/issues/2295

                // Resume
                sqlClient.Databases.Resume(resourceGroup.Name, server.Name, dbName);
                // TODO: Get result and verify that status is now resumed - blocked by https://github.com/Azure/autorest/issues/2295
            });
        }
    }
}
